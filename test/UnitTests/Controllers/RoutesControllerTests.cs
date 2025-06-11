namespace UnitTests.Controllers;

using INDT.TravelRoute.Api.Controllers;
using INDT.TravelRoute.Application.Interfaces.UseCases;
using INDT.TravelRoute.Application.Models;
using INDT.TravelRoute.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Text.Json;

[TestFixture]
public class RoutesControllerTests
{
    private Mock<ICreateRouteUseCase> _createMock;
    private Mock<IDeleteRouteUseCase> _deleteMock;
    private Mock<IGetAllRoutesUseCase> _getAllMock;
    private Mock<IGetRouteByIdUseCase> _getByIdMock;
    private Mock<IUpdateRouteUseCase> _updateMock;
    private Mock<IGetBestTravelRouteUseCase> _bestRouteMock;
    private RoutesController _controller;

    [SetUp]
    public void SetUp()
    {
        _createMock = new Mock<ICreateRouteUseCase>();
        _deleteMock = new Mock<IDeleteRouteUseCase>();
        _getAllMock = new Mock<IGetAllRoutesUseCase>();
        _getByIdMock = new Mock<IGetRouteByIdUseCase>();
        _updateMock = new Mock<IUpdateRouteUseCase>();
        _bestRouteMock = new Mock<IGetBestTravelRouteUseCase>();

        _controller = new RoutesController(
            _createMock.Object,
            _deleteMock.Object,
            _getAllMock.Object,
            _getByIdMock.Object,
            _updateMock.Object,
            _bestRouteMock.Object
        );
    }

    [Test]
    public async Task Post_ShouldReturnCreatedResult()
    {
        var dto = new RouteInputDto { From = "A", To = "B", Value = 10 };

        _createMock
            .Setup(x => x.ExecuteAsync(It.IsAny<Routes>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Routes { Id = Guid.NewGuid(), From = "A", To = "B", Value = 10 });

        var result = await _controller.Post(dto);

        Assert.IsInstanceOf<CreatedAtActionResult>(result);
    }

    [Test]
    public async Task GetAll_ShouldReturnOkWithRoutes()
    {
        _getAllMock.Setup(x => x.ExecuteAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new List<Routes>());

        var result = await _controller.Get();

        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task GetById_ShouldReturnOkWithRoute()
    {
        var id = Guid.NewGuid();
        var route = new Routes { Id = id, From = "A", To = "B", Value = 10 };
        
        _getByIdMock.Setup(x => x.ExecuteAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(route);

        var result = await _controller.Get();

        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task Put_ShouldReturnOk()
    {
        var id = Guid.NewGuid();
        var dto = new RouteInputDto { From = "A", To = "C", Value = 15 };

        _updateMock
            .Setup(x => x.ExecuteAsync(It.IsAny<Routes>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Routes { Id = id, From = "A", To = "C", Value = 15 });

        var result = await _controller.Put(It.IsAny<Guid>(), dto);

        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task Delete_ShouldReturnNoContent()
    {
        var id = Guid.NewGuid();

        _getByIdMock
            .Setup(x => x.ExecuteAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Routes { Id = id, From = "A", To = "B", Value = 10 });

        _deleteMock.Setup(x => x.ExecuteAsync(id, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        var result = await _controller.Delete(id);

        Assert.IsInstanceOf<NoContentResult>(result);
    }

    [Test]
    public async Task GetBestRoute_ShouldReturnOkWithFormattedRoute()
    {
        var response = new CheapestTravelRouteResponse(
            new List<string> { "A", "B", "C" },
            100m
        );

        _bestRouteMock
            .Setup(x => x.ExecuteAsync("A", "C", It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        var result = await _controller.Get("A", "C");

        Assert.IsInstanceOf<OkObjectResult>(result);

        var okResult = result as OkObjectResult;

        // Serializa e desserializa como JsonElement
        var json = JsonSerializer.Serialize(okResult!.Value);
        var jsonDoc = JsonDocument.Parse(json);
        var root = jsonDoc.RootElement;

        Assert.That(root.GetProperty("rota").GetString(), Is.EqualTo("A - B - C"));
        Assert.That(root.GetProperty("custo").GetDecimal(), Is.EqualTo(100m));
    }

    [Test]
    public async Task GetBestRoute_ShouldReturnNotFound_WhenNoRouteExists()
    {
        _bestRouteMock
            .Setup(x => x.ExecuteAsync("A", "Z", It.IsAny<CancellationToken>()))
            .ReturnsAsync((CheapestTravelRouteResponse?)null);

        var result = await _controller.Get("A", "Z");

        Assert.IsInstanceOf<NotFoundObjectResult>(result);

        var notFound = result as NotFoundObjectResult;
        Assert.That(notFound!.Value, Is.EqualTo("Rota não encontrada."));
    }
}
