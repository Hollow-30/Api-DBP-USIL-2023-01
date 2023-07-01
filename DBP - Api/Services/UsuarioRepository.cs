using DBP___Api.Models;

namespace DBP___Api.Services
{
    public class UsuarioRepository : IUsuario
    {
        private ZapatillasC conexion = new ZapatillasC();
        public void add(Cliente obj)
        {
            conexion.Clientes.Add(obj);
            conexion.SaveChanges();
        }

        public void editDetails(Cliente obj)
        {
            var objAModificar = (from tdis in conexion.Clientes
                                 where tdis.IdCliente == obj.IdCliente
                                 select tdis).FirstOrDefault();
            
                objAModificar.Nombre = obj.Nombre;
                objAModificar.Apellidos = obj.Apellidos;
                objAModificar.Correo = obj.Correo;
                objAModificar.Clave = obj.Clave;

            conexion.SaveChanges();
        }

        public IEnumerable<Cliente> GetAllUser()
        {
            return conexion.Clientes;
        }

        public void remove(int id)
        {
            var objEncontrado = (from tdis in conexion.Clientes
                                 where tdis.IdCliente == id
                                 select tdis).Single();
            conexion.Clientes.Remove(objEncontrado);
            conexion.SaveChanges();
        }

    }
}
