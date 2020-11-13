using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int Likes { get; set; }

    }
}
