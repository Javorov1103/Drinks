import { Injectable } from '@angular/core';
import { Recipe } from '../_models/recipe';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { RecipeService } from '../_services/recipe.service';
import { Observable, of } from 'rxjs';
import { NgxNotificationService } from 'ngx-notification';
import { catchError } from 'rxjs/operators';

@Injectable()
export class RecipeDetailResolver implements Resolve<Recipe> {
    constructor(private recipeService: RecipeService,
         private router: Router, private notif: NgxNotificationService) {}

resolve(route: ActivatedRouteSnapshot): Observable<Recipe> {
    return this.recipeService.getRecipe(route.params['id']).pipe(
        catchError(error => {
            this.notif.sendMessage('Problem retrieving data', 'warning', 'bottom-right');
            this.router.navigate(['/recipes']);
            return of(null);
        })
    );
}
}
