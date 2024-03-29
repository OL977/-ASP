﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using РикконсалтингASP.Models;

namespace РикконсалтингASP.Migrations.DbLemelMigration
{
    [DbContext(typeof(DbLemel))]
    [Migration("20210424200833_Int")]
    partial class Int
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("РикконсалтингASP.Models.NewUserLemel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ДатаИзменения")
                        .HasColumnType("datetime2");

                    b.Property<string>("Имя")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Организация")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Отчество")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Пользователь")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Роль")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ФИОСборное")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Фамилия")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("СотрудникиLemel");
                });
#pragma warning restore 612, 618
        }
    }
}
