import { Genre, Type, type Media } from "@/models/media";
import { useMediaStore } from "@/stores/media";
import axios from "axios";

export default class {

    data: any;


    async getData(): Promise<Media[]> {

        console.log("Current Data: " + this.data);
        const mediaStore = useMediaStore();

        await axios
        .get("https://localhost:7166/Media")
        .then((response) => {
            this.data = response.data
            mediaStore.setMedia(response.data)
        })

        return this.data;
    }
  }