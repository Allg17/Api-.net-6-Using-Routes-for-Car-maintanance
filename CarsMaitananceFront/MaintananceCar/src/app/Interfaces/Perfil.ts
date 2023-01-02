import { ModulosDetalle } from './ModulosDetalle';
import { PefilesRole } from './PefilesRole';
export interface Perfil {
    perfilID:       number;
    usuarioID:      number;
    nombre:         string;
    descripcion:    string;
    areaID:         number;
    area:           null;
    pefilesRoles:   PefilesRole[];
    modulosDetalle: ModulosDetalle[];
}