import { Recipe } from './recipe';

export interface Photo {
    id: number;
    url: string;
    added: Date;
    isMain: boolean;
}
