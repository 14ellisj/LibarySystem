using Media_Service.Models.Specifications;
using Media_Service.Models;

namespace Media_Service.Repositories
{
    public interface IMediaDatabase
    {
        Task<IEnumerable<Media>> GetMediaByTitle(string title);
        Task<IEnumerable<Author>> GetAuthorsByName(string author);
        Task<IEnumerable<Media>> FilterMediaAllInfo(MediaFilter filters);
        Task<bool> BorrowItem(int mediaId, int profileId);
        Task<bool> ReturnItem(MediaItem mediaId);
        Task<IEnumerable<Media>> GetBorrowedMedia(int profileId);
        Task<MediaItem?> GetBorrowedMediaItem(int mediaId, int profileId);
    }
}
