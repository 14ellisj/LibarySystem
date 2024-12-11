using Media_Service.Models.Specifications;
using Media_Service.Models;

namespace Media_Service.Repositories
{
    public interface IMediaDatabase
    {
        Task<IEnumerable<MediaEntity>> GetMediaByTitle(MediaTitleSpecification spec);
        Task<IEnumerable<AuthorEntity>> GetAuthorsByName(AuthorNameSpecification spec);
        Task<IEnumerable<MediaEntity>> FilterMediaAllInfo(IEnumerable<ISpecification<MediaEntity>> specs);
        Task<bool> BorrowItem(MediaItemEntity mediaId, int profileId);
        Task<bool> ReserveItem(MediaItemEntity mediaId, int profileId);
    }
}
