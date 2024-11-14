import { Genre, Type, type Media } from "@/models/media";
import { useMediaStore } from "@/stores/media";
import axios from "axios";

export default class {

    mediaStore = useMediaStore();

    async getData(): Promise<Media[]> {
        await axios
            .get("https://localhost:7166/Media")
            .then((response) => {
                this.mediaStore.setMedia(response.data)
            })

        return this.mediaStore.media;
    }
  }