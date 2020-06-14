using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client.DataAccess
{
    class Article
    {
        /// <summary>
        /// Returns a list of all Article in the database.
        /// </summary>
        public static List<Dbo.Article> GetArticleList()
        {
            List<Dbo.Article> res = new List<Dbo.Article>();

            using (ProjectDBEntities ctx = new ProjectDBEntities())
            {
                var primitiveList = ctx.T_Article.ToList();

                foreach (var article in primitiveList)
                    res.Add(new Dbo.Article(article.Id, article.Title, article.IdAuthor,
                        article.Date, article.Image, article.Text, article.Viewcount));
            }

            return res;
        }

        /// <summary>
        /// Increments the viewcounter of the matching article and returns the success of the operation.
        /// </summary>
        public static bool IncrementArticleViewcountById(long id)
        {
            try
            {
                using (ProjectDBEntities ctx = new ProjectDBEntities())
                {
                    var article = (from tmp in ctx.T_Article
                                   where tmp.Id == id
                                   select tmp).First();
                    article.Viewcount = article.Viewcount + 1;
                    if (ctx.SaveChanges() == 0)
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a new Article to the database and returns the success of the operation.
        /// The id field of the parameter will be ignored when adding to the database.
        /// </summary>
        public static bool AddArticle(Dbo.Article article)
        {
            try
            {
                using (ProjectDBEntities ctx = new ProjectDBEntities())
                {
                    ctx.T_Article.Add(new T_Article()
                    {
                        Title = article.Title,
                        IdAuthor = article.IdAuthor,
                        Date = article.Date,
                        Image = article.Image,
                        Text = article.Text,
                        Viewcount = 0
                    });
                    if (ctx.SaveChanges() == 0)
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
