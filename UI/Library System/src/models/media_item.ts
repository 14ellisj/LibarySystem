import type { Library } from './library'
import type { Media } from './media'
import type { Profile } from './profile'

export interface Media_Item {
  id: number
  media_id: Media
  borrower_id: Profile
  library_id: Library
  reserver_id: Profile
  reserve_queue?: number
}
