using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Services;
namespace BinaryTrees.Tests.Domain;


public class BinaryTreeDomainTest
{
    protected OperateTreeService<int> _intNegateTreeService;
    protected OperateTreeService<string> _strNegateTreeService;
    protected IBinaryTree<int> _intBinaryTree;
    protected IBinaryTree<string> _strBinaryTree;
    protected BinaryNode<int> _IntRoot;
    protected BinaryNode<string> _StrRoot;


    public BinaryTreeDomainTest()
    {
        _intNegateTreeService = new OperateTreeService<int>();
        _strNegateTreeService = new OperateTreeService<string>();

        _intBinaryTree = new BinaryTree<int>();
        _strBinaryTree = new BinaryTree<string>();

        _IntRoot = new BinaryNode<int>();
        _StrRoot = new BinaryNode<string>();
    }
    public static IEnumerable<object[]> _NegateDataTreeStr =>
        new List<object[]>
        {                
            new object[] { new BinaryNode<string>("A", new BinaryNode<string>("B", new BinaryNode<string>("D")),
                new BinaryNode<string>("C", new BinaryNode<string>("D"), new BinaryNode<string>("E"))),
                    "D,B,A,D,C,E", "E,C,D,A,B,D" },

            new object[] { new BinaryNode<string>("C", new BinaryNode<string>("B", new BinaryNode<string>("A")),
                new BinaryNode<string>("E", new BinaryNode<string>("D"), new BinaryNode<string>("F"))),
                    "A,B,C,D,E,F", "F,E,D,C,B,A" },

            new object[] {  new BinaryNode<string>("A", new BinaryNode<string>("B", null, new BinaryNode<string>("D")),
                new BinaryNode<string>("C", new BinaryNode<string>("D"), new BinaryNode<string>("E"))),
                    "B,D,A,D,C,E", "E,C,D,A,D,B" },

            new object[] { new BinaryNode<string>("F", new BinaryNode<string>("B", new BinaryNode<string>("A"),
                new BinaryNode<string>("D", new BinaryNode<string>("C"), new BinaryNode<string>("E"))),
                new BinaryNode<string>("I", new BinaryNode<string>("H", new BinaryNode<string>("G")))),
                    "A,B,C,D,E,F,G,H,I", "I,H,G,F,E,D,C,B,A" }
        };
    [Theory]
    [MemberData(nameof(_NegateDataTreeStr))]
    public void Should_set_negate_Root_MultipleChild_BinaryNode_string_and_Traverse_by_natural_in_order(
        BinaryNode<string> binaryNode, string expected, string negated)
    {
        // Arrange
        _strBinaryTree = new BinaryTree<string>(binaryNode);
        //Act
        var result = string.Join(",", 
            _strBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(expected, result);
        Assert.Contains(binaryNode, _strBinaryTree.NaturalInOrder);

        //Act
        _strBinaryTree.MakeABinaryMirror();
        result = string.Join(",", 
            _strBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(negated, result);
        Assert.Contains(binaryNode, _strBinaryTree.NaturalInOrder);

        //Act
        var root = _strBinaryTree.Root;
        _strBinaryTree.MakeABinaryMirrorQueue(root);
        result = string.Join(",", 
            _strBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(expected, result);
        Assert.Contains(binaryNode, _strBinaryTree.NaturalInOrder);
    }

    public static IEnumerable<object[]> _NegateDataTreeInt =>
        new List<object[]>
        {
            new object[] { new BinaryNode<int>(0, new BinaryNode<int>(-1), new BinaryNode<int>(1)), "-1,0,1", "1,0,-1" },

            new object[] { new BinaryNode<int>(-1, new BinaryNode<int>(-2),
                new BinaryNode<int>(4, new BinaryNode<int>(2,
                new BinaryNode<int>(1), new BinaryNode<int>(3)), new BinaryNode<int>(5))), "-2,-1,1,2,3,4,5", "5,4,3,2,1,-1,-2" },

            new object[] { new BinaryNode<int>(0, new BinaryNode<int>(-1),
                new BinaryNode<int>(4, new BinaryNode<int>(2,
                new BinaryNode<int>(1), new BinaryNode<int>(3)), new BinaryNode<int>(5))), "-1,0,1,2,3,4,5", "5,4,3,2,1,0,-1" },

            new object[] { new BinaryNode<int>(0, new BinaryNode<int>(-2,
                new BinaryNode<int>(-3), new BinaryNode<int>(-1)), new BinaryNode<int>(4,
                new BinaryNode<int>(2, new BinaryNode<int>(1), new BinaryNode<int>(3)),
                new BinaryNode<int>(6, new BinaryNode<int>(5), new BinaryNode<int>(7)))), "-3,-2,-1,0,1,2,3,4,5,6,7", "7,6,5,4,3,2,1,0,-1,-2,-3" }
        };
    [Theory]
    [MemberData(nameof(_NegateDataTreeInt))]
    public void Should_set_negate_Rroot_MultipleChild_BinaryNode_int_and_Traverse_by_natural_in_order(
        BinaryNode<int> binaryNode, string expected, string negated)
    {
        // Arrange
        _intBinaryTree = new BinaryTree<int>(binaryNode);
        //Act
        var result = string.Join(",", 
            _intBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(expected, result);
        Assert.Contains(binaryNode, _intBinaryTree.NaturalInOrder);

        //Act
        _intBinaryTree.MakeABinaryMirror();
        result = string.Join(",", 
            _intBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(negated, result);
        Assert.Contains(binaryNode, _intBinaryTree.NaturalInOrder);

        //Act
        var root = _intBinaryTree.Root;
        _intBinaryTree.MakeABinaryMirrorQueue(root);
        result = string.Join(",", 
            _intBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(expected, result);
        Assert.Contains(binaryNode, _intBinaryTree.NaturalInOrder);
    }

    [Theory]
    [MemberData(nameof(_NegateDataTreeInt))]
    public void Should_set_negate_IRroot_MultipleChild_BinaryNode_Int(
        BinaryNode<int> binaryNode, string expected, string negated)
    {
        // Arrange
        _IntRoot = binaryNode;
        _intBinaryTree.Root = _IntRoot;
        //Act
        var result = string.Join(",", 
            _intBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(expected, result);
        Assert.Contains(binaryNode, _intBinaryTree.NaturalInOrder);

        //Act
        _intBinaryTree.MakeABinaryMirror();
        result = string.Join(",", 
            _intBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(negated, result);
        Assert.Contains(binaryNode, _intBinaryTree.NaturalInOrder);

        //Act
        var root = _intBinaryTree.Root;
        _intBinaryTree.MakeABinaryMirrorQueue(root);
        result = string.Join(",", 
            _intBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(expected, result);
        Assert.Contains(binaryNode, _intBinaryTree.NaturalInOrder);
    }

    public static IEnumerable<object[]> _TestDataString =>
        new List<object[]>
        {                
            new object[] { new BinaryNode<string>("A", new BinaryNode<string>("B", new BinaryNode<string>("D")),
                new BinaryNode<string>("C", new BinaryNode<string>("D"), new BinaryNode<string>("E"))), "D,B,A,D,C,E" },

            new object[] { new BinaryNode<string>("C", new BinaryNode<string>("B", new BinaryNode<string>("A")),
                new BinaryNode<string>("E", new BinaryNode<string>("D"), new BinaryNode<string>("F"))), "A,B,C,D,E,F" },

            new object[] {  new BinaryNode<string>("A", new BinaryNode<string>("B", null, new BinaryNode<string>("D")),
                new BinaryNode<string>("C", new BinaryNode<string>("D"), new BinaryNode<string>("E"))), "B,D,A,D,C,E" },

            new object[] { new BinaryNode<string>("F", new BinaryNode<string>("B", new BinaryNode<string>("A"),
                new BinaryNode<string>("D", new BinaryNode<string>("C"), new BinaryNode<string>("E"))),
                new BinaryNode<string>("I", new BinaryNode<string>("H", new BinaryNode<string>("G")))), "A,B,C,D,E,F,G,H,I" }
        };
    [Theory]
    [MemberData(nameof(_TestDataString))]
    public void Should_set_root_MultipleChild_BinaryNode_string_and_Traverse_by_natural_in_order(
        BinaryNode<string> binaryNode, string expected)
    {
        // Arrange
        _strBinaryTree = new BinaryTree<string>(binaryNode);
        //Act
        var result = string.Join(",", 
            _strBinaryTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal(expected, result);
        Assert.Contains(binaryNode, _strBinaryTree.NaturalInOrder);
    }

   [Fact]
    public void Should_set_root_BinaryNode_and_Traverse_by_natural_in_order()
    {
        // Arrange
        var BinaryNodeRoot = new BinaryNode<int>(-1, new BinaryNode<int>(-2),
            new BinaryNode<int>(4,
            new BinaryNode<int>(2, new BinaryNode<int>(1), new BinaryNode<int>(3)),
            new BinaryNode<int>(5)));
            
        var BinaryNodeTree = new BinaryTree<int>(BinaryNodeRoot);
        // Act
        var result = string.Join(",", 
            BinaryNodeTree.NaturalInOrder.Select(x => x.Value));

        // Assert
        Assert.Equal("-2,-1,1,2,3,4,5", result);
        Assert.Contains(BinaryNodeRoot, BinaryNodeTree.NaturalInOrder);
    }

    [Fact]
    public void WhenGivenValidBinaryNode_ReturnsVaildBinaryNode()
    {
        var root = new BinaryNode<int>(3,
            new BinaryNode<int>(2),
            new BinaryNode<int>(1));
        var tree = new BinaryTree<int>(root);

        var resultList = string.Join(",",
            tree.NaturalInOrder.Select(x => x.Value));

        Assert.Equal("2,3,1", resultList);

        tree.MakeABinaryMirror();
        var mirrorList = string.Join(",",
            tree.NaturalInOrder.Select(x => x.Value));

        Assert.Equal("1,3,2", mirrorList);
    }

    [Fact]
    public void NegateTree_NegatesIntTree()
    {
        var tree = new BinaryTree<int>
        {
            Root = new BinaryNode<int>(1)
            {
                Left = new BinaryNode<int>(2),
                Right = new BinaryNode<int>(3)
            }
        };
        var negatedNode = new BinaryNode<int>();
        
        Assert.NotSame(negatedNode, tree.Root);

        negatedNode = _intBinaryTree.MakeABinaryMirror(tree.Root);

        Assert.Same(negatedNode, tree.Root); 
        Assert.NotNull(tree.Root);
        Assert.Equal(1, tree.Root.Value);
        Assert.Equal(3, tree.Root.Left.Value);
        Assert.Equal(2, tree.Root.Right.Value);
    }

    [Fact]
    public void NegateTree_NegatesStringTree()
    {
        var tree = new BinaryTree<string>
        {
            Root = new BinaryNode<string>("root")
            {
                Left = new BinaryNode<string>("left"),
                Right = new BinaryNode<string>("right")
            }
        };
        var negatedNode = new BinaryNode<string>();

        Assert.NotSame(negatedNode, tree.Root);

        negatedNode = _strBinaryTree.MakeABinaryMirror(tree.Root);

        Assert.Same(negatedNode, tree.Root);
        Assert.NotNull(tree.Root);
        Assert.Equal("root", tree.Root.Value);
        Assert.Equal("right", tree.Root.Left.Value);
        Assert.Equal("left", tree.Root.Right.Value);
    }
}
