import { Clientes } from "./Clientes";

export interface Recordatorio {
    recordatorioID: number;
    cliente: Clientes;
    fechaRecordatorio: String;
    observacion: string;
    usuarioID: number;
    completado:boolean;
}
