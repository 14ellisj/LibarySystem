import type { Filter } from "@/models/filters";
import type { Media } from "@/models/media";
import type { Author } from "@/models/author";
import { useAuthorStore } from "@/stores/author";
import { useMediaStore } from "@/stores/media";
import axios from "axios";

export default class {

    mediaStore = useMediaStore();
    authorStore = useAuthorStore();
    apiUrl = "http://localhost:5132/Media"

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