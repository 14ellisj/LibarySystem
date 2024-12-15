import type { Author } from '@/models/author'
import type { MediaFilter, MediaItem } from '@/models/filters'
import type { Media } from '@/models/media'
import type { Media_Item } from '@/models/media_item'
import type { IAutoCompleteParams, IBorrowRequest, IReserveRequest } from '@/models/requests'
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

  async getMediaItem(filter: MediaItem): Promise<Media_Item[]> {
    const requestUrl = this.apiUrl + 'Media'

    await axios
      .get(requestUrl, {
        params: filter,
      })
      .then((response) => {
        this.mediaStore.setMediaItem(response.data)
      })

    return this.mediaStore.mediaItem
  }

  async borrowMedia(mediaId: number, profileId: number): Promise<boolean> {
    const requestUrl = this.apiUrl + 'Media/Borrow'
    const body: IBorrowRequest = {
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

  async reserveMedia(mediaId: number, profileId: number): Promise<boolean> {
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

  async getAutoComplete(query: string, searchType: SearchType): Promise<string[]> {
    const requestUrl = this.apiUrl + 'AutoComplete'
    const params: IAutoCompleteParams = { query, search_type: searchType }
    console.log(requestUrl)
    await axios
      .get(requestUrl, {
        params,
      })
      .then((response) => {
        console.log(response)
        this.mediaStore.setAutocompleteOptions(response.data as string[])
      })

    return this.mediaStore.autoCompleteOptions
  }
}
