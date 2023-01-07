using CarMaintanance.Model;

namespace CarMaintanance.Repository.Interfaces
{
    public interface ISolicitud : IBaseRepository<Solicitudes>
    {
       List<Solicitudes> GetallSolicitudes();
        Solicitudes GetSolicitud(int id);
        int AddUpdateOrDelete(Solicitudes solicitudes);
        bool Despachar(int id);
    }
}
