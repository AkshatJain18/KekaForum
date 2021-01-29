import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SideNavMenuComponent } from './side-nav-menu/side-nav-menu.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CategoriesComponent } from './categories/categories.component';


@NgModule({
  declarations: [				
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SideNavMenuComponent,
      LoginComponent,
      RegisterComponent,
      CategoriesComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { 
        path: 'login', 
        component: LoginComponent, 
        pathMatch: 'full' 
      },
      { 
        path: 'register', 
        component: RegisterComponent, 
        pathMatch: 'full' 
      },
      { 
        path: 'home',
        component: HomeComponent,
        pathMatch: 'full' 
      },
      { 
        path: '**', 
        component: HomeComponent, 
        pathMatch: 'full' 
      },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
