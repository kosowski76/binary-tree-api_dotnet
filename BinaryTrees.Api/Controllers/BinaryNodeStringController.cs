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
[Route("api/[controller]")]public class BinaryNodeStrController : BinaryNodeController<string>
{
    public BinaryNodeStrController(
        IBinaryNodeService<string> service, IOperateTreeService<string> operationsService) : base(service, operationsService)
    {
    }
}