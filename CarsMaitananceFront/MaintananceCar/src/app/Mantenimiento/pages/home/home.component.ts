import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../auth/auth.service';
import { Usuarios } from '../../../Interfaces/usuarios';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [`.container{margin:10px;}`
  ]
})
export class HomeComponent {
  user: Usuarios | undefined;
  constructor(private router: Router, private authservice: AuthService) {

    this.user = authservice.auth;
  }

  VerificarAcceso(url:string)
  {
    return this.authservice.verificarModulo(url);
  }
  
  logout() {
    this.authservice.logout();
    this.router.navigate(['./auth/login'])
  }
}
