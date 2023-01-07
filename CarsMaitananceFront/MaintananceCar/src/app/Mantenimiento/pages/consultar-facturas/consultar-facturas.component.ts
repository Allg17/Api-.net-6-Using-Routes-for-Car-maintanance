
import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Solicitud } from '../../../Interfaces/Solicitud';
import { SolicitudService } from '../../services/solicitud.service';
import { FacturarService } from '../../services/facturar.service';
import { Facturas } from '../../../Interfaces/Facturas';
import { SolicitudDetalle } from '../../../Interfaces/SolicitudDetalle';
import { Router } from '@angular/router';

@Component({
  selector: 'app-consultar-facturas',
  templateUrl: './consultar-facturas.component.html',
  styleUrls: ['./consultar-facturas.component.css']
})
export class ConsultarFacturasComponent {
  displayedColumns: string[] = ['comentario', 'descripcion', 'cliente.nombre', 'fecha', 'fechaSolicitud', 'completada', 'total', 'Accion'];
  dataSource: MatTableDataSource<Facturas>;
  Despachar: boolean = false;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  constructor(private facturaservice: FacturarService, private router: Router) {
    if (this.router.url.includes('despacho')) {
      this.Despachar = true;
    }

    facturaservice.Getallfacturas().subscribe((data) => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      console.log(data);
    });
  }


  GetTotal(detalle: SolicitudDetalle[]) {
    return detalle.reduce((accumulator, { precio }) => {
      return accumulator + precio;
    }, 0);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


}
