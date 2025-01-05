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

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<IEnumerable<ISpecification<MediaEntity>>>()))
                .ReturnsAsync(new List<MediaEntity>());

            var result = await sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task BorrowMedia_UserAlreadyBorrowingMedia_false()
        {
            var sut = new MediaService(_mediaDatabaseMock.Object, _mapperMock.Object);

            var mediaId = 1;
            var profileId = 1;

            MediaEntity mediaResult = new MediaEntity()
            {
                media_items = new List<MediaItemEntity>()
                {
                    new MediaItemEntity()
                    {
                        borrower_id = profileId,
                        borrower = new UserEntity()
                        {
                            id = profileId
                        }
                    }
                }
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<ISpecification<MediaEntity>[]>()))
                .ReturnsAsync(new List<MediaEntity>());

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

            MediaEntity mediaResult = new MediaEntity()
            {
                media_items = new List<MediaItemEntity>()
                {
                    new MediaItemEntity()
                    {
                        borrower_id = borrowerId,
                        borrower = new UserEntity()
                        {
                            id = borrowerId
                        }
                    }
                }
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<IEnumerable<ISpecification<MediaEntity>>>()))
                .ReturnsAsync(new List<MediaEntity>());

            var result = await sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task BorrowMedia_FailsAtDatabase_false()
        {
            var sut = new MediaService(_mediaDatabaseMock.Object, _mapperMock.Object);

            var mediaId = 1;
            var profileId = 1;

            var borrowerId = 2;

            MediaEntity mediaResult = new MediaEntity()
            {
                media_items = new List<MediaItemEntity>()
                {
                    new MediaItemEntity()
                    {
                        borrower_id = borrowerId,
                        borrower = new UserEntity()
                        {
                            id = borrowerId
                        }
                    }
                }
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<IEnumerable<ISpecification<MediaEntity>>>()))
                .ReturnsAsync(new List<MediaEntity>());

            _mediaDatabaseMock.Setup(x => x.BorrowItem(It.IsAny<MediaItemEntity>(), It.IsAny<int>()))
                .ReturnsAsync(false);

            var result = await sut.BorrowMedia(mediaId, profileId);

            Assert.IsFalse(result);
        }

        public async Task BorrowMedia_BorrowSuccessful_true()
        {
            var sut = new MediaService(_mediaDatabaseMock.Object, _mapperMock.Object);

            var mediaId = 1;
            var profileId = 1;

            var borrowerId = 2;

            MediaEntity mediaResult = new MediaEntity()
            {
                media_items = new List<MediaItemEntity>()
                {
                    new MediaItemEntity()
                    {
                        borrower_id = borrowerId,
                        borrower = new UserEntity()
                        {
                            id = borrowerId
                        }
                    }
                }
            };

            _mediaDatabaseMock.Setup(x => x.FilterMediaAllInfo(It.IsAny<IEnumerable<ISpecification<MediaEntity>>>()))
                .ReturnsAsync(new List<MediaEntity>());

            _mediaDatabaseMock.Setup(x => x.BorrowItem(It.IsAny<MediaItemEntity>(), It.IsAny<int>()))
                .ReturnsAsync(true);

            var result = await sut.BorrowMedia(mediaId, profileId);

            Assert.IsTrue(result);
        }
    }
}
