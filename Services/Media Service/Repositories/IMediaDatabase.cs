using Media_Service.Models.Specifications;
using Media_Service.Models;

namespace Media_Service.Repositories
{
    public interface IMediaDatabase
    {
        Task<IEnumerable<Media>> GetMediaByTitle(string title);
        Task<IEnumerable<Author>> GetAuthorsByName(string authorName);
        Task<IEnumerable<Media>> FilterMediaAllInfo(MediaFilter filters);
        Task<bool> BorrowItem(int mediaId, int profileId);
    }
}
