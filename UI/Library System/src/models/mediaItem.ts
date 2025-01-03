import type { Library } from './library'
import type { Media } from './media'
import type { Profile } from './profile'

export interface MediaItem {
  id: number
  media: Media
  borrower?: Profile
  library: Library
}
