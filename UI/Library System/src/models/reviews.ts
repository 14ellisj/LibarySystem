import type { Media } from './media'
import type { Profile } from './profile'

export interface Reviews {
  id: number
  media_id: Media
  rating: number
  profile_id: Profile
  review: string
}
