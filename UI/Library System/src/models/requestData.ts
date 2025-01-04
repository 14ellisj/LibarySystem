import type { Library } from "./library"
import type { MediaItem } from "./mediaItem"


export interface RequestData {
  id: number
  mediaItem: MediaItem
  destination_library: Library
  acceptance: boolean
}