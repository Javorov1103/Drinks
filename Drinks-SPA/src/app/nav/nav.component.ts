import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { NgxNotificationService } from 'ngx-notification';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
  constructor(public authService: AuthService, private ngxNotificationService: NgxNotificationService,
    private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.ngxNotificationService.sendMessage('Logged in successfully', 'success', 'bottom-right');
    }, error => {
      this.ngxNotificationService.sendMessage('Failed to login', 'warning', 'top-right');
    }, () => {
      this.router.navigate(['/recipes']);
    });
  }

  loggedIn() {
    return this.authService.loggedin();
  }

  logout() {
    localStorage.removeItem('token');
    this.ngxNotificationService.sendMessage('Logout success', 'warning', 'bottom-right');
    this.router.navigate(['/home']);
  }
}
