import type { ProfileFilter } from "@/models/filters";
import {type ProfileDetails } from "@/models/profileDetials";
import { useUserStore } from "@/stores/profileInformation";
import axios from "axios";

export default class {

    userStore = useUserStore();
    apiUrl = "http://localhost:7166/Profile"

    async getData(): Promise<ProfileDetails[]> {
        await axios
            .get(this.apiUrl)
            .then((response) => {
                this.userStore.setUser(response.data)
            })

        return this.userStore.user;
    }

    async filterData(filter: ProfileFilter): Promise<ProfileDetails[]> {
        await axios
            .get(this.apiUrl, {
                params: filter
            })
            .then((response) => {
                this.userStore.setUser(response.data)
            })

        return this.userStore.user;
    }
  }