namespace CarMaintanance.Model
{
    public class PerfilesRoles
    {
        public int ID { get; set; }
        public int RolID { get; set; }
        public virtual Roles Rol { get; set; }
        public int PerfilID { get; set; }
        public virtual Perfiles Perfil { get; set; }
    }
}
