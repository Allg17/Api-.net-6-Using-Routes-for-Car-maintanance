import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Confirm } from 'src/app/Interfaces/Confirm';
import { Recordatorio } from '../../../Interfaces/Recordatorio';
import { ConfirmComponent } from '../../componentes/confirm/confirm.component';
import { RecordatorioService } from '../../services/recordatorio.service';

@Component({
  selector: 'app-consultar-recordatorio',
  templateUrl: './consultar-recordatorio.component.html',
  styleUrls: ['./consultar-recordatorio.component.css']
})
export class ConsultarRecordatorioComponent {
  displayedColumns: string[] = ['cliente.nombre', 'cliente.telefono', 'fechaRecordatorio', 'observacion', 'Accion'];
  dataSource: MatTableDataSource<Recordatorio>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  confirm = <Confirm>{};
  constructor(private recordatorioservice: RecordatorioService,private _snackBar: MatSnackBar, public dialog: MatDialog,) {
    recordatorioservice.Getall().subscribe((data) => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      console.log(data)
    });
  }



  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  MostrarSnackBar(msg: string): void {
    this._snackBar.open(msg, 'Ok!', ({
      duration: 4500
    }));
  }

  OnChange(record: Recordatorio) {

    this.confirm.Opcion = "Continuar";
    this.confirm.Titulo = "Seguro que desea continuar?";
    const dial = this.dialog.open(ConfirmComponent, ({
      width: '250px',
      data: this.confirm  // esto es para que si se modifica algo, no se modifique esta propiedad, ya que todo se pasa por referencia.
    }));

    dial.afterClosed().subscribe(res => {
      if (res) {
        console.log(record)
        this.recordatorioservice.Actualizar(record).subscribe(record => {
          this.recordatorioservice.Getall().subscribe((data) => {
            this.dataSource = new MatTableDataSource(data);
            this.dataSource.paginator = this.paginator;
            this.dataSource.sort = this.sort;
            this.MostrarSnackBar("Recordatorio Actualizado")
          });
        })
      }
    });
  }
}
