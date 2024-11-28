import type { Author } from "@/models/author";
import type { MediaFilter } from "@/models/filters";
import type { Media } from "@/models/media";
import type { IAutoCompleteParams } from "@/models/requests";
import { useMediaStore } from "@/stores/media";
import axios from "axios";

export default class {

    mediaStore = useMediaStore();

    apiUrl = "http://localhost:5132/"

    async filterData(filter: MediaFilter): Promise<Media[]> {
        const requestUrl = this.apiUrl + 'Media';

        await axios
            .get(requestUrl, {
                params: filter
            })
            .then((response) => {
                this.mediaStore.setMedia(response.data)
                console.log(response.data);
            })

        return this.mediaStore.media;
    }

    async getAutoCompleteAuthors(author: string) : Promise<string[]> {
        const requestUrl = this.apiUrl + 'AutoComplete/Author';
        const params : IAutoCompleteParams = { name: author }

        await axios
            .get(requestUrl, {
                params
            })
            .then((response) => {
                this.mediaStore.setAutocompleteOptions((response.data as Author[]).map(x => x.first_name + ' ' + x.last_name));
            })

        return this.mediaStore.autoCompleteOptions;
    }

    async getAutoCompleteTitles(name: string) : Promise<string[]> {
        const requestUrl = this.apiUrl + 'AutoComplete/Title';
        const params: IAutoCompleteParams = { name }

        await axios
            .get(requestUrl, {
                params
            })
            .then((response) => {
                this.mediaStore.setAutocompleteOptions((response.data as Media[]).map(x => x.name))
            })

        return this.mediaStore.autoCompleteOptions;
    }
  }