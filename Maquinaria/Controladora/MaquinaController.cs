using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class MaquinaController
    {
        public void AgregarMaquina(Modelo.Maquina maquina)
        {
            var context = Modelo.SingletonContext.GetContext();
            context.Maquinas.Add(maquina);
            context.SaveChanges();
        }

        public void EliminarMaquina(Modelo.Maquina maquina)
        {
            var context = Modelo.SingletonContext.GetContext();
            var entity = context.Maquinas.Find(maquina.IdMaquinaria);
            context.Maquinas.Remove(entity);
            context.SaveChanges();
        }

        public void ActualizarMaquina(Modelo.Maquina maquina)
        {
            var context = Modelo.SingletonContext.GetContext();
            context.Entry(maquina).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public IList<Modelo.Maquina> ObtenerMaquinas()
        {
            var context = Modelo.SingletonContext.GetContext();
            return context.Maquinas.ToList();
        }


    }
}
