using CarMaintanance.Model;

namespace CarMaintanance.Repository.Interfaces
{
    public interface ISolicitud : IBaseRepository<Solicitudes>
    {
        List<Solicitudes> GetallSolicitudes();
        List<Solicitudes> GetSolicitudesByArea(int areaId);
        Solicitudes GetSolicitudByArea(int SolicitudId,string areaId);
        Solicitudes GetSolicitud(int id);
        int AddUpdateOrDelete(Solicitudes solicitudes);
        bool Despachar(int id);
    }
}
