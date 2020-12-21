﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Domain.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public int Likes { get; set; }

    }
}
