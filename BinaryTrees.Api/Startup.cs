using BinaryTrees.Api.Controllers;
using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Resources;
using BinaryTrees.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
namespace BinaryTrees.Api;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IOperateTreeService<>), typeof(OperateTreeService<>));       
        services.AddScoped(typeof(IBinaryNodeService<>), typeof(BinaryNodeService<>));
        services.AddScoped(typeof(IBinaryNodeRepository<>), typeof(BinaryNodeRepository<>));
        // for Tests
        // services.AddScoped(typeof(IBinaryNodeRepository<int>), typeof(BinaryNodeRepository<int>));
        // services.AddScoped(typeof(IBinaryNodeRepository<string>), typeof(BinaryNodeRepository<string>));     
        
        services.AddScoped(typeof(IBinaryTree<>), typeof(BinaryTree<>));
        services.AddScoped(typeof(IBinaryNode<>), typeof(BinaryNode<>)); 

    //    services.AddScoped(typeof(IBinaryNodeResources<int>), typeof(BinaryNodeResources<int>)); 
    //    services.AddScoped(typeof(IBinaryNodeResources<string>), typeof(BinaryNodeResources<string>)); 
        services.AddScoped(typeof(IBinaryNodeResources<>), typeof(BinaryNodeResources<>));        
    //    services.AddTransient<Func<Guid>>(_ => () => Guid.NewGuid());

        services.AddControllers()
            .AddJsonOptions(options => 
                {
                    // options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.MaxDepth = 64;
                }) /*          
            .AddApplicationPart(typeof(BinaryNodesController<string>).Assembly)
            .AddApplicationPart(typeof(BinaryNodesController<int>).Assembly)*/;
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}