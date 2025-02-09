using System.Linq.Expressions;

namespace Media_Service.Models.Specifications
{
    public class MediaItemParentIdSpecification : ISpecification<MediaItemEntity>
    {
        int? _id;

        public MediaItemParentIdSpecification(int? id)
        {
            _id = id;
        }

        public Expression<Func<MediaItemEntity, bool>> Criteria
        {
            get
            {
                if (!_id.HasValue)
                    return _ => true;

                return x => x.media.id == _id;
            }
        }
    }

    public class MediaItemByIdSpecification : ISpecification<MediaItemEntity>
    {
        int? _id;

        public MediaItemByIdSpecification(int? id)
        {
            _id = id;
        }

        public Expression<Func<MediaItemEntity, bool>> Criteria
        {
            get
            {
                if (!_id.HasValue)
                    return _ => false;

                return x => x.id.Equals(_id);
            }
        }
    }

    public class MediaItemBorrowStatusSpecification : ISpecification<MediaItemEntity>
    {
        bool? _isBorrowed;

        public MediaItemBorrowStatusSpecification(bool? isBorrowed)
        {
            _isBorrowed = isBorrowed;
        }

        public Expression<Func<MediaItemEntity, bool>> Criteria
        {
            get
            {
                if (!_isBorrowed.HasValue)
                    return _ => true;


                if ((bool)_isBorrowed)
                    return x => x.borrower_id != null;

                return x => x.borrower_id == null;
            }
        }
    }

    public class MediaItemBorrowedBySpecification : ISpecification<MediaItemEntity>
    {
        int? _profileId;

        public MediaItemBorrowedBySpecification(int? profileId)
        {
            _profileId = profileId;
        }

        public Expression<Func<MediaItemEntity, bool>> Criteria
        {
            get
            {
                if (!_profileId.HasValue)
                    return _ => true;

                return x => x.borrower_id == _profileId;
            }
        }
    }

    public class MediaItemByLibraryIdSpecification : ISpecification<MediaItemEntity>
    {
        int? _libraryId;

        public MediaItemByLibraryIdSpecification(int? libraryId)
        {
            _libraryId = libraryId;   
        }

        public Expression<Func<MediaItemEntity, bool>> Criteria
        {
            get
            {
                if (!_libraryId.HasValue)
                    return _ => true;

                return x => x.library_id == _libraryId;
            }
        }
    }
}