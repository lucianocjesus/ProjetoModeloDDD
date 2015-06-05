using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    //Interface Produto que herda da Interface Base do tipo "Produto"
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        //Alem do CRUD, implementamos uma pesquisa especial
        IEnumerable<Produto> BuscarPorNomeProdutos(string nome);
    }
}
