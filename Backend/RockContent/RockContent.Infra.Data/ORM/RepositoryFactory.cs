using Microsoft.Extensions.Configuration;
using RockContent.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RockContent.Infra.Data.ORM
{
    internal static class RepositoryFactory
    {
        public static IRepository Create(string OrmName)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            IRepository repository = null;

            switch (OrmName)
            {
                case "Dapper":
                    repository = new DapperRepository(new SqlConnection(configuration.GetConnectionString("RockContentConn")));
                    break;

                default:
                    break;
            }

            return repository;
        }
    }
}
