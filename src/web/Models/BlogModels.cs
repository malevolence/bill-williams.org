using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW.Web.Models
{
	[Table("blog_Posts")]
	public class BlogPost
	{
		public BlogPost()
		{
			this.CreateDate = DateTime.Now;
			this.PostTags = new List<PostTag>();
		}

		public int Id { get; set; }

		public int CategoryId { get; set; }

		[Required, StringLength(200)]
		public string Title { get; set; }

		[Required, StringLength(200)]
		public string Slug { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		public string Excerpt { get; set; }

		[Display(Name = "Created On")]
		public DateTime CreateDate { get; set; }

		[Display(Name = "Updated On")]
		public DateTime? UpdateDate { get; set; }

		[Display(Name = "Published On")]
		public DateTime? PublishDate { get; set; }

		[Required, StringLength(100)]
		public string Author { get; set; }

		[ForeignKey("CategoryId")]
		public BlogCategory Category { get; set; }

		public virtual ICollection<PostTag> PostTags { get; set; }
	}

	[Table("blog_Categories")]
	public class BlogCategory
	{
		public int Id { get; set; }

		[Required, StringLength(100)]
		public string Name { get; set; }
	}

	[Table("Tags")]
	public class Tag
	{
		public int Id { get; set; }

		[Required, StringLength(100)]
		public string Name { get; set; }
	}

	[Table("blog_Posts_Tags")]
	public class PostTag
	{
		public int TagId { get; set; }
		public int PostId { get; set; }

		[ForeignKey("TagId")]
		public Tag Tag { get; set; }

		[ForeignKey("PostId")]
		public BlogPost Post { get; set; }
	}
}