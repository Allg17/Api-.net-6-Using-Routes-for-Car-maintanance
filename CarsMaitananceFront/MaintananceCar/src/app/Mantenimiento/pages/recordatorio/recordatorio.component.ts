import { Component } from '@angular/core';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Clientes } from 'src/app/Interfaces/Clientes';
import { Recordatorio } from 'src/app/Interfaces/Recordatorio';
import { ClientesService } from '../../services/clientes.service';
import { RecordatorioService } from '../../services/recordatorio.service';
import { AuthService } from '../../../auth/auth.service';


@Component({
  selector: 'app-recordatorio',
  templateUrl: './recordatorio.component.html',
  styleUrls: ['./recordatorio.component.css']
})
export class RecordatorioComponent {
  termino: string = "";
  clientes: Clientes[] = [];
  clienteSelected!: Clientes | undefined;
  Recordatorio = <Recordatorio>{}
  myFilter = (d: Date | null): boolean => {
    const day = (d || new Date()).getDay();
    // Prevent Saturday and Sunday from being selected.
    return day !== 0 && day !== 6;
  };

  constructor(private clienteservice: ClientesService, private userService: AuthService, private router: Router, private _snackBar: MatSnackBar, private recordatorioservice: RecordatorioService) { }


  Buscando() {
    if (this.termino != "") {
      this.clienteservice.BuscarBylimit(this.termino.trim(), 5).subscribe(clientes => {
        if (clientes.length > 0)
          this.clientes = clientes;
        else
          this.clientes = [];
      });
    }
    else
      this.clientes = [];
  }

  OpcionSeleccionada(event: MatAutocompleteSelectedEvent) {
    if (!event.option.value) {
      this.clienteSelected = undefined;
      return;
    }
    const cliente: Clientes = event.option.value;
    this.termino = cliente.nombre;
    this.Recordatorio.cliente = cliente;
  }


  MostrarSnackBar(msg: string): void {
    this._snackBar.open(msg, 'Ok!', ({
      duration: 2500
    }));
  }

  Agregar() {
    this.Recordatorio.usuarioID = this.userService.auth.usuarioID;
    this.recordatorioservice.Agregar(this.Recordatorio).subscribe(data => {
      if (data.recordatorioID > 0) {
        this.MostrarSnackBar("Recordatorio Creada con exito");
        this.Recordatorio = <Recordatorio>{};
        this.termino = "";
      }
    });
  }


}
