using BinaryTrees.Api;
using BinaryTrees.Core.Domain;
using BinaryTrees.Core.Repositories;
using BinaryTrees.Core.Services;
using BinaryTrees.Infrastructure.Repositories;
using BinaryTrees.Infrastructure.Resources;
using BinaryTrees.Infrastructure.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
// using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
namespace BinaryTrees.Tests.EndToEnd;

public class BinaryNodesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
{
    protected readonly WebApplicationFactory<Startup> _factory;
    protected readonly HttpClient _client;
    protected readonly string _path;
    protected List<BinaryNode<int>> _intNodesSource;
    protected List<BinaryNode<string>> _strNodesSource;
    //protected IBinaryNodeRepository<int> _binaryNodeRrepository;

    public BinaryNodesControllerTests(WebApplicationFactory<Startup> factory)
    {        
        //_intNodesSource = BinaryNodeResources<int>._BinaryNodeSources;        
        //_strNodesSource = BinaryNodeResources<string>._BinaryNodeSources;
        
        _factory = factory;
        _client = _factory.CreateClient();

        _path = "binarynodeint";
    }
    
    protected void SeedDatabaseWithNode(Guid nodeId)
    {
        // Custom method to seed database with a Node entity
        // now for developing is pathed to main Sources
    }

    [Fact]
    public async Task Get_Enpoint_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/nonexixtent-endpoint");
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact(Skip = "test implementation")]
    public async Task GetNodesAsync_ReturnsNull()
    {
        // Act
        var response = await _client.GetAsync($"api/{_path}");        
        // Assert
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        
        Assert.False(string.IsNullOrEmpty(jsonString), "Response content is empty");
        
        var nodes = await response.Content.ReadFromJsonAsync<IEnumerable<BinaryNode<int>>>();
        Assert.Null(nodes);
        Assert.Empty(nodes);
        nodes.Should().BeNull();
        nodes.Should().BeEmpty();
    }

    [Fact]
    public async Task AddNodeAsync_ReturnNodes()
    {
        // Arrange
        var inputCreateNode = new BinaryNode<int>(4);
        var content = JsonContent.Create(inputCreateNode);

        // Act
        var response = await _client.PostAsync($"api/{_path}", content);
        response.EnsureSuccessStatusCode();

        var createNode = await response.Content.ReadFromJsonAsync<BinaryNode<int>>();
        createNode.Should().NotBeNull();
        createNode.Value.Should().NotBe(3);
        createNode.Value.Should().Be(4);
        createNode.Value.Should().NotBe(5);
        createNode.Left.Should().BeNull();
    }

    [Fact(Skip = "to change implementation")]
    public async Task GetByExistedIntNode_ReturnsNodeById()
    {
        // Arrange
        var mockService = new Mock<BinaryNodeService<int>>();
        var nodeValue = _intNodesSource.First().Value;
        var id = Guid.Parse("d3e1f86c-d2c8-4d92-9b7d-30c9409b9e5d");

        var response = await _client.GetAsync($"api/{_path}/d3e1f86c-d2c8-4d92-9b7d-30c9409b9e5d");       
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        var node = JsonConvert.DeserializeObject<BinaryNode<int>>(content);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        //Assert
        node.Should().NotBeNull();
        node.Value.Should().Be(nodeValue);
    }

    [Fact(Skip = "fix implement")]
    public async Task Get_ReturnsNotFound_ForNonExistingNode()
    {
        // Act
        var response = await _client.GetAsync($"api/{_path}/GetNodeAsync/{Guid.NewGuid()}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact(Skip = "for fix after implement")]
    public async Task Get_ReturnsBadRequest_ForInvalidNodeId()
    {
        // Act
        var response = await _client.GetAsync($"api/{_path}/GetNodeAsync/invalid-guid");

        // Assert
        // Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact(Skip = "for fix after implement")]
    public async Task PostPlaceAsync_ReturnNode()
    {
        string guidString = "a3d94468-2f6f-4fc8-1a5e-5d5fcbcb9754";
        Guid parsedGuid = Guid.Parse(guidString);

        // Arrange
        // var newNode = new BinaryTreeResult(parsedGuid, "NewNode", DateTime.UtcNow, "1,2,3");
        var inputCreateNode = new BinaryNode<int>(4);
        var content = JsonContent.Create(inputCreateNode);

        // Act
        var response = await _client.PostAsync($"api/{_path}", content);
        response.EnsureSuccessStatusCode();

        var createNode = await response.Content.ReadFromJsonAsync<BinaryNode<int>>();
        createNode.Should().NotBeNull();
        createNode.Value.Should().NotBe(4);
        createNode.Left.Should().BeNull();
    }

    [Fact(Skip = "to fix an rebuld")]
    public async Task Get_ForExistingNode_ReturnsNodeById()
    {
        // Arrange        
        var nodeValue = _intNodesSource.First().Value;
        var id = Guid.Parse("d3e1f86c-d2c8-4d92-9b7d-30c9409b9e5d");
        // Custom method to seed database with test data
        // SeedDatabaseWithNode(nodeId);

        var response = await _client.GetAsync($"api/{_path}/{id}");
        // Act
        response.EnsureSuccessStatusCode();
        var node = await response.Content.ReadFromJsonAsync<BinaryNode<int>>();

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(node);
        Assert.Equal(nodeValue, node.Value);
        
        node.Should().NotBeNull();
        node.Value.Should().Be(nodeValue);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact(Skip = "to change implementation")]
    public async Task GetByNotExistedIntNode_ReturnsNoFound()
    {
        // Arrange
        var mockService = new Mock<BinaryNodeService<int>>();
        var nodeId = _intNodesSource.First().Value;
        var id = Guid.Parse("1111f86c-d2c8-4d92-9b7d-30c9409b9111");

        //mockService.Setup(service => service.GetAsync(id))
        //        //   .Returns(GetNodeAsync(id))
        //           .Verifiable();

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped(typeof(IBinaryNodeService<int>), provider => mockService.Object);
            });
        }).CreateClient();

        var response = await client.GetAsync($"api/{_path}/{nodeId}");

        // Act
        var node = await response.Content.ReadFromJsonAsync<PositionBinaryNode<int>>();

        //Assert
        node.Should().NotBeNull();
        node.Id.Should().Be(null);
        node.BinaryNode.Should().Be(null);
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
