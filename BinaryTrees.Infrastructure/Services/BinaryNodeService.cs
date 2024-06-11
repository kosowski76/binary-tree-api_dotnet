using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Core.Services;
namespace BinaryTrees.Infrastructure.Services;

public class BinaryNodeService<T> : IBinaryNodeService<T>
{
    private readonly IBinaryNodeRepository<T> _repository;
    // private readonly List<BinaryNode<T>> _nodes = new();

    public BinaryNodeService(IBinaryNodeRepository<T> repository)
    {
        _repository = repository;
    }
    public BinaryNodeService()
    {}

    public async Task<IEnumerable<BinaryNode<T>>> GetNodesAsync()
    {
        var nodes = await _repository.GetNodesAsync();
        return await Task.FromResult(nodes);
    }

    public async Task<BinaryNode<T>> GetNodeAsync(T value)
    {
        var node = await _repository.GetNodeAsync(value);
        return node;
    }

    public async Task<BinaryNode<T>> AddNodeAsync(BinaryNode<T> node)
    {        
        await Task.Run(() => _repository.AddNodeAsync(node));

        return await Task.FromResult(node);
    }

    public async Task<BinaryNode<T>> UpdateNodeAsync(T value, BinaryNode<T> node)
    {
        var existingNode = _repository.GetNodeAsync(value);
        if (existingNode == null)
            { return null; }

        await Task.Run(() => _repository.UpdateNodeAsync(value, node));

        return await Task.FromResult(node);
    }
    public async Task DeleteNodeAsync(T value)
    {
        var node = await _repository.GetNodeAsync(value);
        if (node != null)
        {
            await Task.Run(() => _repository.DeleteNodeAsync(value));            
        }
    }
}