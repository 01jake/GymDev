using GymDev.Shared.Modelos;
using Microsoft.EntityFrameworkCore;
namespace GymDev.Date
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Entrenador> Entrenadores{ get; set; }


    }
}
