namespace CarMaintanance.Repository.Interfaces
{
    public interface IMasterRepository
    {
        IClientesRepository clientesRepository { get; set; }
        IRecordatorio RecordatorioRepository { get; set; }
        IFacturas FacturasRepository { get; set; }
        IUsuarios UsuarioRepository { get; set; }
    }
}
