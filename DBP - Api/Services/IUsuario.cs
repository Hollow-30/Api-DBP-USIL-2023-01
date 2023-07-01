using DBP___Api.Models;

namespace DBP___Api.Services
{
    public interface IUsuario
    {
        IEnumerable<Cliente> GetAllUser();

        void add(Cliente obj);
        void remove(int id);
        void editDetails(Cliente obj);

    }
}
