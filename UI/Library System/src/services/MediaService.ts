import type { MediaFilter, mediaItemsFilter as MediaItemsFilter, LibraryFilter, libraryMediaItemsFilter} from '@/models/filters'
import type { Media } from '@/models/media'
import type { MediaItem } from '@/models/mediaItem'
import type { Library } from '@/models/library'
import type { IAutoCompleteParams, IBorrowRequest, IReserveRequest, IMoveRequest} from '@/models/requests'
import type { Author } from '@/models/author'
import type { IReturnRequest } from '@/models/return'
import type { SearchType } from '@/models/searchType'
import { useMediaStore } from '@/stores/media'
import axios from 'axios'

export default class {
  mediaStore = useMediaStore()

  apiUrl = 'http://localhost:5132/'

  async filterData(filter: MediaFilter): Promise<Media[]> {
    const requestUrl = this.apiUrl + 'Media'

    await axios
      .get(requestUrl, {
        params: filter,
      })
      .then((response) => {
        this.mediaStore.setMedia(response.data)
      })

    return this.mediaStore.media
  }

  async getMediaItems(filter: MediaItemsFilter): Promise<MediaItem[]> {
    const requestUrl = this.apiUrl + 'Media/item'

    await axios
      .get(requestUrl, {
        params: filter,
      })
      .then((response) => {
        this.mediaStore.setMediaItem(response.data)
      })

    return this.mediaStore.mediaItems
  }

  async getLibraryMediaItems(filter: libraryMediaItemsFilter): Promise<MediaItem[]> {
    const requestUrl = this.apiUrl + 'Media/libraryItems'

    await axios
      .get(requestUrl, {
        params: filter,
      })
      .then((response) => {
        this.mediaStore.setLibraryMediaItem(response.data)
      })

    return this.mediaStore.libraryItems
  }


  async getLibraryData(filter: LibraryFilter): Promise<Library[]> {
    const requestUrl = this.apiUrl + 'Media/library'

    await axios
      .get(requestUrl, {
        params: filter,
      })
      .then((response) => {
        this.mediaStore.setLibraryData(response.data)
      })

    return this.mediaStore.library
  }

    async borrowMedia(mediaId: number, profileId: number): Promise<boolean> {
        const requestUrl = this.apiUrl + 'Media/Borrow';
        const body : IBorrowRequest = {
            media_id: mediaId,
            profile_id: profileId
        }

        let success = false

    await axios.patch(requestUrl, body).then(
      () => {
        success = true
        this.mediaStore.borrowMediaItem(mediaId)
      },
      (error) => {
        console.log(error)
        this.mediaStore.markUnavailable(mediaId)
        success = false
      },
    )

    return success
  }

  async moveMedia(mediaId: number, branchDestinationId: number): Promise<boolean> {
    const requestUrl = this.apiUrl + 'Media/move'
    const body: IMoveRequest = {
      media_id: mediaId,
      library_id: branchDestinationId,
    }

    let success = false

    await axios.patch(requestUrl, body).then(
      (response) => {
        success = true
        this.mediaStore.updateMediaItem(response.data)
      },
      (error) => {
        console.log(error)
        success = false
      },
    )

    return success
  }

  async reserveMedia(mediaId: number, profileId: number = 1): Promise<boolean> {
    const requestUrl = this.apiUrl + 'Media/Reserve'
    const body: IReserveRequest = {
      media_id: mediaId,
      profile_id: profileId,
    }

    let success = false

    await axios.patch(requestUrl, body).then(
      (response) => {
        success = true
        this.mediaStore.updateMediaItem(response.data)
      },
      (error) => {
        console.log(error)
        success = false
      },
    )

    return success
  }

    async returnMedia(mediaId: number, profileId: number): Promise<boolean> {
        const requestUrl = this.apiUrl + 'Media/Return';
        const body : IReturnRequest = {
            media_id: mediaId,
            profile_id: profileId
        }

        let success = false;

        await axios
            .patch(requestUrl, body)
            .then(
                (response) => {success = true},
                (error) => {console.log(error); success = false}
            )

        return success;
    }

    async getAutoComplete(query: string, searchType: SearchType) : Promise<string[]> {
        const requestUrl = this.apiUrl + 'AutoComplete';
        const params : IAutoCompleteParams = { query, search_type: searchType }
        console.log(requestUrl)
        await axios
            .get(requestUrl, {
                params
            })
            .then((response) => {
                console.log(response);
                this.mediaStore.setAutocompleteOptions((response.data as string[]));
            })

        return this.mediaStore.autoCompleteOptions;
    }

}
