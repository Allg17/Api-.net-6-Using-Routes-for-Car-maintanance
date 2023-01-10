import { SolicitudDetalle } from "./SolicitudDetalle";
import { Clientes } from './Clientes';

export interface Solicitud {
    solicitudID: number;
    fechaCreado: Date;
    usuarioID: number;
    descripcion: string;
    completada: boolean;
    facturada: boolean;
    clienteID: number;
    despachada:boolean;
    detalle: SolicitudDetalle[];
    cliente: Clientes;
}