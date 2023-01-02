import { Perfil } from './Perfil';

export interface ModulosDetalle {
    moduloId:     number;
    fecha:        Date;
    usuarioID:    number;
    nombre:       string;
    descripcion:  string;
    crear_Editar: boolean;
    eliminar:     boolean;
    ver:          boolean;
    perfilID:     number;
    perfil:       Perfil;
}
