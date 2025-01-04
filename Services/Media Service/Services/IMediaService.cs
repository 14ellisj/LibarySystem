using Media_Service.Models;

namespace Media_Service.Services
{
    public interface IMediaService
    {
        Task<IEnumerable<Media>> FilterMedia(string? title, string? author, bool? isSelected, bool? isAvailable, int? profileId);
        Task<IEnumerable<MediaItem>> GetMediaItems(int mediaId, int? libraryId, int? borrowerId, int? reserverId);
        Task<IEnumerable<MediaItem>> GetLibraryMediaItems( int libraryId, int? mediaId);
        Task<IEnumerable<Library>> GetLibraryData(int? libraryId, string? libraryname);
        Task<bool> BorrowMedia(int mediaId, int profileId);
        Task<bool> MoveMedia(int mediaId, int libraryId);
        Task<bool> ReserveMedia(int mediaId, int profileId);
        Task <Media> GetMedia(int mediaId, int? profileId);

    }
}