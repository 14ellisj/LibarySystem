import {type ProfileDetails } from "@/models/profileDetials";
import { useUserStore } from "@/stores/profileInformation";
import axios from "axios";

export default class {

    UserStore = useUserStore();

    async getData(): Promise<ProfileDetails[]> {
        await axios
            .post("https://localhost:7166/Register")
            .then((response) => {
                this.UserStore.setUser(response.data)
            })

        return this.UserStore.user;
    }
  }