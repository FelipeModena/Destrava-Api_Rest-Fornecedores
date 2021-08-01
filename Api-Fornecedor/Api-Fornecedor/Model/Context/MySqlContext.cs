using Api_Fornecedor.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiRestComASPNet.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        { }


        protected override void
            OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FornecedorEmpresas>()
                .HasKey(x => new { x.FornecedorId, x.EmpresaId});
        }

        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<LogDesenvolvedor> LogDesenvolvedor { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
    }
}
