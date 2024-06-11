namespace BinaryTrees.Tests.Services;
using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Services;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

public class BinaryNodeServiceIntTests
{
    private readonly Mock<IBinaryNodeRepository<int>> _repositoryMock;
    private readonly IBinaryNodeService<int> _service;

    public BinaryNodeServiceIntTests()
    {
        _repositoryMock = new Mock<IBinaryNodeRepository<int>>();
        _service = new BinaryNodeService<int>(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetNodeAsync_ReturnsNode_WhenNodeExists()
    {
        // Arrange
        var expectedNode = new BinaryNode<int> { Value = 1 };
        _repositoryMock.Setup(repo =>
            repo.GetNodeAsync(1)).ReturnsAsync(expectedNode);

        // Act
        var result = await _service.GetNodeAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Value);
    }

    [Fact]
    public async Task AddNodeAsync_AddsNodeToRepository()
    {
        // Arrange
        var newNode = new BinaryNode<int> { Value = 2 };

        // Act
        var result = await _service.AddNodeAsync(newNode);

        // Assert
        Assert.Equal(newNode, result);
        _repositoryMock.Verify(repo => repo.AddNodeAsync(newNode), Times.Once);
    }

    [Fact]
    public async Task UpdateNodeAsync_UpdatesExistingNode()
    {
        // Arrange
        var existingNode = new BinaryNode<int> { Value = 1 };
        _repositoryMock.Setup(repo =>
            repo.GetNodeAsync(1)).ReturnsAsync(existingNode);
        var updatedNode = new BinaryNode<int> { Value = 2 };

        // Act
        await _service.UpdateNodeAsync(1, updatedNode);

        // Assert
        _repositoryMock.Verify(repo =>
            repo.UpdateNodeAsync(1, updatedNode), Times.Once);
    }

    [Fact]
    public async Task DeleteNodeAsync_DeletesExistingNode()
    {
        // Arrange
        var existingNode = new BinaryNode<int> { Value = 1 };
        _repositoryMock.Setup(repo =>
            repo.GetNodeAsync(1)).ReturnsAsync(existingNode);

        // Act
        await _service.DeleteNodeAsync(1);

        // Assert
        _repositoryMock.Verify(repo => repo.DeleteNodeAsync(1), Times.Once); 
    }
}
