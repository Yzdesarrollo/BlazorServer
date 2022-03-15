using BlazorServer.Data;
using BlazorServer.Entities;

namespace BlazorServer.Services
{
    public class RolesServices
    {
        private readonly MiTiendaDbContext _context;

        public RolesServices(MiTiendaDbContext context)
        {
            _context = context;
        }

        public List<Rol> ListaRoles()
        {
            var lista = _context.Roles.ToList();

            return lista;
        }
    }
}
