import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Clientes } from 'src/app/Interfaces/Clientes';
import { ClientesService } from '../../services/clientes.service';
import { AuthService } from '../../../auth/auth.service';

@Component({
  selector: 'app-agregar-cliente',
  templateUrl: './agregar-cliente.component.html',
  styleUrls: ['./agregar-cliente.component.css']
})
export class AgregarClienteComponent {
  public mask = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/]
  public maskCedula = [ /[1-9]/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/]
  cliente=<Clientes>{};
  constructor(private dialref: MatDialogRef<AgregarClienteComponent>, private clienteservice:ClientesService,private authservice:AuthService){}

  Cerrar(){
    this.dialref.close();
  }

  Agregar()
  {
    this.cliente.usuarioID = this.authservice.auth.usuarioID;
    this.cliente.fechaCreado = new Date();
    //this.clienteservice.Agregar(this.cliente).subscribe(data =>this.cliente = data);
  }
}
