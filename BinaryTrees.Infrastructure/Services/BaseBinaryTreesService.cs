using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Infrastructure.Resources;
using BinaryTrees.Infrastructure.Services;
namespace xBinaryTrees.Infrastructure.Services;

public class BaseBinaryTreeService<T> : IBaseBinaryTreeService<T>
{
    // protected readonly IBinaryTreeRepository<T> _binaryTreeRepository;
    ISet<BinaryTreeResult> _SourceBinaryTreeResults;
    protected IBinaryTree<T> _BinaryTree;
    public IBinaryNode<T> _BinaryNode;
    protected BinaryNode<T>? _Root;

    public BaseBinaryTreeService(/*
        IBinaryTreeRepository<T> IBinaryTreeRepository,*/)
    {
    //    _SourceBinaryTreeResults = BinaryNodeResources<T>.resultsNodesSource;
        //_binaryTreeRepository = IBinaryTreeRepository;
        _BinaryNode = new BinaryNode<T>();
        _Root = new BinaryNode<T>();
    }

    public async Task<IEnumerable<BinaryTreeResult>> BrowseAsync()
    {       
        // var nodes = await _binaryNodeRepository.BrowseAsync();
        var nodes = _SourceBinaryTreeResults.AsEnumerable();
        
        return await Task.FromResult(nodes);
    }

    public async Task<BinaryNode<T>> GetRootNodeAsync()
    {
        await Task.Delay(100);
        var nodeResult = _Root;

        return await Task.FromResult(nodeResult);
    }


    public void Insert(T value)
    {
        if (_Root == null)
            { _Root = new BinaryNode<T>(value); }
        else
            { InsertRec(_Root, new BinaryNode<T>(value)); }
    }

    private void InsertRec(BinaryNode<T> root, BinaryNode<T> newNode)
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
    }

    public async Task<BinaryNode<T>> CreateNodeAsync(T value)
    {
        if(_Root == null)
            { _Root = new BinaryNode<T>(value); }
        else
            { AddNodeRecursive(_Root, value); }

        return await Task.FromResult(_Root);
    }

    protected void AddNodeRecursive(BinaryNode<T> node, T value)
    {
        if(Comparer<T>.Default.Compare(value, node.Value) < 0)
        {
            if(node.Left == null)
                { node.Left = new BinaryNode<T>(value); }
            else
                { AddNodeRecursive(node.Left, value); }
        }
        else
        {
            if(node.Right == null)
                { node.Right = new BinaryNode<T>(value); }
            else
                { AddNodeRecursive(node.Right, value); }
        }
    }
}
