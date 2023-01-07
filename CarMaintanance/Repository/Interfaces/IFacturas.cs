using CarMaintanance.Model;

namespace CarMaintanance.Repository.Interfaces
{
    public interface IFacturas : IBaseRepository<Facturas>
    {
        Facturas GetFactura(int SolicitudID);
        bool CrearFactura(Facturas facturas);
        bool Updatefactura(Facturas facturas);
        List<Facturas> GetAllFacturas();
    }
}
