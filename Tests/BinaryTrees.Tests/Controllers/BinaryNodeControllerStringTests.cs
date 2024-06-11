namespace BinaryTrees.Tests.Conrollers;
using BinaryTrees.Api.Controllers;
using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Language;
using Moq.Language.Flow;
using System.Threading.Tasks;
using Xunit;

public class BinaryNodeControllerStringTests
{
    private readonly Mock<IOperateTreeService<string>> _mockOperate;
    private readonly Mock<IBinaryNodeService<string>> _mockService;
    private IBinaryNodeController<string> _controller;

    public BinaryNodeControllerStringTests()
    {
        _mockService = new Mock<IBinaryNodeService<string>>();
        _mockOperate = new Mock<IOperateTreeService<string>>();
        _controller = new BinaryNodeController<string>(_mockService.Object, _mockOperate.Object);
    }

    [Fact]
    public async Task GetNodeAsync_ReturnsNode_WhenNodeExists()
    {
        // Arrange
        var testValue = "test";
        var expectedNode = new BinaryNode<string> { Value = testValue };
        _mockService.Setup(service =>
            service.GetNodeAsync(testValue)).ReturnsAsync(expectedNode);

        // Act
        var result = await _controller.GetNodeAsync(testValue);

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);

        var returnedNode = okResult.Value as BinaryNode<string>;
        Assert.NotNull(returnedNode);
        Assert.Equal(testValue, returnedNode.Value);
    }

    [Fact]
    public async Task GetNodeAsync_ReturnsNotFound_WhenNodeIsNull()
    {
        // Arrange
        var testValue = "test";
        var expectedNode = new BinaryNode<string> { Value = testValue };
        _mockService.Setup(service =>
            service.GetNodeAsync(testValue)).ReturnsAsync(expectedNode);

        // Act
        var result = await _controller.GetNodeAsync("test");

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);

        var returnedNode = okResult.Value as BinaryNode<string>;
        Assert.NotNull(returnedNode);
        Assert.Equal(testValue, returnedNode.Value);
    }

    [Fact]
    public async Task AddNodeAsync_ReturnsCreatedNode()
    {
        // Arrange
        var testValue = "newNode";
        var newNode = new BinaryNode<string> { Value = testValue };
        _mockService.Setup(service =>
            service.AddNodeAsync(newNode)).ReturnsAsync(newNode);

        // Act
        var result = await _controller.AddNodeAsync(newNode);

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);

        var returnedNode = okResult.Value as BinaryNode<string>;
        Assert.NotNull(returnedNode);
        Assert.Equal(testValue, returnedNode.Value);
    }

}
