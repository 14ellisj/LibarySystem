using Media_Service.Models;

namespace Media_Service.Services
{
    public interface IMediaService
    {
        Task<IEnumerable<Media>> FilterMedia(string? title, string? author, bool? isSelected, bool? isAvailable, int? profileId);
        Task<bool> BorrowMedia(int mediaId, int profileId);
        Task <Media> GetMedia(int mediaId, int? profileId);

    }
}
