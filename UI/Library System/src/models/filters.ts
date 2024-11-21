import type { Author } from "./media";

export interface Filter {
    title?: string,
    author?: string,
    availability?: boolean
}

export interface ProfileFilter {
    firstname?: string,
    lastname?: string,
}