using RockContent.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RockContent.Application.Interfaces
{
    public interface IArticleAppService
    {
        Task<IEnumerable<ArticleViewModel>> GetAll();
        Task<ArticleViewModel> GetById(Guid id);
        Task<ArticleViewModel> Create(NewArticleViewModel articleViewModel);
        Task<bool> Liked(Guid id);
        Task<bool> Remove(Guid id);
    }
}
