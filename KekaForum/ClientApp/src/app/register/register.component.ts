import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from 'src/services/auth.service';
import { Router } from '@angular/router';
import { NavbarService } from 'src/services/navbar.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent implements OnInit {

  registerForm:FormGroup;
  isSubmitted:boolean;
  
  constructor(private authService:AuthService,private router:Router,private navbarService:NavbarService) { 
    this.buildRegistrationForm({});
    this.navbarService.hideSideNav();
    this.navbarService.hideTopNav();
  }

  buildRegistrationForm(userDetails:any){
    this.registerForm=new FormGroup({
      firstName:new FormControl(userDetails.firstName,[Validators.required]),
      lastName:new FormControl(userDetails.lastName,[Validators.required]),
      phoneNumber:new FormControl(userDetails.email,[Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      email:new FormControl(userDetails.email,[Validators.required,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
      password:new FormControl(userDetails.password,[Validators.required,Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}') ]),
      desingation:new FormControl(userDetails.desingation,[Validators.required]),
      departmentId:new FormControl(userDetails.departmentId,[Validators.required]),
      locationId:new FormControl(userDetails.locationId,[Validators.required])
    });
  }
  
  register(){
    this.isSubmitted=true;
    if(this.registerForm.valid){
      this.authService.register(this.registerForm.value).subscribe(user=>
      {
        if(user.id!=null){
          localStorage.setItem('user',JSON.stringify(user))
          this.router.navigateByUrl('/homepage');
        }else{  
          alert('invalid credentials');
        } 
      });
    }
  }

  ngOnInit() {

  }

}
