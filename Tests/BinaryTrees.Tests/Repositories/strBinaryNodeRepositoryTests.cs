using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Resources;
using BinaryTrees.Infrastructure.Services;
namespace BinaryTrees.Tests.Repositories;

public class StrBinaryNodeRepositoryTests
{
    private IBinaryNodeService<string> _service;
    private IBinaryNodeRepository<string> _repository;
    private IBinaryNodeResources<string>? _source;

    public StrBinaryNodeRepositoryTests()
    {
        _repository = new BinaryNodeRepository<string>();
        _service = new BinaryNodeService<string>(_repository);
    }

    [Fact]
    public async void GetAll_ReturnsEmptyList_WhenNoNodesExist()
    {
        var nodes = await _repository.GetNodesAsync();

        Assert.Empty(nodes);
    }

    [Fact]
    public async void Add_AddsNodeToRepository()
    {
        var node = new BinaryNode<string>("test");

        await _repository.AddNodeAsync(node);
        var nodes = await _repository.GetNodesAsync();        
        
        Assert.Contains(node, nodes);
    }
    
    [Fact]
    public async void GetByValue_ReturnsNode_WhenNodeExists()
    {
        var node = new BinaryNode<string>("test");

        await _repository.AddNodeAsync(node);
        var result = await _repository.GetNodeAsync("test");

        Assert.NotNull(result);
        Assert.Equal("test", result.Value);
    }

    [Fact]
    public async void GetByValue_ReturnsNull_WhenNodeDoesNotExist()
    {
        var result = await _repository.GetNodeAsync("nonexistent");

        Assert.Null(result);
    }

    [Fact]
    public async void Update_UpdatesExistingNode()
    {
        var node = new BinaryNode<string>("test");
        
        await _repository.AddNodeAsync(node);
        var updatedNode = new BinaryNode<string>("updated") { Left = new BinaryNode<string>("left"), Right = new BinaryNode<string>("right") };
        await _repository.UpdateNodeAsync("test", updatedNode);
        var result = await _repository.GetNodeAsync("updated");

        Assert.NotNull(result);
        Assert.Equal("updated", result.Value);
        Assert.Equal("left", result.Left.Value);
        Assert.Equal("right", result.Right.Value);
    }

    [Fact]
    public async void Delete_RemovesNode()
    {
        var node = new BinaryNode<string>("test");

        await _repository.AddNodeAsync(node);
        await _repository.DeleteNodeAsync("test");

        var result = await _repository.GetNodeAsync("test");

        Assert.Null(result);
    }
}
