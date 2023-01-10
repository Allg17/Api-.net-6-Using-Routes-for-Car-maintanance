
import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { SolicitudDetalle } from '../../../Interfaces/SolicitudDetalle';
import { Solicitud } from '../../../Interfaces/Solicitud';
import { SolicitudService } from '../../services/solicitud.service';
import { AuthService } from 'src/app/auth/auth.service';
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
  datos: Solicitud[] = []
  constructor(private SolicitudService: SolicitudService, private authService: AuthService) {
    // Assign the data to the data source for the table to render

    let user = this.authService.auth.rol.pefilesRoles.forEach(role => {
      SolicitudService.GetSolicitudesByArea(role.perfil.areaID).subscribe((data) => {
        data.forEach((solicitud) => {
          if (this.datos.find(x => x.solicitudID === solicitud.solicitudID)?.solicitudID === undefined)
            this.datos.push(solicitud);
        })
      });


      setTimeout(() => {
        this.dataSource = new MatTableDataSource(this.datos);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
        1000);
    })
  }

  ngAfterViewInit(): void {



  }

  VerificarAcceso(url: string) {
    return this.authService.verificarModulo(url);
  }

  VerificarUsuario() {
    return this.authService.auth.rolID == 5 ||this.authService.auth.rolID  ==6 ;
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
