﻿using EFCoreConsoleSample.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample.Mapping
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");


            builder.Property(t => t.CreateTime).HasColumnType("datetime").HasDefaultValueSql("getdate()");
            builder.Property(t => t.ModifyTime).HasColumnType("datetime").HasDefaultValueSql("getdate()");
            builder.Property(t => t.URL).HasColumnType("varchar(100)").HasField("_url"); //BackingFiled映射URL属性到_url字段
            builder.Property<string>("TestBackingField").HasField("_status");//BackingFiled,新建TestBackingField映射到_status字段

        }
    }
}
