export interface MediaFilter {
  title?: string
  author?: string
  is_selected?: boolean
  availability?: boolean
  profile_id?: number
  library_id?: number
}

export interface ProfileFilter {
  firstname?: string
  lastname?: string
  email?: string
}

export interface MediaItemsFilter{
  media_id?: number
  borrower_id?: number
  library_id?: number
  reserver_id?: number
  reserve_queue?: number
  profile_id?: number
}

export interface LibraryFilter {
  library_id?: number
  name?: string
}

export interface libraryMediaItemsFilter{
  library_id?: number
}

