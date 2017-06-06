﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RestServiceCore.EntityFrameWork;

namespace RestServiceCore.EntityFrameWork.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170606193857_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestServiceCore.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("FirstName");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("PositionId");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("RestServiceCore.Domain.Entities.ContactMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<int>("ContactId");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("TagId");

                    b.ToTable("ContactMember");
                });

            modelBuilder.Entity("RestServiceCore.Domain.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("RestServiceCore.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("RestServiceCore.Domain.Entities.Contact", b =>
                {
                    b.HasOne("RestServiceCore.Domain.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RestServiceCore.Domain.Entities.ContactMember", b =>
                {
                    b.HasOne("RestServiceCore.Domain.Entities.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RestServiceCore.Domain.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}