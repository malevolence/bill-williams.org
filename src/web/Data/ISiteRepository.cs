using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BW.Web.Models;
using System;

namespace BW.Web.Data
{
	public interface ISiteRepository
	{
		IQueryable<BlogPost> Posts { get; }
		IQueryable<BlogCategory> Categories { get; }

		IQueryable<BlogPost> PostsIncluding(params Expression<Func<BlogPost, object>>[] includeProperties);

		Task SaveChangesAsync();
	}
}