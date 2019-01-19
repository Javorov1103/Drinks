import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/_models/recipe';
import { RecipeService } from 'src/app/_services/recipe.service';
import { NgxNotificationService } from 'ngx-notification';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css']
})
export class RecipeDetailComponent implements OnInit {
  recipe: Recipe;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private recipeService: RecipeService,
    private notif: NgxNotificationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
      this.route.data.subscribe(data => {
      this.recipe = data['recipe'];
    });

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false,
      }
    ];

    this.galleryImages = this.getImages();
  }

  getImages() {
    const imagesUrl = [];
    for (let i = 0; i < this.recipe.photos.length; i++) {
        imagesUrl.push({
          small: this.recipe.photos[i].url,
          medium: this.recipe.photos[i].url,
          big: this.recipe.photos[i].url,
        });
    }

    return imagesUrl;
  }

  // loadRecipe() {
  //   this.recipeService.getRecipe(+this.route.snapshot.params['id']).subscribe((recipe: Recipe) => {
  //   this.recipe = recipe;
  // }, error => {
  //   this.notif.sendMessage(error, 'warning', 'bottom-right');
  // });
  //

}
