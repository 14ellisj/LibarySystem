import type { Media_Item } from './media_item'
import type { SearchType } from './searchType'

export interface IAutoCompleteParams {
  query: string
  search_type: SearchType
}

export interface IBorrowRequest {
  media_id: number
  profile_id: number
}

export interface IReserveRequest {
  media_id: number
  profile_id: number
}

export interface IGetItemsRequest {
  media_id: number
  media_item: Media_Item
}
