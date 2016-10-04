using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public partial class Maquina
    {
        public void CalcularEstado()
        {
            if (Fallas == 0) Estado = "NORMAL";
            if (Fallas >= 1 && Fallas <= 10) Estado = "IRREGULAR";
            if (Fallas >= 10 && Fallas <= 20) Estado = "ATENCION";
            if (Fallas >= 20) Estado = "MANTENIMIENTO URGENTE";
        }
    }
}
