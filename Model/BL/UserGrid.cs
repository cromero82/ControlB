using System.Collections.Generic;

namespace Model.BL
{
    public class UserGrid
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName  { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> Roles { get; set; }
    }

    

    public class GenericEntityList
    {
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Aux { get; set; }
    }

    public class AsignacionRolGridVM
    {
        public string UserId { get; set; }
        public string RolId { get; set; }
        public string NombreUsuario { get; set; }
        public List<GenericEntityList> Usuarios { get; set; }
        public List<GenericEntityList> Roles { get; set; }
    }
}
