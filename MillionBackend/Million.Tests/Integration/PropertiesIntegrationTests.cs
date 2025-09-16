using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Million.Api;
using Million.Infrastructure.Database;
using MongoDB.Driver;
using System.Net;
using System.Text.Json;

namespace Million.Tests.Integration;

[TestFixture]
public class PropertiesIntegrationTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client?.Dispose();
        _factory?.Dispose();
    }

    [Test]
    public async Task GetProperties_Endpoint_ShouldReturnOkResponse()
    {
        // Act
        var response = await _client.GetAsync("/api/Properties");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
    }

    [Test]
    public async Task GetProperties_WithQueryParameters_ShouldReturnOkResponse()
    {
        // Act
        var response = await _client.GetAsync("/api/Properties?name=Casa&minPrice=100000&maxPrice=500000");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task GetProperties_WithInvalidQueryParameters_ShouldReturnBadRequestResponse()
    {
        // Act
        var response = await _client.GetAsync("/api/Properties?minPrice=invalid&maxPrice=invalid");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task GetProperty_WithValidId_ShouldReturnNotFoundWhenNoData()
    {
        // Act
        var response = await _client.GetAsync("/api/Properties/507f1f77bcf86cd799439011");

        // Assert
        // Como no hay datos en la base de datos de test, debería retornar NotFound
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Test]
    public async Task GetProperty_WithInvalidId_ShouldReturnInternalServerError()
    {
        // Act
        var response = await _client.GetAsync("/api/Properties/invalid-id");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }

    [Test]
    public async Task GetProperties_Response_ShouldBeValidJson()
    {
        // Act
        var response = await _client.GetAsync("/api/Properties");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        // Verificar que el contenido es JSON válido
        Action parseJson = () => JsonSerializer.Deserialize<object>(content);
        parseJson.Should().NotThrow();
    }

    [Test]
    public async Task GetProperties_Response_ShouldHaveCorrectContentType()
    {
        // Act
        var response = await _client.GetAsync("/api/Properties");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
        response.Content.Headers.ContentType?.CharSet.Should().NotBeNullOrEmpty();
    }

    [Test]
    public async Task GetProperties_WithEmptyQuery_ShouldReturnOkResponse()
    {
        // Act
        var response = await _client.GetAsync("/api/Properties?");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task GetProperties_WithSpecialCharacters_ShouldReturnOkResponse()
    {
        // Act
        var response = await _client.GetAsync("/api/Properties?name=Casa%20con%20acentos&address=Centro%20Ciudad");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task GetProperties_WithVeryLongQuery_ShouldReturnOkResponse()
    {
        // Arrange
        var longQuery = new string('A', 1000);
        var encodedQuery = Uri.EscapeDataString(longQuery);

        // Act
        var response = await _client.GetAsync($"/api/Properties?name={encodedQuery}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
