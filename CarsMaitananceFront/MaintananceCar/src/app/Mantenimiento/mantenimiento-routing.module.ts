import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { SolicitudComponent } from './pages/solicitud/solicitud.component';
import { ConsultaMantComponent } from './pages/consulta-mant/consulta-mant.component';
import { RegistroComponent } from './pages/registro/registro.component';
import { ConsultaSolicitudComponent } from './pages/consulta-solicitud/consulta-solicitud.component';
import { FacturacionComponent } from './pages/facturacion/facturacion.component';
import { DespachoComponent } from './pages/despacho/despacho.component';
import { RecordatorioComponent } from './pages/recordatorio/recordatorio.component';
import { AuthGuard } from '.././auth/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: 'solicitud',
        component: SolicitudComponent,
        canLoad: [AuthGuard],
        canActivate:[AuthGuard]
      },
      {
        path: 'consultarmantenimiento',
        component: ConsultaMantComponent,
        canLoad: [AuthGuard],
        canActivate:[AuthGuard]
      },
      {
        path: 'registro',
        component: RegistroComponent,
        canLoad: [AuthGuard],
        canActivate:[AuthGuard]
      },
      {
        path: 'consultarSolicitud',
        component: ConsultaSolicitudComponent,
        canLoad: [AuthGuard],
        canActivate:[AuthGuard]
      },
      {
        path: 'facturacion',
        component: FacturacionComponent,
        canLoad: [AuthGuard],
        canActivate:[AuthGuard]
      },
      {
        path: 'despacho',
        component: DespachoComponent,
        canLoad: [AuthGuard],
        canActivate:[AuthGuard]
      },
      {
        path: 'recordatorio',
        component: RecordatorioComponent
      },
      {
        path: '**',
        redirectTo: '../404'
      }
    ]
  }
];


@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MantenimientoRoutingModule { }
