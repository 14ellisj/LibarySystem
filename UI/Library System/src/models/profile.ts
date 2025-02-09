import type { Library } from "./library";
import type { Role } from "./role";

export interface Profile {
    id: number,
    role: Role,
    library_id: Library,
    email: string,
    first_name: string,
    last_name: string,
    date_of_birth: string,
    password: string,
    address_id: Library,
  }
  
  
