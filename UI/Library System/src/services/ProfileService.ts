import type { ProfileFilter } from "@/models/filters";
import {type Profile } from "@/models/profile";
import { useUserStore } from "@/stores/profileInformation";
import axios from "axios";

export default class {

    userStore = useUserStore();
    apiUrl = "http://localhost:5273/Profile"

    async getData(): Promise<Profile> {
        await axios
            .get(this.apiUrl)
            .then((response) => {
                this.userStore.setUser(response.data)
                console.log(response.data);
            })

        return this.userStore.user;
    }

    async filterData(filter: ProfileFilter, password: string): Promise<Profile> {
        await axios
            .get(this.apiUrl, {
                params: filter
            })
            .then((response) => {
                this.userStore.setUser(response.data)
                this.userStore.setPassword(password)
                console.log(password)
                console.log(response.data);
            })

        return this.userStore.user;
    }
  }