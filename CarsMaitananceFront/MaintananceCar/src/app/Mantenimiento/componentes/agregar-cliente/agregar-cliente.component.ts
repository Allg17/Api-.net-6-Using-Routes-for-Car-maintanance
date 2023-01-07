import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Clientes } from 'src/app/Interfaces/Clientes';
import { ClientesService } from '../../services/clientes.service';
import { AuthService } from '../../../auth/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-agregar-cliente',
  templateUrl: './agregar-cliente.component.html',
  styleUrls: ['./agregar-cliente.component.css']
})
export class AgregarClienteComponent {
  public mask = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/]
  public maskCedula = [/[1-9]/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/]
  cliente = <Clientes>{};
  constructor(private dialref: MatDialogRef<AgregarClienteComponent>,
    private router: Router,
    private clienteservice: ClientesService, private authservice: AuthService, private _snackBar: MatSnackBar) { }

  Cerrar() {
    this.dialref.close();
  }

  Agregar() {
    this.cliente.usuarioID = this.authservice.auth.usuarioID;
    this.cliente.fechaCreado = new Date();
    this.clienteservice.Agregar(this.cliente).subscribe(data => {
      if (data.clienteID > 0) {
        this.MostrarSnackBar("Cliente Creado");
        this.cliente = <Clientes>{};
        this.dialref.close();
      }
    });
  }

  MostrarSnackBar(msg: string): void {
    this._snackBar.open(msg, 'Ok!', ({
      duration: 3500
    }));
  }

}
