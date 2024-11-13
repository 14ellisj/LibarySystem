import { Genre, Type, type Media } from "@/models/media";
import axios from "axios";

export default class {

    data: any;

    async getData(): Promise<Media[]> {
        await axios
        .get("https://localhost:7166/Media")
        .then((response) => {
            console.log(response.data)
            this.data = response.data
        })

        return this.data;
    }
  }