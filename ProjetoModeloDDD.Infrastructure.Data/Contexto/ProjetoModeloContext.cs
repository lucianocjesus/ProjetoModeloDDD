using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infrastructure.Data.EntityConfig;

namespace ProjetoModeloDDD.Infrastructure.Data.Contexto
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() : base("ProjetoModeloDDD") { }

        //Seta DBSet para criar tabela no banco
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Removendo algumas converções que não é desejada
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Set Campo da tabela para primaryKey, quando o campo tipo o contexto "Id"
            modelBuilder.Properties().Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            //Set o tipo do campo na tabela, quando não for informado
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Set o tamanho do campo na tabela, quando não for informado
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }

        /// <summary>
        /// Método SaveChanges alterado para setar automaticamente o campo "DataCadastro" da tabela, para não precisar recuperar o mesmo e repassar alteração.
        /// </summary>
        /// <returns>SaveChanges() modificado</returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
