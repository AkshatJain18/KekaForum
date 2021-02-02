import { Component, ChangeDetectorRef } from '@angular/core';
import { NavbarService } from 'src/services/navbar.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  navbarService:NavbarService;

  constructor(navbarService:NavbarService,private changeDetector:ChangeDetectorRef ){
    this.navbarService=navbarService;
    console.log(this.navbarService);
  }

  ngOnInit(){

  }

  ngAfterViewChecked(){ this.changeDetector.detectChanges(); }
}
