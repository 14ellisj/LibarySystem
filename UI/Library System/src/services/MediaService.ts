import { Genre, Type, type Media } from "@/models/media";

export default class {

    getData(): Media[] {
    return [
        {
            author: {
            first_name: 'First',
            last_name: 'Last'
            },
            type: Type.DVD,
            genre: Genre.FANTASY,
            name: "Name of media"
        }
        ];
    }
  }