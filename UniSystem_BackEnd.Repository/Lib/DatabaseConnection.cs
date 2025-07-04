using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace UniSystem_BackEnd.Repository.Lib
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection()
        {
            _connectionString = "User ID=postgres;Password=Jvs_915477!!;Host=localhost;Port=5432;Database=unisystem_backend;Pooling=true;";
        }

        public void ExecuteQuery(string sql, object? param = null)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sql, param);
            }
        }

        public T QueryFirstOrDefault<T>(string sql, object? param = null)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, param);
            }
        }

        public IEnumerable<T> Query<T>(string sql, object? param = null)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<T>(sql, param);
            }
        }
    }
}
