using BinaryTrees.Api;
using BinaryTrees.Core.Domain;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
namespace BinaryTrees.Tests.EndToEnd;

public class IntBinaryNodeControllerE2ETests : IClassFixture<WebApplicationFactory<Startup>>
{
    protected readonly HttpClient _client;
    protected string _path;


    public IntBinaryNodeControllerE2ETests(WebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
        _path = "binarynodeint";
    }

    [Fact]
    public async Task GetNodes_ReturnsEmptyList_WhenNoNodesExist()
    {
        var response = await _client.GetAsync($"/api/{_path}");
        response.EnsureSuccessStatusCode();
        var nodes = await response.Content.ReadFromJsonAsync<BinaryNode<int>[]>();
        Assert.Empty(nodes);
    }

    [Fact(Skip = "skip for fix")]
    public async Task AddNode_CreatesNewNode()
    {
        var newNode = new BinaryNode<int>(5);
        var response = await _client.PostAsJsonAsync($"/api/{_path}", newNode);

        response.EnsureSuccessStatusCode();

        var createdNode = await response.Content.ReadFromJsonAsync<BinaryNode<int>>();

        Assert.Equal(5, createdNode.Value);

        var getResponse = await _client.GetAsync($"/api/{_path}");

        getResponse.EnsureSuccessStatusCode();

        var nodes = await getResponse.Content.ReadFromJsonAsync<BinaryNode<int>[]>();

        Assert.Contains(nodes, n => n.Value == 5);
    }

    [Fact(Skip = "skip for fix")]
    public async Task GetNode_ReturnsNode_WhenNodeExists()
    {
        var newNode = new BinaryNode<int>(10);
        await _client.PostAsJsonAsync("/api/BinaryNodeInt", newNode);
        
        var response = await _client.GetAsync($"/api/{_path}/10");

        response.EnsureSuccessStatusCode();

        var node = await response.Content.ReadFromJsonAsync<BinaryNode<int>>();

        Assert.Equal(10, node.Value);
    }

    [Fact(Skip = "_fix with repository test implementation")]
    public async Task GetNode_ReturnsNotFound_WhenNodeDoesNotExist()
    {
        var response = await _client.GetAsync($"/api/{_path}/999");

        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact(Skip = "skip for fix")]
    public async Task DeleteNode_RemovesNode()
    {
        var newNode = new BinaryNode<int>(15);

        await _client.PostAsJsonAsync("/api/BinaryNodeInt", newNode);

        var deleteResponse = await _client.DeleteAsync($"/api/IntBinaryNode/15");

        deleteResponse.EnsureSuccessStatusCode();

        var getResponse = await _client.GetAsync("/api/IntBinaryNode");

        getResponse.EnsureSuccessStatusCode();

        var nodes = await getResponse.Content.ReadFromJsonAsync<BinaryNode<int>[]>();
        
        Assert.DoesNotContain(nodes, n => n.Value == 15);
    }
}


