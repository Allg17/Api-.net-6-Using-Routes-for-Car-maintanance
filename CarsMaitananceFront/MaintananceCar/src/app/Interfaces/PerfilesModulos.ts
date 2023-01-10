import { Perfil } from "./Perfil";
import { ModulosDetalle } from './ModulosDetalle';

export interface PerfilesModulos {
    iD: number;
    moduloID: number;
    modulos: ModulosDetalle;
    perfil: Perfil;
    perfilID: number;
}
