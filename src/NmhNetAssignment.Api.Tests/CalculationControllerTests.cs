using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NmhNetAssignment.Application.Requests;
using NmhNetAssignment.Application.Responses;

public class CalculationControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly CalculationController _controller;

    public CalculationControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new CalculationController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Calculate_ValidKey_ReturnsOkResult()
    {
        // Arrange
        var key = 1;
        var request = new CalculationRequest();
        var expectedResult = new CalculationResponse { ComputedValue = 42 }; // Example result
        _mediatorMock.Setup(m => m.Send(It.IsAny<CalculationRequest>(), default))
                      .ReturnsAsync(expectedResult);

        // Act
        var result = await _controller.Calculate(key, request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResult, okResult.Value);
    }

    [Fact]
    public async Task Calculate_InvalidKey_ReturnsBadRequest()
    {
        // Arrange
        var key = -1;
        var request = new CalculationRequest();
        request.Input = -1;

        // Act
        var result = await _controller.Calculate(key, request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(okResult.Value, null);

    }
}
