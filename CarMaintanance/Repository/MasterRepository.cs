using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;

namespace CarMaintanance.Repository
{
    public class MasterRepository : IMasterRepository
    {
        public IClientesRepository clientesRepository { get; set; }
        public IRecordatorio RecordatorioRepository { get; set ; }
        public IFacturas FacturasRepository { get ; set ; }
        public IUsuarios UsuarioRepository { get; set ; }

        public MasterRepository(CarDbContext dbContext)
        {
            clientesRepository = new ClientesRepository(dbContext);
            RecordatorioRepository = new RecordatorioRepository(dbContext);
            UsuarioRepository = new UsuarioRepository(dbContext);
            FacturasRepository = new FacturasRepository(dbContext); 
        }
    }
}
