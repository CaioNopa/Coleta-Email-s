﻿// <auto-generated />
using System;
using Coleta_Email_s.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coleta_Email_s.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240323033645_CriacaoBanco")]
    partial class CriacaoBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Coleta_Email_s.Models.EmailModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UltimaAtualizacao")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });
#pragma warning restore 612, 618
        }
    }
}
