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
        }

        public async Task<IEnumerable<string>> GetAutoComplete(string query, SearchType searchType)
        {
            IEnumerable<string> result;

            switch (searchType)
            {
                case SearchType.TITLE:
                    result = (await _mediaDatabase.GetMediaByTitle(query))
                        .Select(x => x.Name);
                    break;

                case SearchType.AUTHOR:
                    result = (await _mediaDatabase.GetAuthorsByName(query))
                        .Select(x => x.FirstName + " " + x.LastName);
                    break;

                default:
                    result = Array.Empty<string>();
                    break;
            }
            
            return result;
        }
    }
}
