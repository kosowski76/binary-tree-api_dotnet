using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Infrastructure.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BinaryTrees.Infrastructure.Repositories;

public class BinaryNodeRepository<T> : IBinaryNodeRepository<T>
{
    protected readonly List<BinaryNode<T>> _nodes = new List<BinaryNode<T>>();
    protected IBinaryNodeResources<T>? _binaryNodeSource;

    public BinaryNodeRepository()
    {
        // _nodes = new List<BinaryNode<T>>();
        // ISet<BinaryNode<T>> _nodes = new HashSet<BinaryNode<T>>();
    }

    public async Task<IEnumerable<BinaryNode<T>>> GetNodesAsync()
    {
        await Task.Delay(100);
        //foreach(var node in _nodes)
        //  { yield return node; }
        var nodes = _nodes.AsEnumerable();

        return await Task.FromResult(_nodes);
    }

    public async Task<BinaryNode<T>> GetNodeAsync(T value)
    {
        await Task.Delay(100);
        var node = _nodes.FirstOrDefault(n =>
            EqualityComparer<T>.Default.Equals(n.Value, value));

        return await Task.FromResult(node);
    }

    public async Task<BinaryNode<T>> AddNodeAsync(BinaryNode<T> node)
    {
        await Task.Delay(100);
        if(node == null)
            { throw new ArgumentNullException(nameof(node)); }

        _nodes.Add(node);

        return await Task.FromResult(node);
    }

    public async Task<BinaryNode<T>> UpdateNodeAsync(T value, BinaryNode<T> node)
    {
        await Task.Delay(100);
        var existingNode = _nodes.FirstOrDefault(n =>
            EqualityComparer<T>.Default.Equals(n.Value, value));

        if (existingNode != null)
        {
            existingNode.Value = node.Value;
            existingNode.Left = node.Left;
            existingNode.Right = node.Right;
        }

        return await Task.FromResult(node);
    }

    public async Task DeleteNodeAsync(T value)
    {
        await Task.Delay(100);
        
        var node = _nodes.FirstOrDefault(n =>
            EqualityComparer<T>.Default.Equals(n.Value, value));
        if (node != null)
            { _nodes.Remove(node); }

        await Task.CompletedTask;
    }
}
