using Media_Service.Models;

namespace Media_Service.Services
{
    public interface IMediaService
    {
        Task<IEnumerable<Media>> FilterMedia(string? title, string? author, bool? isSelected, bool? isAvailable);
    }
}
