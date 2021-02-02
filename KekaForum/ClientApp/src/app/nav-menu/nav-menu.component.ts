import { Component } from '@angular/core';
import { Router, ActivatedRoute, ActivationEnd } from '@angular/router';
import { User } from 'src/models/User';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
})
export class NavMenuComponent {

  user:User

  constructor(private router:Router,private activateRoute:ActivatedRoute){
    this.user = JSON.parse(localStorage.getItem('user'));
    console.log(this.user);
  }
}
