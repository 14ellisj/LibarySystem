import type { Author } from "./author";
import type { Genre } from "./genre";
import type { Type } from "./type";

export interface Media {
  id: number,
  name: string,
  author_id: Author,
  avaliablity: boolean,
  type: Type,
  length: number,
  genre: Genre,
  description: string,
  media_art: Blob,
  rating: number
}

