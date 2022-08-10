﻿// <auto-generated />
using System;
using Adevinta_hw.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Adevinta_hw.Migrations
{
    [DbContext(typeof(KonyvtarDbContext))]
    [Migration("20220810073858_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Adevinta_hw.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Adevinta_hw.Models.Borrow", b =>
                {
                    b.Property<int>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("BorrowedBookBookId")
                        .HasColumnType("int");

                    b.Property<string>("BorrowerName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("BorrowId");

                    b.HasIndex("BorrowedBookBookId");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("Adevinta_hw.Models.Borrow", b =>
                {
                    b.HasOne("Adevinta_hw.Models.Book", "BorrowedBook")
                        .WithMany()
                        .HasForeignKey("BorrowedBookBookId");

                    b.Navigation("BorrowedBook");
                });
#pragma warning restore 612, 618
        }
    }
}
