using DBP___Api.Models;

namespace DBP___Api.Services
{
    public class MarcasRepository : IMarcas
    {
        private ZapatillasC conexion = new ZapatillasC();
        public void add(Marca obj)
        {
            conexion.Marcas.Add(obj);
            conexion.SaveChanges();
        }

        public void editDetails(Marca obj)
        {
            var objAModificar = (from tdis in conexion.Marcas
                                 where tdis.IdMarca == obj.IdMarca
                                 select tdis).FirstOrDefault();
            
                objAModificar.Descripcion = obj.Descripcion;
        }

        public IEnumerable<Marca> GetAllMarcas()
        {
            return conexion.Marcas;
        }

        public void remove(int id)
        {
            var objEncontrado = (from tdis in conexion.Marcas
                                 where tdis.IdMarca == id
                                 select tdis).Single();
            conexion.Marcas.Remove(objEncontrado);
            conexion.SaveChanges();
        }
    }
}
