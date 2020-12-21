using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Application.ViewModel
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int Likes { get; set; }
    }
}
