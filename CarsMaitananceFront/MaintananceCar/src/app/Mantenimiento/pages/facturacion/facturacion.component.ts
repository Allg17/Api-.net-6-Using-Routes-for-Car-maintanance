import { Component } from '@angular/core';

import { ClientesService } from '../../services/clientes.service';
import { AreaService } from '../../services/area.service';

import { catchError, Observable, of, switchMap } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Solicitud } from 'src/app/Interfaces/Solicitud';
import { AuthService } from '../../../auth/auth.service';
import { SolicitudService } from '../../services/solicitud.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmComponent } from '../../componentes/confirm/confirm.component';
import { Confirm } from '../../../Interfaces/Confirm';
import { ActivatedRoute, Router } from '@angular/router';
import { Facturas } from 'src/app/Interfaces/Facturas';
import { SolicitudDetalle } from '../../../Interfaces/SolicitudDetalle';
import { FacturarService } from '../../services/facturar.service';

@Component({
  selector: 'app-facturacion',
  templateUrl: './facturacion.component.html',
  styleUrls: ['./facturacion.component.css']
})
export class FacturacionComponent {

  despachar: boolean = false;
  total: number = 0;
  completada: boolean = false;
  confirm = <Confirm>{};
  termino: string = ""
  Factura = <Facturas>{};
  Detalle: SolicitudDetalle[] = []
  ver: boolean = false;
  constructor(private _snackBar: MatSnackBar,
    public dialog: MatDialog,
    private router: Router,
    private facturaservice: FacturarService,
    private activatedRoute: ActivatedRoute,
    private AuthService: AuthService, private facturaService: FacturarService, private Solicitudservice: SolicitudService) {
    this.Factura.solicitud = <Solicitud>{};
    this.Factura.solicitud.detalle = [];

    if (this.router.url.includes('despachar')) {
      this.completada = true;
      this.ver = true;
      this.despachar = true;
      this.activatedRoute.params.pipe(
        switchMap(({ id }) =>
          this.facturaService.get(id)

        ),
        catchError(error => of(error)))
        .subscribe(res => {
          this.Factura = res;
          console.log(res)
          this.termino = res.solicitud.cliente.nombre;
        })
    }
    else if (this.router.url.includes('editar')) {
      this.completada = true;
      this.activatedRoute.params.pipe(
        switchMap(({ id }) =>
          this.facturaService.get(id)

        ),
        catchError(error => of(error)))
        .subscribe(res => {
          this.Factura = res;
          console.log(res)
          this.termino = res.solicitud.cliente.nombre;
        })
    }
    else if (this.router.url.includes('ver')) {
      this.ver = true;
      this.completada = true;
      this.activatedRoute.params.pipe(
        switchMap(({ id }) =>
          this.facturaService.get(id)

        ),
        catchError(error => of(error)))
        .subscribe(res => {
          this.Factura = res;
          console.log(res)
          this.termino = res.solicitud.cliente.nombre;
        })
    }
    else if (this.router.url.includes('facturacion')) {
      this.completada = true;
      this.activatedRoute.params.pipe(
        switchMap(({ id }) =>
          this.Solicitudservice.GetSolicitud(id)

        ),
        catchError(error => of(error)))
        .subscribe(res => {
          this.Factura.fecha = new Date();
          this.Factura.solicitud = res;
          this.termino = res.cliente.nombre;
        })
    }
  }

  MostrarSnackBar(msg: string): void {
    this._snackBar.open(msg, 'Ok!', ({
      duration: 4500
    }));
  }

  CrearFactura() {
    this.confirm.Opcion = "Continuar";
    this.confirm.Titulo = "Seguro que desea continuar?";
    const dial = this.dialog.open(ConfirmComponent, ({
      width: '250px',
      data: this.confirm  // esto es para que si se modifica algo, no se modifique esta propiedad, ya que todo se pasa por referencia.
    }));

    dial.afterClosed().subscribe(res => {
      if (res) {
        if (this.Factura.facturasID) {
          this.facturaservice.Actualizar(this.Factura).subscribe(data => {
            console.log(data)

            if (data) {
              this.MostrarSnackBar("Solicitud Actualizada con exito");
              this.router.navigate(['/mantenimiento/facturacion'])
            }
          });
        }
        else {
          this.Factura.usuarioID = this.AuthService.auth.usuarioID;
          this.Factura.fecha = new Date();
          console.log(JSON.stringify(this.Factura));
          this.facturaservice.Agregar(this.Factura).subscribe(data => {
            console.log(data)
            if (data.facturasID > 0) {
              this.MostrarSnackBar("Factura Creada con exito");
              this.router.navigate(['/mantenimiento/consultarSolicitud'])
            }
          });
        }
      }
    });
  }

  CalculateTotal(event: number) {
    // if (this.Factura.solicitud.detalle.length > 0) {
    //   let total = this.Factura.solicitud.detalle.reduce((accumulator, { precio }) => {
    //     return accumulator + precio;
    //   }, 0);
    //   return total;
    // }

    if (event != null && event > 0)
      this.total = event;
    else
      this.total = 0.00;
  }

  DespacharSolicitud() {
    this.confirm.Opcion = "Continuar";
    this.confirm.Titulo = "Seguro que desea Despachar la solicitud?";
    const dial = this.dialog.open(ConfirmComponent, ({
      width: '250px',
      data: this.confirm  // esto es para que si se modifica algo, no se modifique esta propiedad, ya que todo se pasa por referencia.
    }));

    dial.afterClosed().subscribe(res => {
      if (res) {
        this.Solicitudservice.Despachar(this.Factura.solicitud.solicitudID).subscribe(data => {
          if (data) {
            this.MostrarSnackBar("Solicitud Despachada con exitos!");
            this.router.navigate(['/mantenimiento/despacho']);
          }
          else {
            this.MostrarSnackBar("Ocurrio un error al despachar");
          }
        });
      }
    });
  }
}
