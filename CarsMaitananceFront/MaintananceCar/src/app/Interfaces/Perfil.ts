import { ModulosDetalle } from './ModulosDetalle';
import { PefilesRole } from './PefilesRole';
import { PerfilesModulos } from './PerfilesModulos';
export interface Perfil {
    perfilID: number;
    usuarioID: number;
    nombre: string;
    descripcion: string;
    areaID: number;
    area: null;
    pefilesRoles: PefilesRole[];
    perfilModuloDetalle: PerfilesModulos[];
}