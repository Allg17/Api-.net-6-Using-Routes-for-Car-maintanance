import { PefilesRole } from "./PefilesRole";
import { Usuarios } from './usuarios';

export interface Rol {
    rolID: number;
    fecha: Date;
    usuarioID: number;
    nombre: string;
    descripcion: string;
    usuario: Usuarios;
    pefilesRoles: PefilesRole[];
}
