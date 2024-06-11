using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Resources;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Moq;
namespace BinaryTrees.Tests.Repositories;

public class BinaryNodeRepositoryIntTests
{
    private readonly IBinaryNodeRepository<int> _repository;
    public BinaryNodeRepositoryIntTests()
    {
        _repository = new BinaryNodeRepository<int>();
    }

    [Fact]
    public async Task GetNodeAsync_ReturnsNode_WhenNodeExists()
    {
        // Arrange
        var expectedNode = new BinaryNode<int> { Value = 1 };
        await _repository.AddNodeAsync(expectedNode);

        // Act
        var result = await _repository.GetNodeAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().Be(1);
    }

    [Fact]
    public async Task GetNodeAsync_ReturnsNull_WhenNodeDoesNotExist()
    {
        // Act
        var result = await _repository.GetNodeAsync(999);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task AddNodeAsync_AddsNodeToRepository()
    {
        // Arrange
        var newNode = new BinaryNode<int> { Value = 2 };

        // Act
        var result = await _repository.AddNodeAsync(newNode);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().Be(2);
    }

    [Fact]
    public async Task UpdateNodeAsync_UpdatesExistingNode()
    {
        // Arrange
        var existingNode = new BinaryNode<int> { Value = 3 };
        await _repository.AddNodeAsync(existingNode);
        var updatedNode = new BinaryNode<int> { Value = 4 };

        // Act
        await _repository.UpdateNodeAsync(3, updatedNode);
        var result = await _repository.GetNodeAsync(4);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().Be(4);
    }

    [Fact]
    public async Task DeleteNodeAsync_DeletesNodeFromRepository()
    {
        // Arrange
        var nodeToDelete = new BinaryNode<int> { Value = 5 };
        await _repository.AddNodeAsync(nodeToDelete);

        // Act
        await _repository.DeleteNodeAsync(5);
        var result = await _repository.GetNodeAsync(5);

        // Assert
        result.Should().BeNull();
    }
}