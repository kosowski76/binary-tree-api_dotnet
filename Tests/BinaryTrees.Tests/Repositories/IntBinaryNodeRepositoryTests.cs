using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Resources;
using BinaryTrees.Infrastructure.Services;
namespace BinaryTrees.Tests.Repositories;

public class IntBinaryNodeRepositoryTests
{
    private IBinaryNodeService<int> _service;
    private IBinaryNodeRepository<int> _repository;
    private IBinaryNodeResources<int>? _source;

    public IntBinaryNodeRepositoryTests()
    {
        _repository = new BinaryNodeRepository<int>();
        _service = new BinaryNodeService<int>(_repository);
    }

    [Fact]
    public async void GetAll_ReturnsEmptyList_WhenNoNodesExist()
    {
        _repository = new BinaryNodeRepository<int>();
        var nodes = await _repository.GetNodesAsync();

        Assert.Empty(nodes);
    }

    [Fact]
    public async void Add_AddsNodeToRepository()
    {
        var node = new BinaryNode<int>(5);

        await _repository.AddNodeAsync(node);
        var nodes = await _repository.GetNodesAsync();

        Assert.Contains(node, nodes);
    }

    [Fact]
    public async void GetByValue_ReturnsNode_WhenNodeExists()
    {
        var node = new BinaryNode<int>(5);
        await _repository.AddNodeAsync(node);

        var result = await _repository.GetNodeAsync(5);

        Assert.NotNull(result);
        Assert.Equal(5, result.Value);
    }

    [Fact]
    public async void GetByValue_ReturnsNull_WhenNodeDoesNotExist()
    {
        var result = await _repository.GetNodeAsync(999);

        Assert.Null(result);
    }

    [Fact]
    public async void Update_UpdatesExistingNode()
    {
        var node = new BinaryNode<int>(5);
        await _repository.AddNodeAsync(node);

        var updatedNode = new BinaryNode<int>(10) { Left = new BinaryNode<int>(3), Right = new BinaryNode<int>(8) };
        await _repository.UpdateNodeAsync(5, updatedNode);

        var result = await _repository.GetNodeAsync(10);

        Assert.NotNull(result);
        Assert.Equal(10, result.Value);
        Assert.Equal(3, result.Left.Value);
        Assert.Equal(8, result.Right.Value);

    }

    [Fact]
    public async void Delete_RemovesNode()
    {
        // Arrange
        var node = new BinaryNode<int>(5);

        await _service.AddNodeAsync(node);

        // Act
        await _repository.DeleteNodeAsync(node.Value);
        var result = await _repository.GetNodeAsync(node.Value);

        Assert.Null(result);
    }
}
