using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BW.Web.Data;

namespace web.Migrations
{
    [DbContext(typeof(SiteContext))]
    [Migration("20160430185103_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BW.Web.Models.BlogCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "blog_Categories");
                });

            modelBuilder.Entity("BW.Web.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Excerpt")
                        .IsRequired();

                    b.Property<DateTime?>("PublishDate");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "blog_Posts");
                });

            modelBuilder.Entity("BW.Web.Models.PostTag", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("PostId");

                    b.HasKey("TagId", "PostId");

                    b.HasAnnotation("Relational:TableName", "blog_Posts_Tags");
                });

            modelBuilder.Entity("BW.Web.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Tags");
                });

            modelBuilder.Entity("BW.Web.Models.BlogPost", b =>
                {
                    b.HasOne("BW.Web.Models.BlogCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("BW.Web.Models.PostTag", b =>
                {
                    b.HasOne("BW.Web.Models.BlogPost")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("BW.Web.Models.Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });
        }
    }
}
