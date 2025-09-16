using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Million.Api.Controllers;
using Million.Domain.Entities;
using Million.Infrastructure.Database;
using Moq;

namespace Million.Tests.Controllers;

[TestFixture]
public class PropertiesControllerTests
{
    private Mock<IMongoDbContext> _mockMongoDbContext;
    private PropertiesController _controller;

    [SetUp]
    public void Setup()
    {
        _mockMongoDbContext = new Mock<IMongoDbContext>();
        _controller = new PropertiesController(_mockMongoDbContext.Object);
    }

    [Test]
    public void PropertiesController_Constructor_WithValidContext_ShouldCreateInstance()
    {
        // Act
        var controller = new PropertiesController(_mockMongoDbContext.Object);

        // Assert
        controller.Should().NotBeNull();
    }

    [Test]
    public void PropertiesController_ShouldBeControllerBase()
    {
        // Assert
        _controller.Should().BeAssignableTo<ControllerBase>();
    }

    [Test]
    public void PropertiesController_ShouldHaveApiControllerAttribute()
    {
        // Act
        var attributes = _controller.GetType().GetCustomAttributes(typeof(ApiControllerAttribute), true);

        // Assert
        attributes.Should().HaveCount(1);
        attributes.First().Should().BeOfType<ApiControllerAttribute>();
    }

    [Test]
    public void PropertiesController_ShouldHaveRouteAttribute()
    {
        // Act
        var attributes = _controller.GetType().GetCustomAttributes(typeof(RouteAttribute), true);

        // Assert
        attributes.Should().HaveCount(1);
        var routeAttribute = attributes.First() as RouteAttribute;
        routeAttribute!.Template.Should().Be("api/[controller]");
    }

    [Test]
    public void PropertiesController_ShouldHaveProducesAttribute()
    {
        // Act
        var attributes = _controller.GetType().GetCustomAttributes(typeof(ProducesAttribute), true);

        // Assert
        attributes.Should().HaveCount(1);
        var producesAttribute = attributes.First() as ProducesAttribute;
        producesAttribute!.ContentTypes.Should().Contain("application/json");
    }

    [Test]
    public void GetProperties_Method_ShouldExist()
    {
        // Act
        var method = _controller.GetType().GetMethod("GetProperties", new[] { typeof(string), typeof(string), typeof(decimal?), typeof(decimal?) });

        // Assert
        method.Should().NotBeNull();
        method!.ReturnType.Should().Be(typeof(Task<IActionResult>));
    }

    [Test]
    public void GetProperty_Method_ShouldExist()
    {
        // Act
        var method = _controller.GetType().GetMethod("GetProperty", new[] { typeof(string) });

        // Assert
        method.Should().NotBeNull();
        method!.ReturnType.Should().Be(typeof(Task<IActionResult>));
    }

    [Test]
    public void GetProperties_Method_ShouldHaveHttpGetAttribute()
    {
        // Act
        var method = _controller.GetType().GetMethod("GetProperties", new[] { typeof(string), typeof(string), typeof(decimal?), typeof(decimal?) });
        var attributes = method!.GetCustomAttributes(typeof(HttpGetAttribute), true);

        // Assert
        attributes.Should().HaveCount(1);
        attributes.First().Should().BeOfType<HttpGetAttribute>();
    }

    [Test]
    public void GetProperty_Method_ShouldHaveHttpGetAttribute()
    {
        // Act
        var method = _controller.GetType().GetMethod("GetProperty", new[] { typeof(string) });
        var attributes = method!.GetCustomAttributes(typeof(HttpGetAttribute), true);

        // Assert
        attributes.Should().HaveCount(1);
        var httpGetAttribute = attributes.First() as HttpGetAttribute;
        httpGetAttribute!.Template.Should().Be("{id}");
    }

    [Test]
    public void GetProperties_Method_ShouldHaveProducesResponseTypeAttributes()
    {
        // Act
        var method = _controller.GetType().GetMethod("GetProperties", new[] { typeof(string), typeof(string), typeof(decimal?), typeof(decimal?) });
        var attributes = method!.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true);

        // Assert
        attributes.Should().NotBeEmpty();
    }

    [Test]
    public void GetProperty_Method_ShouldHaveProducesResponseTypeAttributes()
    {
        // Act
        var method = _controller.GetType().GetMethod("GetProperty", new[] { typeof(string) });
        var attributes = method!.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true);

        // Assert
        attributes.Should().NotBeEmpty();
    }

    [Test]
    public void CreateProperty_Method_ShouldExist()
    {
        // Act
        var method = _controller.GetType().GetMethod("CreateProperty", new[] { typeof(Million.Application.DTOs.CreatePropertyDto) });

        // Assert
        method.Should().NotBeNull();
        method!.ReturnType.Should().Be(typeof(Task<IActionResult>));
    }

    [Test]
    public void CreateProperty_Method_ShouldHaveHttpPostAttribute()
    {
        // Act
        var method = _controller.GetType().GetMethod("CreateProperty", new[] { typeof(Million.Application.DTOs.CreatePropertyDto) });
        var attributes = method!.GetCustomAttributes(typeof(HttpPostAttribute), true);

        // Assert
        attributes.Should().HaveCount(1);
        attributes.First().Should().BeOfType<HttpPostAttribute>();
    }

    [Test]
    public void CreateProperty_Method_ShouldHaveProducesResponseTypeAttributes()
    {
        // Act
        var method = _controller.GetType().GetMethod("CreateProperty", new[] { typeof(Million.Application.DTOs.CreatePropertyDto) });
        var attributes = method!.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), true);

        // Assert
        attributes.Should().NotBeEmpty();
    }

    [Test]
    public void CreateProperty_Method_ShouldHaveFromBodyAttribute()
    {
        // Act
        var method = _controller.GetType().GetMethod("CreateProperty", new[] { typeof(Million.Application.DTOs.CreatePropertyDto) });
        var parameters = method!.GetParameters();
        var parameter = parameters.FirstOrDefault(p => p.Name == "dto");

        // Assert
        parameter.Should().NotBeNull();
        var fromBodyAttributes = parameter!.GetCustomAttributes(typeof(FromBodyAttribute), true);
        fromBodyAttributes.Should().HaveCount(1);
        fromBodyAttributes.First().Should().BeOfType<FromBodyAttribute>();
    }

    [Test]
    public void Controller_ShouldHaveCorrectNamespace()
    {
        // Assert
        _controller.GetType().Namespace.Should().Be("Million.Api.Controllers");
    }

    [Test]
    public void Controller_ShouldHaveCorrectName()
    {
        // Assert
        _controller.GetType().Name.Should().Be("PropertiesController");
    }
}