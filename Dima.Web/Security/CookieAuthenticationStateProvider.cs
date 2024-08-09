﻿using Dima.Core.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Dima.Web.Security
{
    public class CookieAuthenticationStateProvider(IHttpClientFactory clientFactory) : AuthenticationStateProvider, ICookieAuthenticationStateProvider
    {
        private bool _isAtuthenticated = false;
        private readonly HttpClient _httpClient = clientFactory.CreateClient(Configuration.HttpClientName);
      
        public async Task<bool> CheckAuthenticatedAsync()
        {
            await GetAuthenticationStateAsync();  
            return _isAtuthenticated;
        }

        public void NotifyAuthenticationStateChanged() 
            => base.NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {//precisa 
            //user
            //Roles  => RoleClaims
            _isAtuthenticated = false;
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var userInfo = await GetUser();
            if (userInfo is null)
                return new AuthenticationState(user);  

            var claims = await GetClaims(userInfo);

            var id = new ClaimsIdentity(claims, nameof(CookieAuthenticationStateProvider));
            user = new ClaimsPrincipal(id);

            _isAtuthenticated = true;
            return new AuthenticationState(user);
        }

        private async Task<User?> GetUser()
        {
            try
            {
                //var x1 =  await _httpClient.GetAsync("v1/identity/manage/info");
                //var x =  await _httpClient.GetFromJsonAsync<User?>("v1/identity/manage/info");
                //return x;
                return await _httpClient.GetFromJsonAsync<User?>("v1/identity/manage/info");
            }
            catch (Exception ex) 
            {
                _ = ex.Message;
                return null;
            }
        }

        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , user.Email),
                new(ClaimTypes.Email, user.Email)
            };

            claims.AddRange(
                user.Claims.Where(x => x.Key != ClaimTypes.Name && x.Key != ClaimTypes.Email)
                .Select(s => new Claim(s.Key, s.Value))
            );

            RoleClaim[]? roles;
            try
            {
                roles = await _httpClient.GetFromJsonAsync<RoleClaim[]>("v1/identity/roles");
            }
            catch 
            {
                return claims;
            }

            //foreach (var role in roles ?? [])
            //{
            //    if (!string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.Value))
            //        claims.Add(new Claim(role.Type, role.Value, role.ValueType, role.Issuer, role.OriginalIssuer));
            //}

            //---mudando para link

            claims.AddRange(
                from role in roles ?? []
                where !string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.Value)
                select new Claim(role?.Type ?? "", role.Value ?? "", role.ValueType, role.Issuer, role.OriginalIssuer)
            );


            return claims;
        }


    }
}
