using BinaryTrees.Api.Application;
using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Services;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
// using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BinaryTrees.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class BinaryNodeController<T> : ControllerBase, IBinaryNodeController<T>
{
    private readonly IBinaryNodeService<T> _service;
    protected readonly IOperateTreeService<T> _operationsService;

    public BinaryNodeController(IBinaryNodeService<T> service,
        IOperateTreeService<T> operationsService)
    {
        _service = service;
        _operationsService = operationsService;
    }


    [HttpPost("negate")]
    public async Task<ActionResult<BinaryNode<T>>> NegateNode([FromBody] BinaryNode<T> node)
    {
        var validate = new JsonValidator<T>();
        validate.IsValid(node);

        var negatedNode = await _operationsService.NegateProcess(node);

        return Ok(negatedNode);
    }

    [HttpGet]
    public async Task<IActionResult> GetNodesAsync()
    // public async Task<ActionResult<IAsyncEnumerable<BinaryNode<T>>>> GetNodesAsync()
    {
        var nodes = await _service.GetNodesAsync();
        return Ok(nodes);
    }

    [HttpGet("{value}")]
    public async Task<ActionResult<BinaryNode<T>>> GetNodeAsync(T value)
    {
        var node = await _service.GetNodeAsync(value);
        if(node == null)
            { return NotFound(); }

        return Ok(node);
    }

    [HttpPost]
    public async Task<ActionResult<BinaryNode<T>>> AddNodeAsync(BinaryNode<T> node)
    {        
        var validate = new JsonValidator<T>();
        validate.IsValid(node);

        await _service.AddNodeAsync(node);

        return Ok(node);
    }

    [HttpPut("{value}")]
    public async Task<ActionResult> UpdateNodeAsync(T value, BinaryNode<T> node)
    {
        var existingNode = await _service.GetNodeAsync(value);
        if (existingNode == null)
            { return NotFound(); }

        await _service.UpdateNodeAsync(value, node);

        return NoContent();
    }

    [HttpDelete("{value}")]
    public async Task<IActionResult> DeleteNodeAsync(T value)
    {
        var node = await _service.GetNodeAsync(value);
        if (node == null)
            { return NotFound(); }

        await _service.DeleteNodeAsync(value);

        return NoContent();
    }

}
