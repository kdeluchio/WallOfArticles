using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static Dapper.SqlMapper;

namespace RockContent.Infra.Data.Interfaces
{
    public interface IRepository : IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IQueryable<T> Query<T>(string sqlCommand, CommandType commandType, DynamicParameters parameters) where T : class;
        IQueryable<T> QueryOneToOne<T, T1>(string sqlCommand, Func<T, T1, T> mapping, CommandType commandType, DynamicParameters parameters, string splitOn) where T : class;
        IQueryable<T> QueryOneToMany<T, T1>(string sqlCommand, CommandType commandType, DynamicParameters parameters, string splitOn) where T : class;
        GridReader Query(string sqlCommand, CommandType commandType, DynamicParameters parameters);
        T QuerySingleOrDefault<T>(string sqlCommand, CommandType commandType, DynamicParameters parameters) where T : class;
        void Execute(string sqlCommand, CommandType commandType, DynamicParameters parameters);
        T ExecuteScalar<T>(string sqlCommand, CommandType commandType, DynamicParameters parameters);

    }
}
