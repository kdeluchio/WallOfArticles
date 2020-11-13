using Dapper;
using Newtonsoft.Json;
using RockContent.Domain.Interfaces;
using RockContent.Domain.Models;
using RockContent.Infra.Data.ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RockContent.Infra.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public void Create(Article article)
        {
            using (var context = RepositoryFactory.Create("Dapper"))
            {
                try
                {
                    context.BeginTransaction();

                    DynamicParameters p = new DynamicParameters();
                    p.Add("@Title", article.Title, DbType.String, ParameterDirection.Input);
                    p.Add("@Text", article.Text, DbType.String, ParameterDirection.Input);

                    article.Id = context.ExecuteScalar<int>("CreateArticle", CommandType.StoredProcedure, p);

                    context.CommitTransaction();
                }
                catch (Exception ex)
                {
                    context.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public IQueryable<Article> GetAll()
        {
            using (var context = RepositoryFactory.Create("Dapper"))
            {
                return context.Query<Article>("GetArticle"
                                               , CommandType.StoredProcedure
                                               , null);
            }
        }

        public Article GetById(int id)
        {
            using (var context = RepositoryFactory.Create("Dapper"))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

                if (id <= 0)
                    return new Article();

                return context.QuerySingleOrDefault<Article>("GetArticle"
                                                         , CommandType.StoredProcedure
                                                         , p);
            }
        }

        public void Remove(int id)
        {
            using (var context = RepositoryFactory.Create("Dapper"))
            {
                try
                {
                    context.BeginTransaction();

                    DynamicParameters p = new DynamicParameters();
                    p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

                    context.Execute("RemoveArticle", CommandType.StoredProcedure, p);

                    context.CommitTransaction();
                }
                catch (Exception ex)
                {
                    context.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public void UpdateLike(int id)
        {
            using (var context = RepositoryFactory.Create("Dapper"))
            {
                try
                {
                    context.BeginTransaction();

                    DynamicParameters p = new DynamicParameters();
                    p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

                    context.Execute("LikedArticle", CommandType.StoredProcedure, p);

                    context.CommitTransaction();
                }
                catch (Exception ex)
                {
                    context.RollbackTransaction();
                    throw ex;
                }
            }
        }
    
    }
}
