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
        public IArea AreaRepository { get; set; }
        public ISolicitud SolicitudesRepository { get ; set ; }

        public MasterRepository(CarDbContext dbContext)
        {
            clientesRepository = new ClientesRepository(dbContext);
            RecordatorioRepository = new RecordatorioRepository(dbContext);
            UsuarioRepository = new UsuarioRepository(dbContext);
            FacturasRepository = new FacturasRepository(dbContext);
            AreaRepository = new AreaRepository(dbContext);
            SolicitudesRepository = new SolicitudRepository(dbContext); 
        }
    }
}
