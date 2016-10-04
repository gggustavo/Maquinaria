using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public partial class Maquina
    {
        public int IdMaquinaria { get; set; }
        public int NroInventario { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime Anio { get; set; }
        public int Fallas { get; set; }
        public string Estado { get; set; }      
    }
}
