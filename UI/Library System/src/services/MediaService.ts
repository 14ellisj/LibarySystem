import type { Filter } from "@/models/filters";
import { Genre, Type, type Media } from "@/models/media";
import { useMediaStore } from "@/stores/media";
import axios from "axios";

export default class {

    mediaStore = useMediaStore();
<<<<<<< Updated upstream
    apiUrl = "https://localhost:7166/Media"
=======
    apiUrl = "http://localhost:5132/Media"
>>>>>>> Stashed changes

    async getData(): Promise<Media[]> {
        await axios
            .get(this.apiUrl)
            .then((response) => {
                this.mediaStore.setMedia(response.data)
            })

        return this.mediaStore.media;
    }

    async filterData(filter: Filter): Promise<Media[]> {
        await axios
            .get(this.apiUrl, {
                params: filter
            })
            .then((response) => {
                this.mediaStore.setMedia(response.data)
            })

        return this.mediaStore.media;
    }
  }