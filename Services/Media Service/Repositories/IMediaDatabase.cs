using Media_Service.Models.Specifications;
using Media_Service.Models;

namespace Media_Service.Repositories
{
    public interface IMediaDatabase
    {
        Task<IEnumerable<Media>> GetMediaByTitle(string title);
        Task<IEnumerable<Author>> GetAuthorsByName(string author);
        Task<IEnumerable<Media>> FilterMediaAllInfo(MediaFilter filters);
        Task<IEnumerable<MediaItem>> GetMediaItemsByParentId(int mediaId);
        Task<MediaItem> GetMediaItemById(int mediaItemId);
        Task<IEnumerable<MediaItem>> GetMediaItemsByLibraryId(int libraryId);
        Task<IEnumerable<Library>> GetAllLibraryData();
        Task<bool> BorrowItem(int mediaId, int profileId);
        Task<bool> MoveItem(int mediaItemId, int libraryId);
        Task<bool> ReserveItem(int mediaItemId, int profileId);
        Task<bool> ReturnItem(int mediaItemId);
        Task<IEnumerable<Media>> GetBorrowedMedia(int profileId);
        Task<MediaItem?> GetBorrowedMediaItem(int mediaId, int profileId);
    }
}
