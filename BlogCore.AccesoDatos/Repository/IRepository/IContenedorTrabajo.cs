using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        //Aqui se declaran los repositorios que se van a utilizar
        ICartegoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        ISliderRepository Slider { get; }
        IUsuarioRepository Usuario { get; }
        void Save(); 


    }
}
