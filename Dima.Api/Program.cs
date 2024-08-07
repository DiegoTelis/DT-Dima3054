using Dima.Api;
using Dima.Api.Common.Api;
using Dima.Api.Endpoints;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrosOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if(app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();


app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseSecurity();

app.MapEndpoints();  // chamando metodo d EXTENSAO  generico para carregar os endpoints




app.Run();

//app.MapPost("/v1/categories", 
//    async (CreateCategoryRequest request, ICategoryHandler handler ) 
//        => await handler.CreateAsync(request))
//    .WithName("Categories: Create")
//    .WithSummary("Cria uma nova categoria")
//    .Produces<Response<Category?>>();

//app.MapPut("/v1/categories/{id}",
//                async ( long id,
//                  UpdateCategoryRequest request, 
//                  ICategoryHandler handler
//                )
//                    => 
//                    {
//                        request.Id = id;
//                        return await handler.UpdateAsync(request);
//                    }
//           )
//    .WithName("Categories: Update")
//    .WithSummary("Atualiza uma nova categoria")
//    .Produces<Response<Category?>>();

//app.MapDelete("/v1/categories/{id}",
//    async (long id, ICategoryHandler handler)
//        =>
//    {
//        var request = new DeleteCategoryRequest()
//        {
//            Id = id,
//            UserId = "diegot"
//        };
//        return await handler.DeleteAsync(request);
//    })
//    .WithName("Categories: Delete")
//    .WithSummary("Exclui uma nova categoria")
//    .Produces<Response<Category?>>();

//app.MapGet("/v1/categories",
//    async (ICategoryHandler handler)
//        =>
//    {
//        var request = new GetAllCategoriesRequest()
//        {
//            UserId = "diegot"
//        };
//        return await handler.GetAllAsync(request);
//    })
//    .WithName("Categories: GetAll")
//    .WithSummary("Retorna todas as categorias do usuario")
//    .Produces<PagedResponse<List<Category>?>>();

//app.MapGet("/v1/categories/{id}",
//    async (long id, /*DeleteCategoryRequest request,*/ ICategoryHandler handler)
//        =>
//    {
//        var request = new GetCategoryByIdRequest()
//        {
//            Id = id,
//            UserId = "diegot"
//        };
//        return await handler.GetByIdAsync(request);
//    })
//    .WithName("Categories: GetById")
//    .WithSummary("Retorna uma Categoria pelo Id")
//    .Produces<Response<Category?>>();

//app.Run();




//Handler
//public class Handler(AppDbContext context)
//{
//    public Response Handle(Request request)
//    {
//        var category = new Category
//        {
//            Title = request.Title,
//            Description = request.Description
//        };

//        //context.Categories.Add(category);
//        //context.SaveChanges();

//        return new Response
//        {
//             Id = category.Id,
//             Title = category.Title
//        };
//    }
//}
