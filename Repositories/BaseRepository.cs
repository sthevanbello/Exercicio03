using Exercicio02.Data;
using Exercicio02.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio02.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly Mais_EventosContext _context;

        public BaseRepository(Mais_EventosContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public T Inserir(T item)
        {
            var retorno = _dbSet.Add(item);
            _context.SaveChanges();
            return retorno.Entity;
        }
        /// <summary>
        /// Exibir todos os itens
        /// </summary>
        /// <returns>List com todos os itens</returns>
        public ICollection<T> ListarTodos()
        {
            var query = _dbSet.AsQueryable();

            return query.ToList();

        }
        public T BuscarPorId(int id)
        {
            return _dbSet.FindAsync(id).Result;
        }
        public void Alterar(T item)
        {
            //_context.Entry(item).State = EntityState.Modified;
            _dbSet.Update(item);
            _context.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchItem, T item)
        {
            patchItem.ApplyTo(item);
            //_context.Entry(item).State = EntityState.Modified;
            _context.Update(item);
            _context.SaveChanges();
        }
        public void Excluir(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}
