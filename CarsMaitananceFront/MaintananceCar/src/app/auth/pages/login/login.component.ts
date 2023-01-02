import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Usuarios } from 'src/app/Interfaces/usuarios';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
 user = <Usuarios>{};


  constructor(private router: Router, private AuthService:AuthService) { }
  login() {
    console.log(this.AuthService.login(this.user).subscribe((a)=>{
     
      if(a)
      {
        this.router.navigate(['./mantenimiento'])
      }
    }))
  }
}
