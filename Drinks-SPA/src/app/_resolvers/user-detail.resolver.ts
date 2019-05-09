import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { NgxNotificationService } from 'ngx-notification';
import { AuthService } from '../_services/auth.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()

export class UserDetailResolver implements Resolve<User> {
constructor(private userService: UserService, private router: Router,
    private authService: AuthService, private notif: NgxNotificationService ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<User> {
        return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
            catchError(error => {
                this.notif.sendMessage('Problem retrieving data', 'warning', 'bottom-right');
                this.router.navigate(['/users']);
                return of(null);
            })
        );
    }
}
