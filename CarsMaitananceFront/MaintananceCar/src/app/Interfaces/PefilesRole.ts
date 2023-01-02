import { Perfil } from "./Perfil";
import { Rol } from './Rol';

export interface PefilesRole {
    id:       number;
    rolID:    number;
    rol:      Rol;
    perfilID: number;
    perfil:   Perfil;
}