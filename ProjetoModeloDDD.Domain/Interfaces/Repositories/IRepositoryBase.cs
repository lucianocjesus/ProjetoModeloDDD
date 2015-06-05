using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    /*Não sabemos de que entidade iremos tratar, então cria-se como interface generica de TEntity
      e trata ela como classe*/
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //Criar os metotos padrões CRUD
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
