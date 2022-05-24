﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Core.Domain.Carousel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Id");

                    b.ToTable("Carousels");
                });

            modelBuilder.Entity("Core.Domain.ContentCarousel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CarouselId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Content")
                        .HasColumnType("bytea");

                    b.Property<int>("PageContainerId")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("TimeCycle")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("CarouselId");

                    b.HasIndex("PageContainerId");

                    b.ToTable("ContentCarousels");
                });

            modelBuilder.Entity("Core.Domain.PageContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PageContainers");
                });

            modelBuilder.Entity("Core.Domain.ContentCarousel", b =>
                {
                    b.HasOne("Core.Domain.Carousel", null)
                        .WithMany("ContentsCarousel")
                        .HasForeignKey("CarouselId");

                    b.HasOne("Core.Domain.PageContainer", "PageContainer")
                        .WithMany("ContentCarousel")
                        .HasForeignKey("PageContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PageContainer");
                });

            modelBuilder.Entity("Core.Domain.Carousel", b =>
                {
                    b.Navigation("ContentsCarousel");
                });

            modelBuilder.Entity("Core.Domain.PageContainer", b =>
                {
                    b.Navigation("ContentCarousel");
                });
#pragma warning restore 612, 618
        }
    }
}