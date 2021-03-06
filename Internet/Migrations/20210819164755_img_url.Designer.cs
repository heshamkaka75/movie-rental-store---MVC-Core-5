// <auto-generated />
using System;
using Internet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Internet.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20210819164755_img_url")]
    partial class img_url
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Internet.Models.Actors", b =>
                {
                    b.Property<int>("actor_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("actor_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("actor_id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Internet.Models.Movies", b =>
                {
                    b.Property<int>("movie_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("actor_id")
                        .HasColumnType("int");

                    b.Property<string>("movie_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rate")
                        .HasColumnType("int");

                    b.HasKey("movie_id");

                    b.HasIndex("actor_id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Internet.Models.Movies", b =>
                {
                    b.HasOne("Internet.Models.Actors", "Actor")
                        .WithMany()
                        .HasForeignKey("actor_id");

                    b.Navigation("Actor");
                });
#pragma warning restore 612, 618
        }
    }
}
