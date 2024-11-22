export interface Media {
  id: number;
  name: string
  author: Author
  avaliablity: boolean;
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
