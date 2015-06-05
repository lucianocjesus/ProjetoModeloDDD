using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infrastructure.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            //Utilizando o Fluent API para mapear os compartamentos do meu dominio (Domain), para ser modelado como uma tabela do meu banco de dados.

            //Seta campo da tabela como chave-primaria
            HasKey(c => c.ClienteId);

            //Seta campo da tabela como requerido e com tamanho maximo de 150 caracteres
            Property(c => c.Nome).IsRequired().HasMaxLength(150);

            //Seta campo da tabela como requerido e com tamanho maximo de 150 caracteres
            Property(c => c.Sobrenome).IsRequired().HasMaxLength(150);

            //Seta campo da tabela como requerido
            Property(c => c.Email).IsRequired();
        }
    }
}
