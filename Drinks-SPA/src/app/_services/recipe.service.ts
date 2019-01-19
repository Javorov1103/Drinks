import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recipe } from '../_models/recipe';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  constructor(private http: HttpClient) { }

  getRecipes(): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(environment.apiUrl + 'recipe');
  }

  getRecipe(id): Observable<Recipe> {
    return this.http.get<Recipe>(environment.apiUrl + 'recipe/' + id);
  }
}
