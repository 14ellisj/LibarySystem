import type { Author } from "./author";


export interface Filter {
    title?: string,
    author?: string,
    availability?: boolean,
    type?: string
}

export interface ProfileFilter {
    firstname?: string,
    lastname?: string,
    email?: string,
}