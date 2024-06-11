using BinaryTrees.Core.Domain;
namespace BinaryTrees.Core.Domain;

public interface IBinaryTree<T>
{
    public BinaryNode<T>? Root { get; set; }
    IEnumerable<BinaryNode<T>> NaturalInOrder { get; }

    public void MakeABinaryMirror();
    public BinaryNode<T> MakeABinaryMirror(BinaryNode<T> node);
    public void MakeABinaryMirrorQueue(BinaryNode<T> binaryNode);
}

public class BinaryTree<T> : IBinaryTree<T>
{
    public BinaryNode<T>? Root { get; set; }
    
    public BinaryTree(BinaryNode<T> root)
    {
        this.Root = root;
    }
    
    public BinaryTree()
    {
        this.Root = null;
    }
    
    public IEnumerable<BinaryNode<T>> NaturalInOrder
    {
        get
        {
            IEnumerable<BinaryNode<T>> TraverseInOrder(BinaryNode<T> current)
            {
                if (current.Left != null)
                {
                    foreach (var left in TraverseInOrder(current.Left))
                        yield return left;
                }

                yield return current;

                if (current.Right != null)
                {
                    foreach (var right in TraverseInOrder(current.Right))
                        yield return right;
                }
            }
            foreach (var node in TraverseInOrder(Root))
                yield return node;
        }
    }
    
    public void MakeABinaryMirror()
    {
        Root = MakeABinaryMirror(Root);
    }
    public BinaryNode<T> MakeABinaryMirror(BinaryNode<T> binaryNode)
    {
        if (binaryNode == null)
            { return binaryNode; }
 
        /* do the subtrees */
        BinaryNode<T> left = MakeABinaryMirror(binaryNode.Left);
        BinaryNode<T> right = MakeABinaryMirror(binaryNode.Right);
 
        /* swap the left and right pointers */
        binaryNode.Left = right;
        binaryNode.Right = left;
 
        return binaryNode;
    }

    public void MakeABinaryMirrorQueue(BinaryNode<T> root)
    {
        if (root == null)
        {
            return;
        }
 
        Queue<BinaryNode<T>> q = new Queue<BinaryNode<T>>();
        q.Enqueue(root);
 
        /** Do BFS. While doing BFS, keep swapping
         *  left and right children **/
        while (q.Count > 0)
        {
                // pop top node from queue
            BinaryNode<T> curr = q.Peek();
            q.Dequeue();
 
                // swap left child with right child
            BinaryNode<T> temp = curr.Left;
            curr.Left = curr.Right;
            curr.Right = temp;
 
                // push left and right children
            if (curr.Left != null)
            {
                q.Enqueue(curr.Left);
            }
            if (curr.Right != null)
            {
                q.Enqueue(curr.Right);
            }
        }

    }
}

public interface IBinaryTree2<T>
{
    public IBinaryNode<T>? Root { get; set; }

    IEnumerable<IBinaryNode<T>> NaturalInOrder { get; }

    public IBinaryNode<T> MakeABinaryMirror(IBinaryNode<T> node);
}

public class BinaryTree2<T> : IBinaryTree2<T>
{
    public IBinaryNode<T>? Root { get; set; }

    public BinaryTree2(IBinaryNode<T> root)
    {
        this.Root = root;
    }

    public BinaryTree2()
    {}

    public IEnumerable<IBinaryNode<T>> NaturalInOrder
    {
        get
        {
            IEnumerable<IBinaryNode<T>> TraverseInOrder(IBinaryNode<T> current)
            {
                if (current.Left != null)
                {
                    foreach (var left in TraverseInOrder(current.Left))
                        yield return left;
                }

                yield return current;

                if (current.Right != null)
                {
                    foreach (var right in TraverseInOrder(current.Right))
                        yield return right;
                }
            }
            foreach (var node in TraverseInOrder(Root))
                yield return node;
        }
    }
    
    public void MakeABinaryMirror()
    {
        Root = MakeABinaryMirror(Root);
    }

    public IBinaryNode<T> MakeANegativeTree(IBinaryNode<T> node)
    {
        if(node == null)
        {
            return new BinaryNode<T>(){};
        }

        // Swap the left and rigth childern
        var temp = node.Left;
        node.Left = node.Right;
        node.Right = temp;

        // Recursively negate the left and right subtree
        MakeABinaryMirror(node.Left);
        MakeABinaryMirror(node.Right);

        return node;
    }

    public IBinaryNode<T> MakeABinaryMirror(IBinaryNode<T> node)
    {
        if(node == null)
            { return node; }
 
        /* do the subtrees */
        IBinaryNode<T> left = MakeABinaryMirror(node.Left);
        IBinaryNode<T> right = MakeABinaryMirror(node.Right);
 
        /* swap the left and right pointers */
        node.Left = (BinaryNode<T>)right;
        node.Right = (BinaryNode<T>)left;

        return node;
    }
}
