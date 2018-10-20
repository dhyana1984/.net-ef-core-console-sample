﻿// <auto-generated />
using System;
using EFCoreConsoleSample;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreConsoleSample.Migrations
{
    [DbContext(typeof(EfCoreDbContext))]
    [Migration("20181019063306_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.SqlSequence", "'SqlSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreConsoleSample.Entity.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("ModifyTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("TestBackingField");

                    b.Property<string>("URL")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EFCoreConsoleSample.Entity.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Introduce")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EFCoreConsoleSample.Entity.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "SqlSequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(50);

                    b.HasKey("CustomerId");

                    b.ToTable("T_Customer");
                });

            modelBuilder.Entity("EFCoreConsoleSample.Entity.Student", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<DateTime>("CreateTime");

                    b.Property<decimal>("Decimal");

                    b.Property<double>("Double");

                    b.Property<float>("Float");

                    b.Property<int>("Id");

                    b.Property<long>("Int64");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<byte>("Status");

                    b.HasKey("Guid");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
