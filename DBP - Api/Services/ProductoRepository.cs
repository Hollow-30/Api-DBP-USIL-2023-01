using DBP___Api.Models;

namespace DBP___Api.Services
{
    public class ProductoRepository : IProducto
    {

        private ZapatillasC conexion = new ZapatillasC();
        private List<Tbproducto> lstp = new List<Tbproducto>();

        public void add(Tbproducto obj)
        {
            conexion.Tbproductos.Add(obj);
            conexion.SaveChanges();
        }

        public void editDetails(Tbproducto obj)
        {
            var objAModificar = (from tdis in conexion.Tbproductos
                                 where tdis.IdProducto == obj.IdProducto
                                 select tdis).FirstOrDefault();
            
                objAModificar.Nombre = obj.Nombre;
                objAModificar.IdCategoria = obj.IdCategoria;
                objAModificar.IdMarca = obj.IdMarca;
                objAModificar.RutaImagen = obj.RutaImagen;
                objAModificar.Precio = obj.Precio;
                objAModificar.Stock = obj.Stock;
            conexion.SaveChanges();
        }

        public IEnumerable<Tbproducto> GetAllProducts()
        {
            return conexion.Tbproductos;
        }

        public IEnumerable<Tbproducto> GetAllProductsHombre()
        {
            var obj = (from homb in conexion.Tbproductos where homb.IdCategoria == 1 select homb).FirstOrDefault();
            lstp.Add(obj);
            return lstp;
        }

        public IEnumerable<Tbproducto> GetAllProductsMujer()
        {
            var obj = (from mujer in conexion.Tbproductos where mujer.IdCategoria == 2 select mujer).FirstOrDefault();
            lstp.Add(obj);
            return lstp;
        }

        public Tbproducto GetProducto(int id)
        {
            var objEncontrado = (from tpro in conexion.Tbproductos
                                 where tpro.IdProducto == id
                                 select tpro).Single();
            return objEncontrado;
        }

        public void remove(int id)
        {
            var objEncontrado = (from tdis in conexion.Tbproductos
                                 where tdis.IdProducto == id
                                 select tdis).Single();
            conexion.Tbproductos.Remove(objEncontrado);
            conexion.SaveChanges();
        }
    }
}
