using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.Domain.Interfaces
{
    public interface IArticleValidate
    {
        public void ValidateId();
        public void ValidateTitle();
        public void ValidateText();
    }
}
