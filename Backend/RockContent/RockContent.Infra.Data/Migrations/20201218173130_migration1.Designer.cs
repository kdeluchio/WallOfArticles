﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RockContent.Infra.Data.Context;

namespace RockContent.Infra.Data.Migrations
{
    [DbContext(typeof(RockContentContext))]
    [Migration("20201218173130_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RockContent.Domain.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedIn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Article");
                });
#pragma warning restore 612, 618
        }
    }
}
