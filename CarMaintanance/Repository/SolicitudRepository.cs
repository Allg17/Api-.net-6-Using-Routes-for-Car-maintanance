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
           return Db.Solicitudes.
                         Select(lista => new Solicitudes
                         {
                             Cliente = lista.Cliente,

                             Detalle = lista.Detalle.Select(x => new SolicitudesHijas
                             {
                                 Area = x.Area,
                                 Descripcion = x.Descripcion,
                                 AreaID = x.AreaID,
                                 Completada = x.Completada,
                                 Facturada = x.Facturada,
                                 FechaCreado = x.FechaCreado,
                                 Nombre = x.Nombre,
                                 Precio = x.Precio,
                                 Solicitud = x.Solicitud,
                                 SolicitudHijaID = x.SolicitudHijaID,
                                 SolicitudID = x.SolicitudID,
                                 UsuarioID = x.UsuarioID

                             }).ToList(),
                             SolicitudID = lista.SolicitudID,
                             ClienteID = lista.ClienteID,
                             Completada = lista.Completada,
                             Descripcion = lista.Descripcion,
                             Despachada = lista.Despachada,
                             Factura = lista.Factura,
                             Facturada = lista.Facturada,
                             FacturasID = lista.FacturasID,
                             FechaCreado = lista.FechaCreado,
                             UsuarioID = lista.UsuarioID
                         }).ToList();
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
            else
                obj.Completada = false;


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

        public List<Solicitudes> GetSolicitudesByArea(int AreaId)
        {
            var result = Db.Solicitudes
                         .Where(x => x.Detalle.Where(y => y.AreaID == AreaId).Count() > 0).
                         Select(lista => new Solicitudes
                         {
                             Cliente = lista.Cliente,

                             Detalle = lista.Detalle.Where(y=>y.AreaID ==AreaId).Select(x => new SolicitudesHijas
                             {
                                 Area = x.Area,
                                 Descripcion = x.Descripcion,
                                 AreaID = x.AreaID,
                                 Completada = x.Completada,
                                 Facturada = x.Facturada,
                                 FechaCreado = x.FechaCreado,
                                 Nombre = x.Nombre,
                                 Precio = x.Precio,
                                 Solicitud = x.Solicitud,
                                 SolicitudHijaID = x.SolicitudHijaID,
                                 SolicitudID = x.SolicitudID,
                                 UsuarioID = x.UsuarioID

                             }).ToList(),
                             SolicitudID = lista.SolicitudID,
                             ClienteID = lista.ClienteID,
                             Completada = lista.Completada,
                             Descripcion = lista.Descripcion,
                             Despachada = lista.Despachada,
                             Factura = lista.Factura,
                             Facturada = lista.Facturada,
                             FacturasID = lista.FacturasID,
                             FechaCreado = lista.FechaCreado,
                             UsuarioID = lista.UsuarioID
                         }).ToList();



            return result;
        }

        public Solicitudes GetSolicitudByArea(int SolicitudId, string areaId)
        {

            var areaid = areaId.Split('-');

            return Db.Solicitudes
                             .Where(x => x.Detalle.Where(y => y.SolicitudID == SolicitudId).Count() > 0).
                             Select(lista => new Solicitudes
                             {
                                 Cliente = lista.Cliente,

                                 Detalle = lista.Detalle.Where(y => areaid.Contains(y.AreaID.ToString())).Select(x => new SolicitudesHijas
                                 {
                                     Area = x.Area,
                                     Descripcion = x.Descripcion,
                                     AreaID = x.AreaID,
                                     Completada = x.Completada,
                                     Facturada = x.Facturada,
                                     FechaCreado = x.FechaCreado,
                                     Nombre = x.Nombre,
                                     Precio = x.Precio,
                                     Solicitud = x.Solicitud,
                                     SolicitudHijaID = x.SolicitudHijaID,
                                     SolicitudID = x.SolicitudID,
                                     UsuarioID = x.UsuarioID

                                 }).ToList(),
                                 SolicitudID = lista.SolicitudID,
                                 ClienteID = lista.ClienteID,
                                 Completada = lista.Completada,
                                 Descripcion = lista.Descripcion,
                                 Despachada = lista.Despachada,
                                 Factura = lista.Factura,
                                 Facturada = lista.Facturada,
                                 FacturasID = lista.FacturasID,
                                 FechaCreado = lista.FechaCreado,
                                 UsuarioID = lista.UsuarioID
                             }).SingleOrDefault();
        }
    }
}
