import { Photo } from './photo';

export interface Recipe {
    id: number;
    name: string;
    description: string;
    ingredients: string;
    photos: Photo[];
    photoUrl: string;
}
