using Media_Service.Models.Specifications;
using Media_Service.Models;

namespace Media_Service.Repositories
{
    public interface IMediaDatabase
    {
        Task<IEnumerable<MediaEntity>> GetMediaByTitle(MediaTitleSpecification spec);
        Task<IEnumerable<AuthorEntity>> GetAuthorsByName(AuthorNameSpecification spec);
        Task<IEnumerable<MediaEntity>> FilterMediaAllInfo(IEnumerable<ISpecification<MediaEntity>> specs);
        Task<IEnumerable<MediaItemEntity>> GetMediaItemsById(MediaItemIdSpecification spec);
         Task<IEnumerable<MediaItemEntity>> GetMediaItemsByLibraryId(LibraryMediaItemIdSpecification spec);
        Task<IEnumerable<LibraryEntity>> GetAllLibraryData();
        Task<bool> BorrowItem(MediaItemEntity mediaId, int profileId);
        Task<bool> MoveItem(MediaItemEntity mediaId, int libraryId);
        Task<bool> ReserveItem(MediaItemEntity mediaId, int profileId);
    }
}
