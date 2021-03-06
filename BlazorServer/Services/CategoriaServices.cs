using BlazorServer.Data;
using BlazorServer.Entities;
using BlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Services
{
    public class CategoriaServices
    {
        private readonly MiTiendaDbContext _context;

        public CategoriaServices(MiTiendaDbContext context)
        {
            _context = context;
        }

        public List<CategoriaModel> ListaCategorias()
        {
            var query = _context.Categorias
                .Include(x => x.Productos)
                .ToList();

            var lista = query.Select(x => new CategoriaModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                CantidadProductos = x.Productos.Count,
            }).ToList();

            return lista;

        }

        public CategoriaModel Categoria(int idCategoria)
        {
            var query = _context.Categorias
                .Include(x => x.Productos)
                .Where(x => x.Id == idCategoria)
                .ToList();

            var model = query.Select(x => new CategoriaModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                CantidadProductos = x.Productos.Count,

            }).FirstOrDefault();

            return model;
        }

        public MsgResult Crear(CategoriaModel model)
        {
            var res = new MsgResult();

            var entity = new Categoria
            {
                Nombre = model.Nombre,
            };

            _context.Categorias.Add(entity);

            try
            {
                _context.SaveChanges();

                res.IsSuccess = true;
                res.Message = "Categoria creada correctamente";
                res.Code = entity.Id;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Error al registrar la categoria";
                res.Error = ex;
            }

            return res;
        }

        public MsgResult Modificar(CategoriaModel model)
        {

            var res = new MsgResult();

            var entity = _context.Categorias.FirstOrDefault(x => x.Id == model.Id);

            if (entity == null)
            {
                res.IsSuccess = false;
                res.Message = "No se puede modificar la categoria solicitada porque no existe";
                return res;
            }

            entity.Nombre = model.Nombre;


            try
            {
                _context.SaveChanges();

                res.IsSuccess = true;
                res.Message = "Categoria modificada correctamente";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Error al modificar la categoria";
                res.Error = ex;
            }

            return res;
        }

        public MsgResult Eliminar(int idCategoria)
        {
            var res = new MsgResult();

            var entity = _context.Categorias
                .Include(x => x.Productos)
                .FirstOrDefault(x => x.Id == idCategoria);

            if (entity == null)
            {
                res.IsSuccess = false;
                res.Message = "No se puede eliminar la categoria solicitada porque no existe";
                res.Code = -1; // Porque se tiene dos posibles respuestas con false
                return res;
            }

            if (entity.Productos.Count > 0)
            {
                res.IsSuccess = false;
                res.Message = "No se puede eliminar la categoria solicitada porque tiene productos relacionados. " +
                    "Elimine primero los prodcutos para poder eliminar la categoría";
                res.Code = -2;
                return res;
            }


            _context.Categorias.Remove(entity);

            try
            {
                _context.SaveChanges();

                res.IsSuccess = true;
                res.Message = "Categoria eliminada correctamente";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Error al eliminar la categoria";
                res.Error = ex;
            }

            return res;
        }
    }
}
