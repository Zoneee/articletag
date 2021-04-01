using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Businesses.Dto;

namespace Businesses.Interfaces
{
    public interface IArticleBusiness
    {
        Task<ArticleDto> GetArticleAsync(long userid);
    }
}
