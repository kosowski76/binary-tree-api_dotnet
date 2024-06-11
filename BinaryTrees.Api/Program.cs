using BinaryTrees.Api.Controllers;
// using BinaryTree.Api.Exceptions;
using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Resources;
using BinaryTrees.Infrastructure.Services;
//using BinaryTree.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped(typeof(IOperateTreeService<>), typeof(OperateTreeService<>));
builder.Services.AddScoped(typeof(IBinaryNodeService<>), typeof(BinaryNodeService<>));

// builder.Services.AddScoped(typeof(IBinaryNodeRepository<int>), typeof(BinaryNodeRepository<int>));
// builder.Services.AddScoped(typeof(IBinaryNodeRepository<string>), typeof(BinaryNodeRepository<string>));
builder.Services.AddScoped(typeof(IBinaryNodeRepository<>), typeof(BinaryNodeRepository<>));

// builder.Services.AddScoped(typeof(IBinaryNodeResources<int>), typeof(BinaryNodeResources<int>));
// builder.Services.AddScoped(typeof(IBinaryNodeResources<string>), typeof(BinaryNodeResources<string>));
builder.Services.AddScoped(typeof(IBinaryNodeResources<>), typeof(BinaryNodeResources<>));

builder.Services.AddScoped(typeof(IBinaryTree<>), typeof(BinaryTree<>));
builder.Services.AddScoped(typeof(IBinaryNode<>), typeof(BinaryNode<>));
// builder.Services.AddScoped(typeof(IBinaryTreeService<>), typeof(BinaryTreeService<>));

// builder.Services.AddTransient<Func<Guid>>(_ => () => Guid.NewGuid());

builder.Services.AddControllers()
    .AddJsonOptions(options => 
        {
            // options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.MaxDepth = 64;
        }) /*
    .AddApplicationPart(typeof(BinaryNodesController<int>).Assembly)
    .AddApplicationPart(typeof(BinaryNodesController<string>).Assembly)*/;

//builder.Services.AddControllers(options => 
//{
//    options.RespectBrowserAcceptHeader = true;
//});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
