using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using LogMiddleware.Api.data.Interface;
using LogMiddleware.Api.Models;
using MySqlConnector;

namespace LogMiddleware.Api.data.Implementation
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly IConfiguration _configuration;

        public Repositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Insert(string query, T obj)
        {
             using (var conn = new MySqlConnection(_configuration.GetConnectionString("Default")))
            {
                return (await conn.ExecuteAsync(query, obj)) >= 1;
            }
        }

        public async Task<T> ObterPorId(string query, object id)
        {
            using (var conn = new MySqlConnection(_configuration.GetConnectionString("Default")))
            {
                return (await conn.QueryAsync<T>(query, id)).FirstOrDefault();
            }
        }

        public async Task<List<T>> ObterTodos(string query)
        {
            using (var conn = new MySqlConnection(_configuration.GetConnectionString("Default")))
            {
                return (await conn.QueryAsync<T>(query)).ToList();
            }
        }

        public async Task<bool> Update(string query, T obj)
        {
            using (var conn = new MySqlConnection(_configuration.GetConnectionString("Default")))
            {
                return (await conn.ExecuteAsync(query, obj)) >= 1;
            }
        }
    }
}