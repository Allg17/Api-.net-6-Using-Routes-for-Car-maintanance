import { Areas } from "./Areas";

export interface AreaDetalle {
    areaDetalleID: number;
    fechaCreado: Date;
    solicitudID: number;
    area: Areas;
}
