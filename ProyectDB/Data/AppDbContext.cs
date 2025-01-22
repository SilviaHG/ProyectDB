using Microsoft.EntityFrameworkCore;
using ProyectDB.Data.Models;

namespace ProyectDB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
          //inyecciona de dependencias de nuestra BD

        }
        // va acceder a nuestra clase que estan en la carpeta models
        public DbSet<Customer> customers {  get; set; } 
    }
}
