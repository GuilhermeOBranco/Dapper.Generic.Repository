using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogMiddleware.Api.data.Interface
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> ObterPorId(string query, object id);
        Task<List<T>> ObterTodos(string query);
        Task<bool> Update(string query, T obj);
        Task<bool> Insert(string query, T obj);

    }
}