using DBP___Api.Models;

namespace DBP___Api.Services
{

    public interface IMarcas
    {
        IEnumerable<Marca> GetAllMarcas();

        void add(Marca obj);
        void remove(int id);
        void editDetails(Marca obj);
    }
}
