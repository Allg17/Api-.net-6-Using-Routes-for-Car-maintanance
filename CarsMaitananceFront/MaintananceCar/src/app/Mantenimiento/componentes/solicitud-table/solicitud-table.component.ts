import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { SolicitudDetalle } from '../../../Interfaces/SolicitudDetalle';
import { ConfirmComponent } from '../confirm/confirm.component';
import { Confirm } from '../../../Interfaces/Confirm';
import { MatDialog } from '@angular/material/dialog';
@Component({
  selector: 'app-solicitud-table',
  templateUrl: './solicitud-table.component.html',
  styleUrls: ['./solicitud-table.component.css']
})
export class SolicitudTableComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['nombre', 'descripcion', 'precio', 'area'];
  dataSource = <MatTableDataSource<SolicitudDetalle>>{};
  @Input() Lista = <SolicitudDetalle[]>{};
  @Input() Facturada: boolean = false;
  @Input() Acciones: boolean = false;
  @Input() Completada: boolean = false;
  @Input() AtivateCompletado: boolean = false;
  @Input() AtivateFacturado: boolean = false;
  filterValue: string = "";
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @Output() Editar: EventEmitter<any> = new EventEmitter();
  @Output() Total: EventEmitter<number> = new EventEmitter();
  @Output() Borrar: EventEmitter<SolicitudDetalle[]> = new EventEmitter();
  total: number = 0;
  confirm = <Confirm>{};
  constructor(public dialog: MatDialog,) {
    // Assign the data to the data source for the table to render
  }
  ngOnInit(): void {
    this.dataSource = new MatTableDataSource(this.Lista);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }


  ngAfterViewInit(): void {
    this.dataSource = new MatTableDataSource(this.Lista);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if (this.Completada) {
      this.displayedColumns.push("completada");
    }

    if (this.Facturada) {
      this.displayedColumns.push("facturada");
    }
    else {
      if (this.Acciones)
        this.displayedColumns.push('Acciones');
    }

    this.Facturar()


    setTimeout(() => {
      this.dataSource = new MatTableDataSource(this.Lista);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

    },
      1000);

  }

  Facturar() {

    //
    // alert(total)
    // if (row.facturada===true)
    //   this.total += row.precio;
    // else
    //   this.total -= row.precio;

    setTimeout(() => {
      this.total = this.Lista.reduce((accumulator, { precio, facturada }) => {
        if (facturada) {
          return accumulator + precio;
        }
        else
          return accumulator;
      }, 0);

      this.Total.emit(this.total);
    },
      50);
    // console.log(row.facturada)
    //       alert(this.total);

  }


  borrar(item: SolicitudDetalle) {

    this.confirm.Opcion = "Continuar";
    this.confirm.Titulo = "Seguro que desea eliminar el item?";
    const dial = this.dialog.open(ConfirmComponent, ({
      width: '250px',
      data: this.confirm
    }));

    dial.afterClosed().subscribe(res => {
      if (res) {
        this.Lista = this.Lista.filter(items => items !== item);
        this.dataSource = new MatTableDataSource(this.Lista);
        this.Borrar.emit(this.Lista);
      }
    });

  }


  editar(item: SolicitudDetalle) {
    this.Lista = this.Lista.filter(items => items !== item);
    let lista = this.Lista;
    this.dataSource = new MatTableDataSource(this.Lista);
    this.Editar.emit({ lista, item });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
