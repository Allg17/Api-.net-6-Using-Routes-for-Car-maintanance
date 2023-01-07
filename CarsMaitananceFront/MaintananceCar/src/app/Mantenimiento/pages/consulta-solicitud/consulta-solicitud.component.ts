
import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { SolicitudDetalle } from '../../../Interfaces/SolicitudDetalle';
import { Solicitud } from '../../../Interfaces/Solicitud';
import { SolicitudService } from '../../services/solicitud.service';
@Component({
  selector: 'app-consulta-solicitud',
  templateUrl: './consulta-solicitud.component.html',
  styleUrls: ['./consulta-solicitud.component.css']
})
export class ConsultaSolicitudComponent implements AfterViewInit {
  displayedColumns: string[] = ['descripcion', '.cliente.nombre', 'fecha', 'completada', 'Accion'];
  dataSource: MatTableDataSource<Solicitud>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  constructor(private SolicitudService: SolicitudService) {
    // Assign the data to the data source for the table to render
    SolicitudService.GetallSolicitud().subscribe((data) => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      console.log(data);
    });
  }

  ngAfterViewInit(): void {



  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
