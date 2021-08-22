using Microsoft.EntityFrameworkCore;
using TimiPro.Models;

namespace TimiPro.Data.EF
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options): base(options)
        {
        }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Imovel> imovel { get; set; }
        
        
    }
}
