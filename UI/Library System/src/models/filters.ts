import type { Author } from "./author";


export interface MediaFilter {
    title?: string,
    author?: string,
    availability?: boolean,
    isSelected?: boolean
}

export interface ProfileFilter {
    firstname?: string,
    lastname?: string,
    email?: string,
}