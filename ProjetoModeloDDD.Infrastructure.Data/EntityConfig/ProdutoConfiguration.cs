using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infrastructure.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            //Seta campo da tabela como chave-primaria
            HasKey(p => p.ProdutoId);

            //Seta campo da tabela como requerido e com tamanho maximo de 150 caracteres
            Property(p => p.Nome).IsRequired().HasMaxLength(250);

            //Seta campo da tabela como requerido
            Property(p => p.Valor).IsRequired();

            //Seta ForeyKey para tabela Cliente
            HasRequired(p => p.Cliente).WithMany().HasForeignKey(p => p.ClienteId);
        }
    }
}
