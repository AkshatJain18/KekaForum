import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NavbarService {

  isTopNavVisible: boolean=true;
  isSideNavVisible: boolean=true;

  hideTopNav() { 
    this.isTopNavVisible = false; 
  }

  showTopNav() { 
    this.isTopNavVisible = true; 
  }
  
  hideSideNav() { 
    this.isSideNavVisible = false; 
  }

  showSideNav() { 
    this.isSideNavVisible = true; 
  }

}
