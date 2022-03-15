using BlazorServer.Data;
using BlazorServer.Entities;
using BlazorServer.Extensions;
using BlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Services
{
    public class UsuariosServices
    {
        private readonly MiTiendaDbContext _context;

        public UsuariosServices(MiTiendaDbContext context)
        {
            _context = context;           
        }

        public MsgResult Registrar(RegistroUsuarioModel usuario)
        {
            var res = new MsgResult();

            //TODO: Pendiente verificar que no exista otro usuario con el mismo email
            var newUser = _context.Usuarios.Where(u => u.Email == usuario.Email).FirstOrDefault();

            if(newUser != null) // Si el email no es null es porque ya existe
            {
                res.IsSuccess = false;
                res.Message = "Ya existe un usuario con este email";
                return res;
            }

            //TODO: Pendiente validar confirmación de contraseña
            //TODO: Pendiente encriptar clave

            var claveEncriptada = usuario.Clave.Encriptar();

            newUser = new Usuario
            {
                IdRol = usuario.IdRol,
                Email = usuario.Email,
                Clave = claveEncriptada,
                Nombre = usuario.Nombre,
            };

            _context.Usuarios.Add(newUser);

            try
            {
                _context.SaveChanges();

                res.IsSuccess = true;
                res.Message = "Usuario registrado correctamente";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Error al registrar el usuario";
                res.Error = ex;
            }

            return res;
        }

        public MsgResult ValidarEmail(string email)
        {
            var res = new MsgResult();

            var existeEmail = _context.Usuarios.FirstOrDefault(x => x.Email == email);

            if (existeEmail == null)
            {
                res.IsSuccess = false;
            }
            else
            {
                res.IsSuccess = true;
            }

            return res;
        }

        public MsgResult Login(LoginUsuarioModel model)
        {
            var result = new MsgResult();

            var user = _context.Usuarios.FirstOrDefault(x => x.Email == model.Email);

            if(user == null)
            {
                result.IsSuccess = false;
                result.Message = "Usuario NO Existe.";
                return result;
            }

           // TODO: Se válida con el hash y no con la clave
            var passwordHash = model.Password.Encriptar();

            if(user.Clave != passwordHash)
            {
                result.IsSuccess=false;
                result.Message = "Contraseña NO Válida.";
                return result;
            }

            result.IsSuccess = true;
            result.Message = "Acceso concedido";
            return result;
        }
    }
}
