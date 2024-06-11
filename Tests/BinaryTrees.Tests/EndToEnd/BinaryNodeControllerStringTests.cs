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

public class BinaryNodeControllerStringTests:
IClassFixture<WebApplicationFactory<Startup>>
{
    protected readonly HttpClient _client;
    protected readonly string _path;

    public BinaryNodeControllerStringTests(WebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();

        _path = "binarynodestr";
    }

    [Fact]
    public async Task AddNodeAsync_AddsStringNode_ReturnsCreated()
    {
        // Arrange
        var newNode = new BinaryNode<string> { Value = "TestValue" };

        // Act
        var response =
        await _client.PostAsJsonAsync($"api/{_path}", newNode);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var returnedNode = await

        response.Content.ReadFromJsonAsync<BinaryNode<string>>();
        returnedNode.Should().NotBeNull();
        returnedNode.Value.Should().Be(newNode.Value);
    }
}