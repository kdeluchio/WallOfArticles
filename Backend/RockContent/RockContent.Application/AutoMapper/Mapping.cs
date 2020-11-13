using AutoMapper;
using RockContent.Application.ViewModel;
using RockContent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Application.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            DomainToView();
            ViewToDomain();
        }

        private void DomainToView()
        {
            CreateMap<Article, ArticleViewModel>();
        }

        private void ViewToDomain()
        {
            CreateMap<ArticleViewModel, Article>();
            CreateMap<NewArticleViewModel, Article>();
        }
    }
}
