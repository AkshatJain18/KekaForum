import { Component, OnInit } from '@angular/core';
import { NavbarService } from 'src/services/navbar.service';
import { Category } from 'src/models/Category';
import { CategoryService } from 'src/services/category.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
})
export class CategoriesComponent implements OnInit {

  isFormVisible:boolean;
  categories:Category[];
  categoryForm:FormGroup;

  constructor(private navbarService:NavbarService,private cateogryService:CategoryService) { }

  openCategoryForm(){
    this.isFormVisible=true;
    this.navbarService.hideSideNav();
    this.navbarService.hideTopNav();
  }

  closeCategoryForm(){
    this.isFormVisible=false;
    this.navbarService.showSideNav();
    this.navbarService.showTopNav();
  }

  buildCategoryForm(category:Category){
    this.categoryForm=new FormGroup({
      name:new FormControl(category.name,[Validators.required]),
      description:new FormControl(category.description,[Validators.required]),
    });
  }

  addCategory(){
    if(this.categoryForm.valid){
      this.closeCategoryForm();
      this.cateogryService.postCategory(this.categoryForm.value).subscribe();
    }
  }

  ngOnInit(){
    this.cateogryService.getAllCategories().subscribe(item=>this.categories=item);
  }
}
