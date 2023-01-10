using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CarMaintanance.Model
{
    public class CarDbContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Solicitudes> Solicitudes { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<SolicitudesHijas> SolicitudesHijas { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<Recordatorios> Recordatorios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<PerfilesModulos> PerfilesModulos { get; set; }
        public DbSet<PerfilesRoles> PerfilesRoles { get; set; }
        public DbSet<Modulos> Modulos { get; set; }


        public CarDbContext(DbContextOptions<CarDbContext> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //default Value
            modelBuilder.Entity<SolicitudesHijas>()
            .Property(b => b.FechaCreado)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Solicitudes>()
             .Property(b => b.FechaCreado)
             .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Facturas>()
            .Property(b => b.FechaCreado)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Clientes>()
               .Property(b => b.FechaCreado)
               .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Areas>()
             .Property(b => b.FechaCreado)
             .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Modulos>()
            .Property(b => b.FechaCreado)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Perfiles>()
             .Property(b => b.FechaCreado)
             .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<PerfilesModulos>()
            .Property(b => b.FechaCreado)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<PerfilesRoles>()
           .Property(b => b.FechaCreado)
           .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Recordatorios>()
             .Property(b => b.FechaCreado)
             .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Roles>()
            .Property(b => b.FechaCreado)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Usuarios>()
            .Property(b => b.FechaCreado)
            .HasDefaultValueSql("getdate()");


            //One to Many
            modelBuilder.Entity<SolicitudesHijas>()
                .HasOne<Solicitudes>(x => x.Solicitud)
                .WithMany(x => x.Detalle)
                .HasForeignKey(x => x.SolicitudID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Perfiles>()
             .HasOne<Areas>(s => s.Area)
             .WithMany(ad => ad.Perfil)
             .HasForeignKey(ad => ad.AreaID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Recordatorios>()
             .HasOne<Clientes>(x => x.Cliente)
             .WithMany(x => x.RecordatorioList)
             .HasForeignKey(x => x.ClienteID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Solicitudes>()
              .HasOne<Clientes>(x => x.Cliente)
              .WithMany(x => x.DetalleSolicitud)
              .HasForeignKey(foreignKeyExpression: x => x.ClienteID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SolicitudesHijas>()
            .HasOne<Areas>(x => x.Area)
            .WithMany(x => x.Hijas)
            .HasForeignKey(foreignKeyExpression: x => x.AreaID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usuarios>()
           .HasOne<Roles>(s => s.Rol)
           .WithMany(ad => ad.Usuario)
           .HasForeignKey(ad => ad.RolID).OnDelete(DeleteBehavior.NoAction);

            //Many to many 
            modelBuilder.Entity<PerfilesRoles>()
            .HasOne<Roles>(x => x.Rol)
            .WithMany(x => x.PefilesRoles)
            .HasForeignKey(foreignKeyExpression: x => x.RolID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PerfilesRoles>()
           .HasOne<Perfiles>(x => x.Perfil)
           .WithMany(x => x.PerfilesRoles)
           .HasForeignKey(foreignKeyExpression: x => x.PerfilID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PerfilesModulos>()
            .HasOne<Perfiles>(x => x.Perfil)
            .WithMany(x => x.PerfilModuloDetalle)
            .HasForeignKey(foreignKeyExpression: x => x.PerfilID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PerfilesModulos>()
           .HasOne<Modulos>(x => x.Modulos)
           .WithMany(x => x.PerfilModuloDetalle)
           .HasForeignKey(foreignKeyExpression: x => x.ModuloID).OnDelete(DeleteBehavior.NoAction);

            //One to one

            modelBuilder.Entity<Facturas>()
              .HasOne<Solicitudes>(s => s.Solicitud)
              .WithOne(ad => ad.Factura)
              .HasForeignKey<Facturas>(ad => ad.SolicitudID).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
