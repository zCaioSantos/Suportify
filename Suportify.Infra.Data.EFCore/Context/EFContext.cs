using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Suportify.Domain.Entities.Autenticacao;
using System.Reflection;


namespace Suportify.Infra.Data.EFCore.Context
{
    public partial class EFContext : DbContext
    {
        private readonly ILoggerFactory MyLoggerFactory;



        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
