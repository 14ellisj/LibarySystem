using Wishlist_Service.Models.Specifications;
using Wishlist_Service.Models;

namespace Wishlist_Service.Repositories
{
    public interface IMediaDatabase
    {
        Task<IEnumerable<WishlistEntity>> GetWishlistByTitle(WishlistTitleSpecification spec);
        Task<IEnumerable<AuthorEntity>> GetAuthorsByName(AuthorNameSpecification spec);
    }
}
