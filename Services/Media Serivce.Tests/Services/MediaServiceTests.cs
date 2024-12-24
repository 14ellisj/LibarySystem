using AutoMapper;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Media_Service.Repositories;
using Media_Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Serivce.Tests.Services
{
    [TestClass]
    public class MediaServiceTests
    {
        Mock<IMediaDatabase> _mediaDatabaseMock;
        Mock<IMapper> _mapperMock;

        public MediaServiceTests()
        {
            _mediaDatabaseMock = new Mock<IMediaDatabase>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public async Task BorrowMedia_MediaNotFound_false()
        {
            var sut = new MediaService(_mediaDatabaseMock.Object, _mapperMock.Object);

            var mediaId = 1;
            var profileId = 1;

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<MediaFilter>()))
                .ReturnsAsync(new List<Media>());

            var result = await sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task BorrowMedia_UserAlreadyBorrowingMedia_false()
        {
            var sut = new MediaService(_mediaDatabaseMock.Object, _mapperMock.Object);

            var mediaId = 1;
            var profileId = 1;

            Media mediaResult = new Media()
            {
                IsBorrwedByUser = true,
                IsAvailable = true
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<MediaFilter>()))
                .ReturnsAsync(new List<Media>() { mediaResult });

            var result = await sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task BorrowMedia_NoAvailableItems_false()
        {
            var sut = new MediaService(_mediaDatabaseMock.Object, _mapperMock.Object);

            var mediaId = 1;
            var profileId = 1;

            var borrowerId = 2;

            Media mediaResult = new Media()
            {
                IsAvailable = false
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<MediaFilter>()))
                .ReturnsAsync(new List<Media>() { mediaResult });

            var result = await sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task BorrowMedia_FailsAtDatabase_false()
        {
            var sut = new MediaService(_mediaDatabaseMock.Object, _mapperMock.Object);

            var mediaId = 1;
            var profileId = 1;

            Media mediaResult = new Media()
            {
                IsAvailable = true
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<MediaFilter>()))
                .ReturnsAsync(new List<Media>() { mediaResult });

            _mediaDatabaseMock.Setup(x => x.BorrowItem(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(false);

            var result = await sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        public async Task BorrowMedia_BorrowSuccessful_true()
        {
            var sut = new MediaService(_mediaDatabaseMock.Object, _mapperMock.Object);

            var mediaId = 1;
            var profileId = 1;

            Media mediaResult = new Media()
            {
                IsAvailable = true,
                IsBorrwedByUser = false
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<MediaFilter>()))
                .ReturnsAsync(new List<Media>() { mediaResult });

            _mediaDatabaseMock.Setup(x => x.BorrowItem(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(true);

            var result = await sut.BorrowMedia(mediaId, profileId);

            Assert.IsTrue(result);
        }
    }
}
