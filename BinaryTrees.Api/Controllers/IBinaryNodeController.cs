using BinaryTrees.Core.Domain;
using Microsoft.AspNetCore.Mvc;
namespace BinaryTrees.Api.Controllers;

public interface IBinaryNodeController<T>
{
    public Task<IActionResult> GetNodesAsync();
    public Task<ActionResult<BinaryNode<T>>> GetNodeAsync(T value);
    public Task<ActionResult<BinaryNode<T>>> AddNodeAsync(BinaryNode<T> node);
//    public IActionResult CreateNodeAsync(T value);
    public Task<ActionResult> UpdateNodeAsync(T value, BinaryNode<T> node);
    public Task<IActionResult> DeleteNodeAsync(T value);
}