using Microsoft.EntityFrameworkCore;

namespace CarMaintanance.Model
{
    public class CarDbContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Solicitudes> Solicitudes { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<AreasDetalle> AreasD { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<SolicitudesHijas> SolicitudesHijas { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<Recordatorios> Recordatorios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Areas> Areas { get; set; }


        public CarDbContext(DbContextOptions<CarDbContext> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many
            modelBuilder.Entity<SolicitudesHijas>()
                .HasOne<Solicitudes>(x => x.Solicitud)
                .WithMany(x => x.Detalle)
                .HasForeignKey(x => x.SolicitudID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<SolicitudesHijas>()
               .HasOne<AreasDetalle>(x => x.AreaDetalle)
               .WithMany(x => x.DetalleHijas)
               .HasForeignKey(x => x.AreaDetalleID)
                      .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Recordatorios>()
             .HasOne<Clientes>(x => x.Cliente)
             .WithMany(x => x.RecordatorioList)
             .HasForeignKey(x => x.ClienteID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AreasDetalle>()
             .HasOne<Solicitudes>(x => x.Solicitud)
             .WithMany(x => x.AreaDetalle)
             .HasForeignKey(x => x.SolicitudID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AreasDetalle>()
               .HasOne<Areas>(x => x.Area)
               .WithMany(x => x.DetalleArea)
               .HasForeignKey(foreignKeyExpression: x => x.AreaID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Solicitudes>()
              .HasOne<Clientes>(x => x.Cliente)
              .WithMany(x => x.DetalleSolicitud)
              .HasForeignKey(foreignKeyExpression: x => x.ClienteID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Facturas>()
               .HasOne<Clientes>(x => x.Cliente)
               .WithMany(x => x.DetalleFacturas)
               .HasForeignKey(foreignKeyExpression: x => x.ClienteID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Modulos>()
             .HasOne<Perfiles>(x => x.Perfil)
             .WithMany(x => x.ModulosDetalle)
             .HasForeignKey(foreignKeyExpression: x => x.PerfilID).OnDelete(DeleteBehavior.NoAction);

            //Many to many 
            modelBuilder.Entity<PerfilesRoles>()
            .HasOne<Roles>(x => x.Rol)
            .WithMany(x => x.PefilesRoles)
            .HasForeignKey(foreignKeyExpression: x => x.RolID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PerfilesRoles>()
           .HasOne<Perfiles>(x => x.Perfil)
           .WithMany(x => x.PefilesRoles)
           .HasForeignKey(foreignKeyExpression: x => x.PerfilID).OnDelete(DeleteBehavior.NoAction);

          

            //One to one
            modelBuilder.Entity<Usuarios>()
              .HasOne<Roles>(s => s.Rol)
              .WithOne(ad => ad.Usuario)
              .HasForeignKey<Roles>(ad => ad.UsuarioID).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Facturas>()
              .HasOne<Solicitudes>(s => s.Solicitud)
              .WithOne(ad => ad.Factura)
              .HasForeignKey<Facturas>(ad => ad.SolicitudID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Perfiles>()
             .HasOne<Areas>(s => s.Area)
             .WithOne(ad => ad.Perfil)
             .HasForeignKey<Perfiles>(ad => ad.AreaID).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
