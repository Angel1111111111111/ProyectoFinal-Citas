﻿// <auto-generated />
using System;
using Citas_Backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Citas_Backend.Migrations.LogDb
{
    [DbContext(typeof(LogDbContext))]
    [Migration("20240503224859_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Citas_Backend.Entities.LogEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Accion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("accion");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("detalle");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("fecha");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("log");
                });
#pragma warning restore 612, 618
        }
    }
}
