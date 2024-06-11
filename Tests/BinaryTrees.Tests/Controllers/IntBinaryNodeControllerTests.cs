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
namespace BinaryTrees.Tests.Conrollers;

public class IntBinaryNodeControllerTests
{
    protected BinaryNodeController<int> _controller;
    private readonly BinaryNodeService<int> _service;
    protected readonly OperateTreeService<int> _operationService;
    protected BinaryNodeRepository<int> _repository;

    public IntBinaryNodeControllerTests()
    {
        _repository = new BinaryNodeRepository<int>();
        _service = new BinaryNodeService<int>(_repository);
        _operationService = new OperateTreeService<int>();
        _controller = new BinaryNodeController<int>(_service, _operationService);
    }

    [Fact]
    public async Task GetIntNodesAsync_ReturnsAllNodes()
    {
        // Arrange
        var node1 = new BinaryNode<int> { Value = 10 };
        var node2 = new BinaryNode<int> { Value = 20 };
        await _service.AddNodeAsync(node1);
        await _service.AddNodeAsync(node2);

        // Act
        var result = await _controller.GetNodesAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var nodes =
        Assert.IsAssignableFrom<IEnumerable<BinaryNode<int>>>(okResult.Value);
        Assert.Equal(2, nodes.Count());
    }

    [Fact]
    public async Task GetIntNodeByIdAsync_ReturnsNode()
    {
        // Arrange
        var node = new BinaryNode<int> { Value = 10 };
        await _service.AddNodeAsync(node);
        // Act
        var result = await _controller.GetNodeAsync(10);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedNode = Assert.IsType<BinaryNode<int>>(okResult.Value);
        Assert.Equal(10, returnedNode.Value);
    }

}
