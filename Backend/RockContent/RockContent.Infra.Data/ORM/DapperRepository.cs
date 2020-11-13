using Dapper;
using RockContent.Infra.Data.Interfaces;
using Slapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static Dapper.SqlMapper;

namespace RockContent.Infra.Data.ORM
{
    internal class DapperRepository : IRepository
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public DapperRepository(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }

        public void BeginTransaction()
        {
            if (_connection != null)
            {
                _transaction = _connection.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }

        public IQueryable<T> Query<T>(string sqlCommand, CommandType commandType, DynamicParameters parameters) where T : class
        {
            return _connection.Query<T>(sqlCommand, commandType: commandType, param: parameters, transaction: _transaction, commandTimeout: 120).AsQueryable();
        }

        public IQueryable<T> QueryOneToOne<T, T1>(string sqlCommand, Func<T, T1, T> mapping, CommandType commandType, DynamicParameters parameters, string splitOn) where T : class

        {
            return _connection.Query<T, T1, T>(sqlCommand
                                  , map: mapping
                                  , commandType: commandType
                                  , param: parameters
                                  , transaction: _transaction
                                  , commandTimeout: 120
                                  , splitOn: splitOn).AsQueryable();

        }

        public IQueryable<T> QueryOneToMany<T, T1>(string sqlCommand, CommandType commandType, DynamicParameters parameters, string splitOn) where T : class
        {
            var result = _connection.Query<dynamic>(sqlCommand
                                                   , commandType: commandType
                                                   , param: parameters
                                                   , transaction: _transaction
                                                   , commandTimeout: 120);

            var identifier = splitOn.Split(",");
            if (identifier == null || identifier.Length <= 1)
                return null;

            AutoMapper.Configuration.AddIdentifier(typeof(T), identifier[0]);
            AutoMapper.Configuration.AddIdentifier(typeof(T1), identifier[1]);

            return (AutoMapper.MapDynamic<T>(result) as IEnumerable<T>).AsQueryable();
        }

        public T QuerySingleOrDefault<T>(string sqlCommand, CommandType commandType, DynamicParameters parameters) where T : class
        {
            return _connection.QuerySingleOrDefault<T>(sqlCommand, commandType: commandType, param: parameters, transaction: _transaction, commandTimeout: 120);
        }

        public GridReader Query(string sqlCommand, CommandType commandType, DynamicParameters parameters)
        {
            return _connection.QueryMultiple(sqlCommand, commandType: commandType, param: parameters, transaction: _transaction, commandTimeout: 120);
        }

        public void Execute(string sqlCommand, CommandType commandType, DynamicParameters parameters)
        {
            _connection.Execute(sqlCommand, param: parameters, transaction: _transaction, commandType: commandType, commandTimeout: 120);
        }

        public T ExecuteScalar<T>(string sqlCommand, CommandType commandType, DynamicParameters parameters)
        {
            return _connection.ExecuteScalar<T>(sqlCommand, param: parameters, transaction: _transaction, commandType: commandType, commandTimeout: 120);
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();

                _connection.Dispose();
                _connection = null;
            }

            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    
    }
}
