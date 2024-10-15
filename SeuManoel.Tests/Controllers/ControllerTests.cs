using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SeuManoel.Application.Embalar.Commands;
using SeuManoel.Application.Embalar.Dtos;
using SeuManoel.Web.API.Controllers;
using Xunit;

namespace SeuManoel.Tests.Controllers
{
    public class SeuManoelControllerTests
    {
        private readonly Mock<ILogger<SeuManoelController>> _loggerMock;
        private readonly Mock<ISender> _senderMock;
        private readonly SeuManoelController _controller;

        public SeuManoelControllerTests()
        {
            _loggerMock = new Mock<ILogger<SeuManoelController>>();
            _senderMock = new Mock<ISender>();
            _controller = new SeuManoelController(_senderMock.Object);
        }

        [Fact]
        public async Task EmbalarAsync_ReturnsOkResult_WithEmbaladosDto()
        {
            var command = new EmbalarCommand();
            var expectedDto = new EmbaladosDto();
            _senderMock.Setup(s => s.Send(It.IsAny<EmbalarCommand>(), default))
                       .ReturnsAsync(expectedDto);

            var result = await _controller.EmbalarAsync(command);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<EmbaladosDto>(okResult.Value);
            Assert.Equal(expectedDto, returnValue);
        }

        [Fact]
        public async Task EmbalarAsync_CallsSendMethodOnce()
        {
            var command = new EmbalarCommand();
            _senderMock.Setup(s => s.Send(It.IsAny<EmbalarCommand>(), default))
                       .ReturnsAsync(new EmbaladosDto());

            await _controller.EmbalarAsync(command);

            _senderMock.Verify(s => s.Send(It.IsAny<EmbalarCommand>(), default), Times.Once);
        }
    }
}