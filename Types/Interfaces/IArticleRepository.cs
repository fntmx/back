using Bmwadforth.Types.Interfaces;
using Bmwadforth.Types.Models;

namespace Bmwadforth.Types.Interfaces;

public interface IArticleRepository
{
    Task<Article> GetArticle(int id);
    Task<List<Article>> GetArticles();
    Task<int> NewArticle(Article article);
    Task UpdateArticle(Article article);
    Task<(Stream, string)> GetArticleContent(int id);
    Task NewArticleContent(int id, string contentType, Stream source);
    Task<(Stream, string)> GetArticleThumbnail(int id);
    Task NewArticleThumbnail(int id, string contentType, Stream source);
}