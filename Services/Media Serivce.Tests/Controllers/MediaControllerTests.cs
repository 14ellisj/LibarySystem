using Castle.Core.Logging;
using Media_Service.Controllers;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Serivce.Tests.Controllers
{
    [TestClass]
    public class MediaControllerTests
    {
        Mock<IMediaService> _mediaServiceMock;
        Mock<ILogger<MediaController>> _loggerMock;
        public MediaControllerTests()
        {
            _mediaServiceMock = new Mock<IMediaService>();
            _loggerMock = new Mock<ILogger<MediaController>>();
        }

        [TestMethod]
        public async Task BorrowMedia_NoMediaId_BadRequest()
        {
            MediaController sut = new MediaController(_loggerMock.Object, _mediaServiceMock.Object);
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = null,
                ProfileId = 1
            };

            var result = await sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task BorrowMedia_NoProfileId_BadRequest()
        {
            MediaController sut = new MediaController(_loggerMock.Object, _mediaServiceMock.Object);
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = 1,
                ProfileId = null
            };

            var result = await sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task BorrowMedia_UnsuccessulFromService_ConflictError()
        {
            MediaController sut = new MediaController(_loggerMock.Object, _mediaServiceMock.Object);
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = 1,
                ProfileId = 1
            };

            _mediaServiceMock.Setup(x => x.BorrowMedia(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(false);

            var result = await sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
        }

        [TestMethod]
        public async Task BorrowMedia_InternalServerErrorInService_StatusCode500()
        {
            MediaController sut = new MediaController(_loggerMock.Object, _mediaServiceMock.Object);
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = 1,
                ProfileId = 1
            };

            _mediaServiceMock.Setup(x => x.BorrowMedia(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new Exception());

            var result = await sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            Assert.AreEqual(500, (result as ObjectResult).StatusCode);
        }

        [TestMethod]
        public async Task BorrowMedia_Success_OKResult()
        {
            MediaController sut = new MediaController(_loggerMock.Object, _mediaServiceMock.Object);
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = 1,
                ProfileId = 1
            };

            _mediaServiceMock.Setup(x => x.BorrowMedia(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(true);

            var result = await sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
