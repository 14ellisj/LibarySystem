import type { SearchType } from './searchType'

export interface MediaFilter {
  title?: string
  author?: string
  is_selected?: boolean
  availability?: boolean
}

export interface ProfileFilter {
  firstname?: string
  lastname?: string
  email?: string
}
