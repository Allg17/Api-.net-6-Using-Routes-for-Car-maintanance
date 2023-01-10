import { AfterViewInit, Component, OnInit } from '@angular/core';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Clientes } from '../../../Interfaces/Clientes';
import { ClientesService } from '../../services/clientes.service';
import { AreaService } from '../../services/area.service';
import { Areas } from '../../../Interfaces/Areas';
import { SolicitudDetalle } from '../../../Interfaces/SolicitudDetalle';
import { catchError, Observable, of, switchMap } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Solicitud } from 'src/app/Interfaces/Solicitud';
import { AuthService } from '../../../auth/auth.service';
import { SolicitudService } from '../../services/solicitud.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmComponent } from '../../componentes/confirm/confirm.component';
import { Confirm } from '../../../Interfaces/Confirm';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-solicitud',
  templateUrl: './solicitud.component.html'
})
export class SolicitudComponent implements AfterViewInit, OnInit {
  constructor(private clienteservice: ClientesService, private areaservice: AreaService, private _snackBar: MatSnackBar,
    public dialog: MatDialog,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private AuthService: AuthService, private Solicitudservice: SolicitudService) {
    areaservice.GetAreas().subscribe(x => this.areas = x);
    this.Solicitud.detalle = [];
    this.Solicituddetalle.area = <Areas>{};
    if (this.router.url.includes('ver')) {
      this.ver = true;
      this.completada = true;
      this.activatedRoute.params.pipe(
        switchMap(({ id }) =>
          this.Solicitudservice.GetSolicitud(id)

        ),
        catchError(error => of(error)))
        .subscribe(res => {
          this.Solicitud = res;
          this.termino = res.cliente.nombre;
          this.clienteSelected = res.cliente;
        })
    }
    else if (this.router.url.includes('editar')) {
      this.completada = true;
      let areas = ""
      this.AuthService.auth.rol.pefilesRoles.forEach(role => {
        areas += role.perfil.areaID.toString() + '-'
      })


      this.activatedRoute.params.pipe(
        switchMap(({ id }) =>
          this.Solicitudservice.GetSolicitudByArea(id,areas)

        ),
        catchError(error => of(error)))
        .subscribe(res => {
          this.Solicitud = res;
          this.termino = res.cliente.nombre;
          this.clienteSelected = res.cliente;
        })
    }

  }
  ngAfterViewInit(): void {

  }
  ver: boolean = false;
  completada: boolean = false;
  confirm = <Confirm>{};
  termino: string = ""
  terminoArea: string = "";
  clientes: Clientes[] = [];
  clienteSelected!: Clientes | undefined;
  areas: Areas[] = [];
  areasSelected = <Areas>{};
  Solicitud = <Solicitud>{};
  Solicituddetalle = <SolicitudDetalle>{};

  ngOnInit(): void {


  }


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

  BuscandoArea() {
    if (this.terminoArea != "") {
      this.areaservice.BuscarBylimit(this.terminoArea.trim(), 5).subscribe(areas => {
        if (areas.length > 0)
          this.areas = areas;
        else
          this.areas = [];
      });
    }
    else
      this.areas = [];
  }


  OpcionSeleccionada(event: MatAutocompleteSelectedEvent) {
    if (!event.option.value) {
      this.clienteSelected = undefined;
      return;
    }
    const cliente: Clientes = event.option.value;
    this.termino = cliente.nombre;
    this.clienteSelected = cliente;
  }

  AreaSeleccionada(event: MatAutocompleteSelectedEvent) {
    if (!event.option.value) {
      return;
    }
    const area: Areas = event.option.value;
    this.terminoArea = area.nombre;
    this.areasSelected = area;
  }

  Agregar() {
    if (this.Solicituddetalle.nombre && this.Solicituddetalle.precio > 0 && this.Solicituddetalle.descripcion && this.terminoArea) {
      this.Solicituddetalle.area = this.areasSelected;
      this.Solicituddetalle.areaID = this.areasSelected.areaID;
      this.Solicituddetalle.usuarioID = this.AuthService.auth.usuarioID;
      this.Solicitud.detalle.push(this.Solicituddetalle);
      this.Solicituddetalle = <SolicitudDetalle>{};
      this.terminoArea = "";
    } else {
      this.MostrarSnackBar("Debe llenar los campos");
    }
  }

  Eliminar(item: SolicitudDetalle[]) {
    this.Solicitud.detalle = item;
  }

  Modificar(item: any) {
    this.Solicitud.detalle = item.lista;
    this.Solicituddetalle = item.item;
    this.terminoArea = item.item.area.nombre;
    this.areasSelected = item.item.area
  }

  MostrarSnackBar(msg: string): void {
    this._snackBar.open(msg, 'Ok!', ({
      duration: 2500
    }));
  }

  CrearSolicitud() {
    this.confirm.Opcion = "Continuar";
    this.confirm.Titulo = "Seguro que desea continuar?";
    const dial = this.dialog.open(ConfirmComponent, ({
      width: '250px',
      data: this.confirm  // esto es para que si se modifica algo, no se modifique esta propiedad, ya que todo se pasa por referencia.
    }));

    dial.afterClosed().subscribe(res => {
      if (res) {
        if (this.Solicitud.solicitudID) {
          this.Solicitudservice.Actualizar(this.Solicitud).subscribe(data => {
            console.log(data)

            if (data) {
              this.MostrarSnackBar("Solicitud Actualizada con exito");
              this.router.navigate(['/mantenimiento/consultarSolicitud'])
            }
          });
        }
        else {
          this.Solicitud.usuarioID = this.AuthService.auth.usuarioID;
          this.Solicitud.clienteID = this.clienteSelected?.clienteID ?? 0;
          this.Solicitudservice.Agregar(this.Solicitud).subscribe(data => {
            if (data.solicitudID > 0) {
              this.MostrarSnackBar("Solicitud Creada con exito");
              this.router.navigate([`/mantenimiento/solicitud/editar/${data.solicitudID}`])
            }
          });
        }
      }
    });
  }
}
