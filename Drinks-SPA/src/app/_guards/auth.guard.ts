import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { NgxNotificationService } from 'ngx-notification';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router,
     private ngxNotificationService: NgxNotificationService) {}

  canActivate(): boolean {
    if (this.authService.loggedin()) {
      return true;
    }
    this.ngxNotificationService.sendMessage('You shall not pass!!!', 'warning', 'bottom-right');
    this.router.navigate(['/home']);
    return false;
  }
}
