using BlogCore.AccesoDatos.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Repository
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _db;
        
        public ArticuloRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Articulo articulo)
        {
            var objDesdeBd = _db.Articulo.FirstOrDefault(s => s.Id == articulo.Id);
            objDesdeBd.Nombre = articulo.Nombre;
            objDesdeBd.Descripcion = articulo.Descripcion;
            objDesdeBd.urlImagen = articulo.urlImagen;
            objDesdeBd.CategoriaId = articulo.CategoriaId;

            _db.SaveChanges();
        }

    }
}
