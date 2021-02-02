import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { JwtModule} from "@auth0/angular-jwt"
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
import { UsersComponent } from './users/users.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { QuestionsComponent } from './questions/questions.component';
import {TimeAgoPipe} from 'time-ago-pipe';
import { AnswerComponent } from './questions/answer/answer.component';
import { AuthInterceptor } from 'src/interceptors/auth-interceptor';

export function tokenGetter(){
  var accessToken=<any>localStorage.getItem('accessToken');
  return accessToken;
}

@NgModule({
  declarations: [							
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TimeAgoPipe,
    SideNavMenuComponent,
    LoginComponent,
    RegisterComponent,
    CategoriesComponent,
    UsersComponent,
    UserDetailComponent,
    QuestionsComponent,
    AnswerComponent
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
        path: 'categories', 
        component: CategoriesComponent, 
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
        path: 'users',
        component: UsersComponent,
        pathMatch: 'full' 
      },
      { 
        path: 'user-detail',
        component: UserDetailComponent,
        pathMatch: 'full' 
      },
      { 
        path: '**', 
        component: HomeComponent, 
        pathMatch: 'full' 
      },
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter:tokenGetter,
        allowedDomains:["localhost:5001"],
        disallowedRoutes:[]
      }
    })
  ],
  providers: [
    {
      provide : HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi   : true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
