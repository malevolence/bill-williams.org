using BW.Web.Models;
using Microsoft.Data.Entity;

namespace BW.Web.Data
{
	public class SiteContext : DbContext
	{
		public DbSet<BlogPost> BlogPosts { get; set; }
		public DbSet<BlogCategory> BlogCategories { get; set; }
		public DbSet<Tag> Tags { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<PostTag>().HasKey(x => new { x.TagId, x.PostId });
		}
	}
}