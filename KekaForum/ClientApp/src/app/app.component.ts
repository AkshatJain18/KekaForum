import { Component } from '@angular/core';
import { NavbarService } from 'src/services/navbar.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  isTopNavVisible:boolean;
  isSideNavVisible:boolean;
  navbarService:NavbarService;

  constructor(navbarService:NavbarService){
    this.navbarService=navbarService;
    console.log(this.navbarService);
  }

  ngOnInit(){

  }
}
