import type { Media } from './media'
import type { Profile } from './profile'

export interface Reservation {
  id: number
  media_id: Media
  reserver_id: Profile
  queue_order: number
}
