using RockContent.Domain.Interfaces;
using RockContent.Domain.Models;
using RockContent.Infra.Data.Context;

namespace RockContent.Infra.Data.Repository
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(RockContentContext context)
            : base(context)
        {
        }
        
    }
}