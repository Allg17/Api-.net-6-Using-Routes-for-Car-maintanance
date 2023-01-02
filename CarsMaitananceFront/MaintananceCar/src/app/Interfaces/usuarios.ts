import { Rol } from "./Rol";

export interface Usuarios {
    usuarioID: number;
    nombre: string;
    fecha: Date;
    rolID: number;
    user: string;
    clave: string;
    rol: Rol;
}