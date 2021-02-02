import { Component, OnInit } from '@angular/core';
import { NavbarService } from 'src/services/navbar.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from 'src/services/auth.service';
import { User } from 'src/models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {

  loginForm:FormGroup;
  isSubmitted:boolean;

  constructor(private navbarService:NavbarService,private router:Router,private authService:AuthService) { 
    this.navbarService.hideSideNav();
    this.navbarService.hideTopNav();
    this.buildLoginForm({});
  }

  buildLoginForm(loginCredentials:any){
    this.loginForm=new FormGroup({
      email:new FormControl(loginCredentials.email,[Validators.required,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
      password:new FormControl(loginCredentials.password,[Validators.required,Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')]),
    });
  }

  login(){
    this.isSubmitted=true;
    console.log(this.loginForm.value);
    if(this.loginForm.valid){
      this.authService.login(this.loginForm.value).subscribe(user=>
      {
        if(user.id!=null){
          const userData:User=user;
          localStorage.setItem('accessToken',user.accessToken);
          localStorage.setItem('user',JSON.stringify(userData));
          console.log(user);
          this.router.navigateByUrl('/homepage');
        }else{  
          alert("invalid credentials");
        } 
      });
    }  
  }

  ngOnInit() {
  }
}
