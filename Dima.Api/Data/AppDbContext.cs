using Dima.Api.Models;
using Dima.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Dima.Api.Data;

//para poder realizar a customização, neste caso criou o User
// <User, IdentityRole<long>, long>
public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<User, IdentityRole<long>, long, // Seria apenas isto, mas incluido abaixo para deixar completo
            IdentityUserClaim<long>, IdentityUserRole<long>,
            IdentityUserLogin<long>, IdentityRoleClaim<long>,
            IdentityUserToken<long>
            >(options)
{
    // No luga desse abaixo, usando   Prymary-construtor, acima.
    //public AppDbContext(DbContextOptions<AppDbContext> options)
    //    :base(options)
    //{

    //}


    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Caso queira fazer de modo individual... 
        //modelBuilder.ApplyConfiguration(new CategoryMapping());
        //modelBuilder.ApplyConfiguration(new TransactionMapping());

        //Caso queira todos de uma vez
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
