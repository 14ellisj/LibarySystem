using Media_Service.Models.Specifications;
using Media_Service.Models;

namespace Media_Service.Repositories
{
    public interface IMediaDatabase
    {
        Task<IEnumerable<MediaEntity>> GetMediaByTitle(MediaTitleSpecification filter);
        Task<IEnumerable<AuthorEntity>> GetAuthorsByName(AuthorNameSpecification query);
    }
}
