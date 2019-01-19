import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { RecipeListComponent } from './recipes/recipe-list/recipe-list.component';
import { RecipeDetailComponent } from './recipes/recipe-detail/recipe-detail.component';
import { RecipeDetailResolver } from './_resolvers/recipe-detail.resolver';
import { RecipeListResolver } from './_resolvers/recipe-list.resolver';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {
     path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'recipes', component: RecipeListComponent, resolve: {recipes: RecipeListResolver}},
            {path: 'recipes/:id', component: RecipeDetailComponent, resolve: {recipe: RecipeDetailResolver}},
            {path: 'messages', component: MessagesComponent},
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
