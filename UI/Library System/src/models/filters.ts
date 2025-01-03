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
  
export interface mediaItemsFilter{
    media_id?: number
    borrower_id?: number
    library_id?: number
    profile_id? : number
  }
