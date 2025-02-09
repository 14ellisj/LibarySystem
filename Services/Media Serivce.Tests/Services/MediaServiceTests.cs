﻿using AutoMapper;
using Castle.Core.Logging;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Media_Service.Repositories;
using Media_Service.Services;
using Microsoft.Extensions.Logging;
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
        Mock<ILogger<MediaService>> _loggerMock;
        MediaService _sut;



        [TestInitialize]
        public void Initialize()
        {
            _mediaDatabaseMock = new Mock<IMediaDatabase>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<MediaService>>();
            _sut = new MediaService(_mediaDatabaseMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [TestMethod]
        public async Task BorrowMedia_MediaNotFound_false()
        {

            var mediaId = 1;
            var profileId = 1;

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<MediaFilter>()))
                .ReturnsAsync(new List<Media>());

            var result = await _sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task BorrowMedia_UserAlreadyBorrowingMedia_false()
        {
            var mediaId = 1;
            var profileId = 1;

            Media mediaResult = new Media()
            {
                IsBorrwedByUser = true,
                IsAvailable = true
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<MediaFilter>()))
                .ReturnsAsync(new List<Media>() { mediaResult });

            var result = await _sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task BorrowMedia_NoAvailableItems_false()
        {
            var mediaId = 1;
            var profileId = 1;

            var borrowerId = 2;

            Media mediaResult = new Media()
            {
                IsAvailable = false
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<MediaFilter>()))
                .ReturnsAsync(new List<Media>() { mediaResult });

            var result = await _sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task BorrowMedia_FailsAtDatabase_false()
        {
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

            var result = await _sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        public async Task BorrowMedia_BorrowSuccessful_true()
        {
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

            var result = await _sut.BorrowMedia(mediaId, profileId);

            Assert.IsTrue(result);
        }
    }
}
