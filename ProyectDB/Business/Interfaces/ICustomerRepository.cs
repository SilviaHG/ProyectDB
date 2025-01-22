using ProyectDB.Data.Models;

namespace ProyectDB.Business.Interfaces
{
    //se crea las tareas para hacer el CRUD
    public interface ICustomerRepository
    {
        //metodo que va devolver todas los clientes
        Task<IEnumerable<Customer>> GetCustomersAsync();
        //bucar por id
        Task<Customer> GetCustomerByIdAsync(int id);
        //metodo para agregar, no estoy esperando un listado por eso no van las flechas
        Task<bool> AddCustomerAsync(Customer customer);

        //metodo para actualizar, no estoy esperando un listado por eso no van las flechas
        Task UpdateCustomerAsync(Customer customer);
        //metodo para eliminar, no estoy esperando un listado por eso no van las flechas
        Task DeleteCustomerAsync(int id);
        //verificar si existe
        Task<bool> isUnique(int id);

    }
}
