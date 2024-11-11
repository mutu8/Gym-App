using BlogCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Repository.IRepository
{
    public interface ICartegoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);

        IEnumerable<SelectListItem> GetListaCategorias();
    }
}
