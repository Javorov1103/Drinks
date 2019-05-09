import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/_models/recipe';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit {
recipe: Recipe;

  constructor(private route: ActivatedRoute) { }
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.recipe = data['recipe'];
    });
  }
}

