using RockContent.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Application.Interfaces
{
    public interface IArticleAppService
    {
        public IEnumerable<ArticleViewModel> GetAll();
        public ArticleViewModel GetById(int id);
        public int Create(NewArticleViewModel articleViewModel);
        public void Liked(int id);
        public void Remove(int id);
    }
}
