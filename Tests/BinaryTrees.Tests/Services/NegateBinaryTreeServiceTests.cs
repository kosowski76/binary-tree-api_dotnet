namespace BinaryTrees.Tests.Services;
using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Services;
using FluentAssertions;
using Moq;
using Moq.Language;
using Moq.Language.Flow;
using Xunit;

public class BinaryTreeServiceTests
{
    private readonly IBinaryTree<int> _intBinaryTree;
    private readonly IBinaryTree<string> _strBinaryTree;

    public BinaryTreeServiceTests()
    {
        _intBinaryTree = new BinaryTree<int>();
        _strBinaryTree = new BinaryTree<string>();
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

        _intBinaryTree.MakeABinaryMirror(tree.Root);

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
        
        _strBinaryTree.MakeABinaryMirror(tree.Root);

        Assert.NotNull(tree.Root);
        Assert.Equal("root", tree.Root.Value);
        Assert.Equal("right", tree.Root.Left.Value);
        Assert.Equal("left", tree.Root.Right.Value);
    }


    [Fact(Skip = " for fix")]
    public async void Insert_ShouldAddElementsCorrectly()
    {
        // Arrange
        var service = new OperateTreeService<int>();

        // Act
       service.InsertProcess(10);
       service.InsertProcess(5);
       service.InsertProcess(15);

        // Assert
       service._RootNode.Value.Should().Be(10);
       service._RootNode.Left.Value.Should().Be(5);
       service._RootNode.Right.Value.Should().Be(15);
    }

    [Fact(Skip = " for fix")]
    public void Insert_StringElements_ShouldAddElementsCorrectly()
    {
        // Arrange
        var service = new OperateTreeService<string>();

        // Act
        service.InsertProcess("mango");
        service.InsertProcess("apple");
        service.InsertProcess("banana");

        // Assert
        service._RootNode.Value.Should().Be("mango");
        service._RootNode.Left.Value.Should().Be("apple");
        service._RootNode.Right.Value.Should().Be("banana");
    }
}

