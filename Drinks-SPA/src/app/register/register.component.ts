import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { modelGroupProvider } from '@angular/forms/src/directives/ng_model_group';
import { NgxNotificationService } from 'ngx-notification';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister =  new EventEmitter();
  model: any = {};

  constructor(private authService: AuthService, private ngxNotificationService: NgxNotificationService) { }

  ngOnInit() {
  }


register() {
  // TODO: Add validation for password and confirmPassword match
  if (this.model.password === this.model.confirmPassword) {
    this.authService.register(this.model).subscribe(() => {
      this.ngxNotificationService.sendMessage('Registration successfull', 'success', 'bottom-right');
    }, error => {
      this.ngxNotificationService.sendMessage(error, 'warning', 'center');
    });
  } else {
    this.ngxNotificationService.sendMessage('Please provide same passwords in the fields', 'warning', 'center');
  }
}

cancel() {
  this.cancelRegister.emit(false);
  console.log('cancelled');
}

}
