using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Resources;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Moq;
namespace BinaryTrees.Tests.Repositories;

public class BinaryNodeRepositoryStringTests
{
    private readonly IBinaryNodeRepository<string> _repository;
    private IBinaryNodeResources<string> _binaryNodeSource;

    public BinaryNodeRepositoryStringTests()
    {
        _repository = new BinaryNodeRepository<string>();
    }

    [Fact]
    public async Task GetNodeAsync_ReturnsNode_WhenNodeExists()
    {
        // Arrange
        var expectedNode = new BinaryNode<string> { Value = "test" };
        //_repository = new BinaryNodeRepository<string>();
        await _repository.AddNodeAsync(expectedNode);

        // Act
        var result = await _repository.GetNodeAsync("test");

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().Be("test");
    }

    [Fact]
    public async Task GetNodeAsync_ReturnsNull_WhenNodeDoesNotExist()
    {
        // Act
        var result = await _repository.GetNodeAsync("non-existent");

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task AddNodeAsync_AddsNodeToRepository()
    {
        // Arrange
        var newNode = new BinaryNode<string> { Value = "newNode" };

        // Act
        var result = await _repository.AddNodeAsync(newNode);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().Be("newNode");
    }

    [Fact]
    public async Task UpdateNodeAsync_UpdatesExistingNode()
    {
        // Arrange
        var existingNode = new BinaryNode<string> { Value = "existingNode" };
        await _repository.AddNodeAsync(existingNode);
        var updatedNode = new BinaryNode<string> { Value = "updatedNode" };

        // Act
        await _repository.UpdateNodeAsync("existingNode", updatedNode);
        var result = await _repository.GetNodeAsync("updatedNode");

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().Be("updatedNode");
    }

    [Fact]
    public async Task DeleteNodeAsync_DeletesNodeFromRepository()
    {
        // Arrange
        var nodeToDelete = new BinaryNode<string> { Value = "nodeToDelete" };
        await _repository.AddNodeAsync(nodeToDelete);

        // Act
        await _repository.DeleteNodeAsync("nodeToDelete");
        var result = await _repository.GetNodeAsync("nodeToDelete");

        // Assert
        result.Should().BeNull();
    }
}
