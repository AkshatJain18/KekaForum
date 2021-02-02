import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/User';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit {

  users:User[];
  
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(item=>this.users=item);
  }
}
