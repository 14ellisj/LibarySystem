using Media_Service.Models;

namespace Media_Service.Services
{
    public interface IAutoCompleteService
    {
        Task<IEnumerable<string>> GetAutoComplete(string query, SearchType searchType);
    }
}
