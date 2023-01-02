import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Clientes } from 'src/app/Interfaces/Clientes';
import { ClientesService } from '../../services/clientes.service';
import { AgregarClienteComponent } from '../../componentes/agregar-cliente/agregar-cliente.component';

@Component({
  selector: 'app-consulta-mant',
  templateUrl: './consulta-mant.component.html',
  styleUrls: ['./consulta-mant.component.css']
})
export class ConsultaMantComponent {

  constructor(private ClientesService: ClientesService,public dialog: MatDialog) { }
  public maskCedula = [ /[1-9]/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/]
  valor: string = '';
  Nombre: string = '';

  Buscar() {

    this.Nombre = "No hay registros.";
    this.ClientesService.BuscarCliente(this.valor).subscribe(x => {
      if (x != null)
        this.Nombre = x.nombre;
    });
  }

  Agregar() {
    const dial = this.dialog.open(AgregarClienteComponent, ({
      width: '700px',
      height:'700px',
      disableClose: true
    }));
  }
}
