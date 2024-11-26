import type { Media } from "@/models/media";
import type { Author } from "@/models/author";
import { useAuthorStore } from "@/stores/author";
import { useMediaStore } from "@/stores/media";
import axios from "axios";

export default class {

    mediaStore = useMediaStore();
    authorStore = useAuthorStore();
    apiUrl = "http://localhost:5132/Media"


async getData(): Promise<Author[]> {
    await axios
        .get(this.apiUrl)
        .then((response) => {
            this.authorStore.setAuthor(response.data)
        })

    return this.authorStore.author;
}
}