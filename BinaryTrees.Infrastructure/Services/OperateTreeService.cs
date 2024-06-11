using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Services;
namespace BinaryTrees.Infrastructure.Services;

public class OperateTreeService<T> : IOperateTreeService<T>
{
    public IBinaryTree<T> _BinaryTree;
    public BinaryNode<T>? _RootNode;

    public OperateTreeService()
    {
        _BinaryTree = new BinaryTree<T>();
        _RootNode = null;
    }

    protected async Task<BinaryNode<T>> GetRootAssync()
    {
        return _BinaryTree.Root;
    }
    
    public async Task<BinaryNode<T>> NegateProcess(BinaryNode<T> node)
    {
        var calcResult = await Task.Run(()
            => CalculationBinaryTree(node));

        return await Task.FromResult(_BinaryTree.Root);
    }

    public BinaryNode<T> InsertProcess(T value)
    {
        Insert(value); 

        return _RootNode;  
    }

    public async Task<CalculationResults> CalculationBinaryTree(BinaryNode<T> node)
    {            
        await Task.Delay(100);        
        _BinaryTree = new BinaryTree<T>(node);

        var treeNaturalInOrder = _BinaryTree.NaturalInOrder.Select(x => x.Value);
        var naturalInOrderResult = string.Join(",", treeNaturalInOrder);

        _BinaryTree.MakeABinaryMirror(node);

        var negativeResult =  string.Join(",",
            _BinaryTree.NaturalInOrder.Select(x => x.Value));

        return await Task.FromResult(new CalculationResults(
            naturalInOrderResult, negativeResult));
    }

    public async Task Insert(T value)
    {
        if (value == null)
            { throw new ArgumentNullException(nameof(value)); }

        // Logic for inserting an element into the tree
        if(_RootNode == null)
            { _RootNode = new BinaryNode<T>(value); }
        else
            { var result = InsertRec(_RootNode, new BinaryNode<T>(value)); }
                
        await Task.CompletedTask;
    }

    protected async Task InsertRec(BinaryNode<T> root, BinaryNode<T> newNode)
    {
        // Assuming T implements IComparable for simplicity, otherwise we need a custom comparer
        if (Comparer<T>.Default.Compare(newNode.Value, root.Value) < 0)
        {
            if (root.Left == null)
                { root.Left = newNode; }
            else
                { InsertRec(root.Left, newNode); }
        }
        else
        {
            if (root.Right == null)
                { root.Right = newNode; }
            else
                { InsertRec(root.Right, newNode); }
        }

        await Task.CompletedTask;
    }
}
