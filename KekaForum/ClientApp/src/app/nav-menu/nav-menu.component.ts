import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
})
export class NavMenuComponent {
  isExpanded = false;
  isHomeActive:boolean;
  isCategoriesActive:boolean;
  isUsersActive:boolean;
  
  constructor(private router:Router){
    
  }

  navigateToHome(){
    this.isHomeActive=true;
    this.router.navigateByUrl('/home');
  }

  navigateToCategories(){
    this.isCategoriesActive=true;
    this.router.navigateByUrl('/categories');
  }

  navigateToUsers(){
    this.isUsersActive=true;
    this.router.navigateByUrl('/users');
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
