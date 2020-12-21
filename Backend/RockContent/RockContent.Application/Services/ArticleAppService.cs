using AutoMapper;
using AutoMapper.QueryableExtensions;
using RockContent.Application.Interfaces;
using RockContent.Application.ViewModel;
using RockContent.Domain.Interfaces;
using RockContent.Domain.Models;
using RockContent.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RockContent.Application.Services
{
    public class ArticleAppService : IArticleAppService
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public ArticleAppService(IMapper mapper,
                                 IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<ArticleViewModel>> GetAll()
        {      
            var result = await _articleRepository.GetByAllAsync();
            return result.ProjectTo<ArticleViewModel>(_mapper.ConfigurationProvider);
        }

        public async Task<ArticleViewModel> GetById(Guid id)
        {
            return _mapper.Map<ArticleViewModel>(await _articleRepository.GetByIdAsync(id));
        }

        public async Task<ArticleViewModel> Create(NewArticleViewModel articleViewModel)
        {
            var article = _mapper.Map<Article>(articleViewModel);

            var validator = new ArticleValidate(article);
            validator.ValidateTitle();
            validator.ValidateText();

            await _articleRepository.InsertAsync(article);
            var result = await GetById(article.Id);
            
            return result;
        }

        public async Task<bool> Liked(Guid id)
        {            
            var article = await _articleRepository.GetByIdAsync(id);
            if (article == null)
                return false;

            var validator = new ArticleValidate(article);
            validator.ValidateId();

            article.Likes ++;
            await _articleRepository.UpdateAsync(article);

            return true;
        }

        public async Task<bool> Remove(Guid id)
        {            
            var article = await _articleRepository.GetByIdAsync(id);
            if(article == null)
                return false;

            var validator = new ArticleValidate(article);
            validator.ValidateId();

            await _articleRepository.DeleteAsync(id);

            return true;
        }

    }
}
