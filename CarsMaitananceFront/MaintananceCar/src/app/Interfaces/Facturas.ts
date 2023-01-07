import { Solicitud } from "./Solicitud";


export interface Facturas {
    facturasID: number;
    fecha: Date;
    solicitudID: number;
    comentario: string;
    completada: boolean;
    usuarioID: number;
    solicitud: Solicitud;
}
