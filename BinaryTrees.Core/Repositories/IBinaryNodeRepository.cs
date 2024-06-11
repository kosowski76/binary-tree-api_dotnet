using BinaryTrees.Core.Domain;
namespace BinaryTrees.Core.Repositories;

public interface IBinaryNodeRepository<T>
{
    Task<IEnumerable<BinaryNode<T>>> GetNodesAsync();
    Task<BinaryNode<T>> GetNodeAsync(T value);
    Task<BinaryNode<T>> AddNodeAsync(BinaryNode<T> node);
    Task<BinaryNode<T>> UpdateNodeAsync(T value, BinaryNode<T> node);
    Task DeleteNodeAsync(T value);

//    void SaveCalcultation(CalculateBinaryTree calculateBinaryTree);
//    CalculateBinaryTree GetCalcultationById(int id);
}