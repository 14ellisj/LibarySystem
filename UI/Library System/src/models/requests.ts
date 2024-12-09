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
