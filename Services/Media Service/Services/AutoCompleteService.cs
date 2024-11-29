using AutoMapper;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Media_Service.Repositories;

namespace Media_Service.Services
{
    public class AutoCompleteService : IAutoCompleteService
    {
        private readonly IMediaDatabase _mediaDatabase;
        private readonly IMapper _mapper;
        public AutoCompleteService(IMediaDatabase mediaDatabase, IMapper mapper) 
        {
            _mediaDatabase = mediaDatabase;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> GetAutoComplete(string query, SearchType searchType)
        {
            IEnumerable<string> result;

            switch (searchType)
            {
                case SearchType.TITLE:
                    result = (await GetMediaByTitle(query)).Select(x => x.Name);
                    break;

                case SearchType.AUTHOR:
                    result = (await GetAuthors(query)).Select(x => x.FirstName + " " + x.LastName);
                    break;

                default:
                    result = Array.Empty<string>();
                    break;
            }
            
            return result;
        }

        private async Task<IEnumerable<Author>> GetAuthors(string query)
        {
            AuthorNameSpecification authorSpec = new AuthorNameSpecification(query);
            var authors = await _mediaDatabase.GetAuthorsByName(authorSpec);

            return _mapper.Map<IEnumerable<Author>>(authors);
        }

        private async Task<IEnumerable<Media>> GetMediaByTitle(string query)
        {
            MediaTitleSpecification titleSpec = new MediaTitleSpecification(query, false);
            var media = await _mediaDatabase.GetMediaByTitle(titleSpec);

            return _mapper.Map<IEnumerable<Media>>(media);
        }
    }
}
