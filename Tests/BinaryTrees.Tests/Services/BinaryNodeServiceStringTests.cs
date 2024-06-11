namespace BinaryTrees.Tests.Services;
using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Services;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

public class BinaryNodeServiceStringTests
{
    private readonly Mock<IBinaryNodeRepository<string>> _repositoryMock;
    private readonly IBinaryNodeService<string> _service;

    public BinaryNodeServiceStringTests()
    {
        _repositoryMock = new Mock<IBinaryNodeRepository<string>>();
        _service = new BinaryNodeService<string>(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetNodeAsync_ReturnsNode_WhenNodeExists()
    {
        // Arrange
        var expectedNode = new BinaryNode<string> { Value = "test" };
        _repositoryMock.Setup(repo =>
            repo.GetNodeAsync("test")).ReturnsAsync(expectedNode);

        // Act
        var result = await _service.GetNodeAsync("test");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("test", result.Value);
    }

    [Fact]
    public async Task AddNodeAsync_AddsNodeToRepository()
    {
        // Arrange
        var newNode = new BinaryNode<string> { Value = "newNode" };

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
        var existingNode = new BinaryNode<string> { Value = "test" };
        _repositoryMock.Setup(repo =>
            repo.GetNodeAsync("test")).ReturnsAsync(existingNode);

        var updatedNode = new BinaryNode<string> { Value = "updatedNode" };

        // Act
        await _service.UpdateNodeAsync("test", updatedNode);

        // Assert
        _repositoryMock.Verify(repo =>
        repo.UpdateNodeAsync("test", updatedNode), Times.Once);
    }

    [Fact]
    public async Task DeleteNodeAsync_DeletesExistingNode()
    {
        // Arrange
        var existingNode = new BinaryNode<string> { Value = "test" };
        _repositoryMock.Setup(repo =>
            repo.GetNodeAsync("test")).ReturnsAsync(existingNode);

        // Act
        await _service.DeleteNodeAsync("test");

        // Assert
        _repositoryMock.Verify(repo =>
            repo.DeleteNodeAsync("test"), Times.Once);
    }

}