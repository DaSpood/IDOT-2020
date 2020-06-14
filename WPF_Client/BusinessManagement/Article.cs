using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client.BusinessManagement
{
    class Article
    {
        /// <summary>
        /// Returns a list of all Article in the database.
        /// </summary>
        public static List<Dbo.Article> GetArticleList()
        {
            return DataAccess.Article.GetArticleList();
        }

        /// <summary>
        /// Increments the viewcounter of the matching article and returns the success of the operation.
        /// </summary>
        public static bool IncrementArticleViewcountById(long id)
        {
            return DataAccess.Article.IncrementArticleViewcountById(id);
        }

        /// <summary>
        /// Adds a new Article to the database and returns the success of the operation.
        /// The id field of the parameter will be ignored when adding to the database.
        /// </summary>
        public static bool AddArticle(Dbo.Article article)
        {
            return DataAccess.Article.AddArticle(article);
        }
    }
}
