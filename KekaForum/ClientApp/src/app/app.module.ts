import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SideNavMenuComponent } from './side-nav-menu/side-nav-menu.component';
import { LoginComponent } from './login/login.component';


@NgModule({
  declarations: [		
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SideNavMenuComponent,
      LoginComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { 
        path: '', 
        component: HomeComponent, 
        pathMatch: 'full' 
      },
      { 
        path: 'login', 
        component: LoginComponent, 
        pathMatch: 'full' 
      },
      { 
        path: 'home',
        component: HomeComponent,
        pathMatch: 'full' 
      },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
