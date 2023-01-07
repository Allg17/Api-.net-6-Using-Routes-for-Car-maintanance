using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarMaintanance.Repository
{
    public class FacturasRepository : RepositorioBase<Facturas>, IFacturas
    {
        public FacturasRepository(CarDbContext CarContext) : base(CarContext)
        {
          
        }

        public bool CrearFactura(Facturas facturas)
        {
            facturas.Solicitud.Facturada = facturas.Completada = facturas.Solicitud.Detalle.Where(x => x.Facturada).Count() == facturas.Solicitud.Detalle.Count() ? true : false;
            facturas.Solicitud.Detalle.ForEach(x => x.Area = null);


            Db.Entry(facturas).State = EntityState.Added;
            var res = Db.SaveChanges();

            facturas.Solicitud.FacturasID = facturas.FacturasID;
            Db.Entry(facturas.Solicitud).State = EntityState.Modified;
            Db.UpdateRange(facturas.Solicitud.Detalle);
            res = Db.SaveChanges();
            return res > 0;
        }

        public List<Facturas> GetAllFacturas()
        {
            return Db.Facturas
                 .Include(x => x.Solicitud)
                 .ThenInclude(x => x.Cliente)
                 .Include(x => x.Solicitud)
                 .ThenInclude(x => x.Detalle).ToList();


        }

        public Facturas GetFactura(int FacturaID)
        {
            return Db.Facturas
                 .Include(x => x.Solicitud)
                 .ThenInclude(x => x.Cliente)
                 .Include(x => x.Solicitud)
                 .ThenInclude(x => x.Detalle)
                 .ThenInclude(x=>x.Area)
                 .FirstOrDefault(x => x.FacturasID == FacturaID);
        }

        public bool Updatefactura(Facturas facturas)
        {

            facturas.Solicitud.Facturada = facturas.Completada = facturas.Solicitud.Detalle.Where(x => x.Facturada).Count() == facturas.Solicitud.Detalle.Count() ? true : false;
            facturas.Solicitud.Detalle.ForEach(x => x.Area = null);

            Db.Entry(facturas).State = EntityState.Modified;
            Db.Entry(facturas.Solicitud).State = EntityState.Modified;
            Db.UpdateRange(facturas.Solicitud.Detalle);
            var res = Db.SaveChanges();
            return res > 0;
        }
    }
}
