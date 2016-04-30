using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using BW.Web.Models;

namespace BW.Web.Data
{
    public class EFSiteRepository : ISiteRepository
    {
		private readonly SiteContext context;

		public EFSiteRepository(SiteContext context)
		{
			this.context = context;
		}

        public IQueryable<BlogCategory> Categories
        {
            get
            {
                return context.BlogCategories;
            }
        }

        public IQueryable<BlogPost> Posts
        {
            get
            {
                return context.BlogPosts;
            }
        }

        public IQueryable<BlogPost> PostsIncluding(params Expression<Func<BlogPost, object>>[] includeProperties)
        {
            IQueryable<BlogPost> query = context.BlogPosts;

			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}

			return query;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}