using BinaryTrees.Core.Domain;
namespace BinaryTrees.Core.Services;

public interface IOperateTreeService<T>
{
    public Task<BinaryNode<T>> NegateProcess(BinaryNode<T> node);
    public BinaryNode<T> InsertProcess(T value);
}

public interface IBinaryNodeService<T>
{
    Task<IEnumerable<BinaryNode<T>>> GetNodesAsync();
    Task<BinaryNode<T>> GetNodeAsync(T value);
    Task<BinaryNode<T>> AddNodeAsync(BinaryNode<T> node);
 //   void CreateNode(T value);Task<BinaryNode<T>> GetNodeAsync(T value);
    Task<BinaryNode<T>> UpdateNodeAsync(T value, BinaryNode<T> node);
    Task DeleteNodeAsync(T value);
}
