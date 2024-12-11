import type { Media } from './media'
import type { Profile } from './profile'

export interface Wishlist {
  id: number
  media_id: Media
  profile_id: Profile
}
