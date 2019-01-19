import { Recipe } from './recipe';

export interface User {

    id: number;
    email: string;
    username: string;
    created: Date;
    lastActive: Date;
    introduction?: string;
    favourites?: string;
    recipes: Recipe[];
}
