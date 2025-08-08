import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  imports: [CommonModule, InputGroupModule,InputGroupAddonModule, FormsModule, PasswordModule, ButtonModule ],
})
export class LoginComponent {

  email: string = '';
  password: string = ''


  onSubmit() {
    const payload = {
      email: this.email,
      password: this.password,
    }

    console.log(payload);
    
  }
}
