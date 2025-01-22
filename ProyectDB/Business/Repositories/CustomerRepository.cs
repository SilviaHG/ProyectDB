using Microsoft.EntityFrameworkCore;
using ProyectDB.Business.Interfaces;
using ProyectDB.Data;
using ProyectDB.Data.Models;

namespace ProyectDB.Business.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            //validar que no se repita
            if(await isUnique(customer.Id))
            {
                //agregar un cliente
                _context.customers.Add(customer);
                //guardo cambios
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> isUnique(int id)
        {
            return !await _context.customers.AnyAsync(p => p.Id == id);
        }


        public async Task DeleteCustomerAsync(int id)
        {
            //elimina el cliente
            var customer = await _context.customers.FindAsync(id);
            if (customer != null)
            {
                _context.customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
                
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            //mostrar todos los clientes por lista
            return await _context.customers.ToListAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            //actualiza el cliente
            _context.customers.Update(customer);
            //guardo los cambios
            await _context.SaveChangesAsync();
        }
    }
}
