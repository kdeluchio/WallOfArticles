using RockContent.Domain.Interfaces;
using RockContent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Domain.Validations
{
    public class ArticleValidate : IArticleValidate
    {
        private readonly Article _article;

        public ArticleValidate(Article article)
        {
            _article = article;
        }

        public void ValidateId()
        {
            ValidateModel();

            if (_article.Id <=0)
            {
                throw new Exception("Id is required.");
            }
        }

        public void ValidateText()
        {
            ValidateModel();

            if (string.IsNullOrEmpty(_article.Title))
            {
                throw new Exception("Title is required.");
            }
        }

        public void ValidateTitle()
        {
            ValidateModel();

            if (string.IsNullOrEmpty(_article.Text))
            {
                throw new Exception("Text is required.");
            }
        }
    
        private void ValidateModel()
        {
            if (_article == null)
            {
                throw new Exception("Article is not found.");
            }
        }
    }
}
