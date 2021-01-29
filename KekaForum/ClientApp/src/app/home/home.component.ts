import { Component } from '@angular/core';
import { NavbarService } from 'src/services/navbar.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  
  isFormVisible:boolean;

  constructor(private navbarService:NavbarService){
    console.log(this.navbarService);
  }

  openQuestionForm(){
    this.isFormVisible=true;
    this.navbarService.hideSideNav();
    this.navbarService.hideTopNav();
  }

  addQuestion(){
    this.isFormVisible=false;
  }

  ngOnInit(){
    this.navbarService.showSideNav();
    this.navbarService.showTopNav();
    console.log(this.navbarService);
  }
}
