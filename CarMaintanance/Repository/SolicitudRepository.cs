using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace CarMaintanance.Repository
{
    public class SolicitudRepository : RepositorioBase<Solicitudes>, ISolicitud
    {
        public SolicitudRepository(CarDbContext CarContext) : base(CarContext)
        {
        }

        public List<Solicitudes> GetallSolicitudes()
        {
            return Db.Solicitudes
                .Include(x => x.Cliente)
                .Include(x=>x.Factura)
                .ToList();
        }

        public Solicitudes GetSolicitud(int id)
        {
            return Db.Solicitudes
                .Include(x => x.Cliente)
                .Include(x => x.Detalle)
                .ThenInclude(x => x.Area)
                .FirstOrDefault(x => x.SolicitudID == id);
        }

        public int AddUpdateOrDelete(Solicitudes obj)
        {
            var solicitud = Db.SolicitudesHijas.Where(x => x.SolicitudID == obj.SolicitudID).AsNoTracking().ToList();

            foreach (var item in solicitud)
            {
                if (obj.Detalle.Where(x => x.SolicitudHijaID == item.SolicitudHijaID).Count() == 0)
                    Db.Remove(item);
            }

            if (obj.Detalle.Where(x => x.Completada).Count() == obj.Detalle.Count())
                obj.Completada = true;

            Db.UpdateRange(obj.Detalle.Where(x => x.SolicitudHijaID > 0));
            Db.AddRange(obj.Detalle.Where(x => x.SolicitudHijaID == 0));

            Db.Entry(obj).State = EntityState.Modified;
            return Db.SaveChanges();
        }

        public bool Despachar(int id)
        {
            try
            {
                var solicitud = GetById(id);
                if (solicitud != null)
                {
                    solicitud.Despachada = true;
                    Db.Update(solicitud);
                    return Db.SaveChanges() > 0;
                }
                else
                    return false;
          
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
