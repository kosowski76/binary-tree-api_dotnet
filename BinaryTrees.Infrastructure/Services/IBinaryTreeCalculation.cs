using BinaryTrees.Core.Domain;
namespace BinaryTrees.Infrastructure.Services;

public interface IBinaryTreeCalculation<T>
{
    public Task<string> CalculationBinaryTree(BinaryNode<T> node);
    public Task<string> TreeResultNaturalInOrder(BinaryNode<T> node);
//    public BinaryNode<T> MakeABinaryMirror(BinaryNode<T> binaryNode);

//    public void MakeABinaryMirrorQueue(BinaryNode<T> root);

}
