import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MantenimientoRoutingModule } from './mantenimiento-routing.module';
import { SolicitudComponent } from './pages/solicitud/solicitud.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from '../material/material.module';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './pages/home/home.component';
import { ConsultaMantComponent } from './pages/consulta-mant/consulta-mant.component';
import { RegistroComponent } from './pages/registro/registro.component';
import { ConsultaSolicitudComponent } from './pages/consulta-solicitud/consulta-solicitud.component';
import { FacturacionComponent } from './pages/facturacion/facturacion.component';
import { DespachoComponent } from './pages/despacho/despacho.component';
import { RecordatorioComponent } from './pages/recordatorio/recordatorio.component';
import { AgregarClienteComponent } from './componentes/agregar-cliente/agregar-cliente.component';
import { TextMaskModule } from 'angular2-text-mask';
@NgModule({
  declarations: [
    SolicitudComponent,
    HomeComponent,
    ConsultaMantComponent,
    RegistroComponent,
    ConsultaSolicitudComponent,
    FacturacionComponent,
    DespachoComponent,
    RecordatorioComponent,
    AgregarClienteComponent
  ],
  imports: [
    CommonModule,
    MantenimientoRoutingModule,
    FlexLayoutModule,
    MaterialModule,
    FormsModule,
    TextMaskModule
  ]
})
export class MantenimientoModule { }
