import { Perfil } from './Perfil';
export interface Areas {
    areaID: number;
    fecha: Date;
    usuarioID: number;
    nombre: string;
    detalleArea: null;
    perfil: Perfil;
}
