using BlogCore.AccesoDatos.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICartegoriaRepository
    {
        private readonly ApplicationDbContext _db;
        
        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _db.Categoria.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(Categoria categoria)
        {
            var objDesdeBd = _db.Categoria.FirstOrDefault(s => s.Id == categoria.Id);
            objDesdeBd.Nombre = categoria.Nombre;
            objDesdeBd.Orden = categoria.Orden;

            //_db.SaveChanges();
        }

    }
}
