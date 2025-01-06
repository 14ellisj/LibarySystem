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
        MediaController _sut;


        [TestInitialize]
        public void Initialize()
        {
            _mediaServiceMock = new Mock<IMediaService>();
            _loggerMock = new Mock<ILogger<MediaController>>();
            _sut = new MediaController(_loggerMock.Object, _mediaServiceMock.Object);
        }

        [TestMethod]
        public async Task BorrowMedia_NoMediaId_BadRequest()
        {
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = null,
                ProfileId = 1
            };

            var result = await _sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task BorrowMedia_NoProfileId_BadRequest()
        {
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = 1,
                ProfileId = null
            };

            var result = await _sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task BorrowMedia_UnsuccessulFromService_ConflictError()
        {
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = 1,
                ProfileId = 1
            };

            _mediaServiceMock.Setup(x => x.BorrowMedia(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(false);

            var result = await _sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
        }

        [TestMethod]
        public async Task BorrowMedia_InternalServerErrorInService_StatusCode500()
        {
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = 1,
                ProfileId = 1
            };

            _mediaServiceMock.Setup(x => x.BorrowMedia(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new Exception());

            var result = await _sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            Assert.AreEqual(500, (result as ObjectResult).StatusCode);
        }

        [TestMethod]
        public async Task BorrowMedia_Success_NoContentResult()
        {
            BorrowItemRequest request = new BorrowItemRequest()
            {
                MediaId = 1,
                ProfileId = 1
            };

            _mediaServiceMock.Setup(x => x.BorrowMedia(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(true);

            var result = await _sut.BorrowMedia(request);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}
