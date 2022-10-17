import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/AuthService';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public title: string;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.userSub.subscribe(user => {
      this.title = user.email;
    })
  }

  public onLogout(): void {
    this.authService.logout();
  }
}
