using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;

namespace ProjetoModeloDDD.Infrastructure.Data.Repositories
{
    //Herda do meu RepositórioBase e Implementa da minha Interface Cliente
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        //Tudo que eu preciso aqui (CRUD), já esta sendo feito da minha herança Base. Se eu quiser algo especifico eu crio.
    }
}
