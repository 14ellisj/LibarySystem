import type { Author } from "./author";
import type { Genre } from "./genre";
import type { Type } from "./type";

export interface Media {
  id: number,
  name: string,
  author: Author,
  type: Type,
  length: number,
  genre: Genre,
  description: string,
  image: string,
  rating: number,
  is_available: boolean
}

