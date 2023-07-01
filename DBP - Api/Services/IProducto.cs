using DBP___Api.Models;

namespace DBP___Api.Services
{
    public interface IProducto
    {
        IEnumerable<Tbproducto> GetAllProducts();
        IEnumerable<Tbproducto> GetAllProductsHombre();
        IEnumerable<Tbproducto> GetAllProductsMujer();
        Tbproducto GetProducto(int id);

        void add(Tbproducto obj);
        void remove(int id);
        void editDetails(Tbproducto obj);
    }
}
