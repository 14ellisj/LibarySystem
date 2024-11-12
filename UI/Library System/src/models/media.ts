export interface Media {
  name: string
  author: Author
  type: Type
  genre: Genre
}

export interface Author {
  first_name: string
  last_name: string
}

export enum Type {
  AUDIO_BOOK,
  BOOK,
  DVD,
}

export enum Genre {
  FANTASY,
  ROMANCE,
  CRIME,
}
