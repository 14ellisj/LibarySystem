using Media_Service.Models;

namespace Media_Service.Services
{
    public interface IReturnService
    {
        Task<bool> ReturnMedia(int mediaId, int profileId);
    }
}