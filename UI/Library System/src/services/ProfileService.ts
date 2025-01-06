import type { ProfileFilter } from "@/models/filters";
import {type Profile } from "@/models/profile";
import { useUserStore } from "@/stores/profileInformation";
import type { IRegisterDetails } from "@/models/register.ts";
import axios from "axios";

export default class {
  userStore = useUserStore()
  apiUrl = 'http://localhost:5273/Profile'

  async getData(): Promise<Profile> {
    await axios
        .get(this.apiUrl)
        .then((response) => {
            this.userStore.setUser(response.data)
        })

    return this.userStore.user
  }

    async filterData(filter: ProfileFilter, password: string): Promise<Profile> {
        await axios
            .get(this.apiUrl, {
                params: filter
            })
            .then((response) => {
                this.userStore.setUser(response.data)
                this.userStore.setPassword(password)
            })

        return this.userStore.user;
    }

    async checkEmail(filter: ProfileFilter): Promise<Profile> {
        await axios
            .get(this.apiUrl, {
                params: filter
            })
            .then((response) => {
                this.userStore.setUser(response.data)
            })

        return this.userStore.user;
    }

    async createProfile(email: string, firstName: string, lastName: string, password: string){
        const body : IRegisterDetails = {
            email: email,
            first_name: firstName,
            last_name: lastName,
            password: password
        }
        axios
            .post(this.apiUrl, body)
            .then((response) => {
                console.log("Created new profile");
            })

        return this.userStore.user;
    }
  }
