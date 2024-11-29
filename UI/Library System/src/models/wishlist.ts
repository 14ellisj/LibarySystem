import type { Media } from "./media";
import type { Profile } from "./profile";

export interface WishList {
    id: number,
    media_id: Media,
    profile_id: Profile
  }