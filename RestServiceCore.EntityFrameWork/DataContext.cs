﻿using System;
using Microsoft.EntityFrameworkCore;
using RestServiceCore.Domain.Entities;
using Microsoft.Extensions.Configuration;
using RestServiceCore.Domain.Entity;

namespace RestServiceCore.EntityFrameWork
{
    public class DataContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public DataContext
        (DbContextOptions<DataContext> options) : base(options)
        {
        }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tag>().ToTable("Tag");           
            modelBuilder.Entity<Tag>()
            .Property(t => t.AddedDate)
             .IsRequired()
             .HasColumnType("DateTime")
             .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<Position>()
            .Property(t => t.AddedDate)
             .IsRequired()
             .HasColumnType("DateTime")
             .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Contact>()
            .Property(t => t.AddedDate)
             .IsRequired()
             .HasColumnType("DateTime")
             .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<ContactMember>().ToTable("ContactMember");
            modelBuilder.Entity<ContactMember>()
            .Property(t => t.AddedDate)
             .IsRequired()
             .HasColumnType("DateTime")
             .HasDefaultValueSql("GetDate()");
        }

        public virtual DbSet<Tag> Tags { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactMember> ContactMembers { get; set; }

    }




}
