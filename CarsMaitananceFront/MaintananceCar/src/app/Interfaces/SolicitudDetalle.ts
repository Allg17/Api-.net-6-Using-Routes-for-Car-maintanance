import { AreaDetalle } from "./AreaDetalle";
import { Areas } from "./Areas";

export interface SolicitudDetalle {
    solicitudHijaID: number;
    solicitudID: number;
    fechaCreado: Date;
    usuarioID: number;
    precio: number;
    nombre: string;
    descripcion: string;
    area: Areas;
    completada: boolean;
    facturada: boolean;
    areaID: number;
}


