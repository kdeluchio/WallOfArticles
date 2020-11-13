using RockContent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockContent.Domain.Interfaces
{
    public interface IArticleRepository
    {
        public IQueryable<Article> GetAll();
        public Article GetById(int id);
        public void Create(Article article);
        public void UpdateLike(int id);
        public void Remove(int id);
    }
}
