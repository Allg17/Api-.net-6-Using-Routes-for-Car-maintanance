import { Perfil } from './Perfil';
export interface Areas {
    areaID: number;
    fechaCreado: Date;
    usuarioID: number;
    nombre: string;
    detalleArea: null;
    perfil: Perfil;
}
