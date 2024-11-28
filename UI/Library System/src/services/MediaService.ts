import type { Author } from "@/models/author";
import type { MediaFilter } from "@/models/filters";
import type { Media } from "@/models/media";
import type { IAutoCompleteParams } from "@/models/requests";
import type { SearchType } from "@/models/searchType";
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
            })

        return this.mediaStore.media;
    }

    async getAutoComplete(query: string, searchType: SearchType) : Promise<string[]> {
        const requestUrl = this.apiUrl + 'AutoComplete';
        const params : IAutoCompleteParams = { query, search_type: searchType }
        console.log(searchType);
        await axios
            .get(requestUrl, {
                params
            })
            .then((response) => {
                this.mediaStore.setAutocompleteOptions((response.data as string[]));
            })

        return this.mediaStore.autoCompleteOptions;
    }

}