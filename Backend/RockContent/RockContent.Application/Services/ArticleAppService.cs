using AutoMapper;
using AutoMapper.QueryableExtensions;
using RockContent.Application.Interfaces;
using RockContent.Application.ViewModel;
using RockContent.Domain.Interfaces;
using RockContent.Domain.Models;
using RockContent.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

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

        public int Create(NewArticleViewModel articleViewModel)
        {
            var article = _mapper.Map<Article>(articleViewModel);

            var validator = new ArticleValidate(article);
            validator.ValidateTitle();
            validator.ValidateText();

            _articleRepository.Create(article);
            return article.Id;
        }

        public IEnumerable<ArticleViewModel> GetAll()
        {
            return _articleRepository.GetAll().ProjectTo<ArticleViewModel>(_mapper.ConfigurationProvider);
        }

        public ArticleViewModel GetById(int id)
        {
            return _mapper.Map<ArticleViewModel>(_articleRepository.GetById(id));
        }

        public void Liked(int id)
        {
            var article = _articleRepository.GetById(id);
            var validator = new ArticleValidate(article);
            validator.ValidateId();

            _articleRepository.UpdateLike(id);
        }

        public void Remove(int id)
        {
            var article = _articleRepository.GetById(id);
            var validator = new ArticleValidate(article);
            validator.ValidateId();

            _articleRepository.Remove(id);
        }
    }
}
