using BinaryTrees.Api.Application;
using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Services;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
// using Newtonsoft.Json;
namespace BinaryTrees.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class BinaryNodeIntController : BinaryNodeController<int>
{
    public BinaryNodeIntController(
        IBinaryNodeService<int> service, IOperateTreeService<int> operationsService) : base(service, operationsService)
    {
    }
}