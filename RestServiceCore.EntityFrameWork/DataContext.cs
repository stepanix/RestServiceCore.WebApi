using System;
using Microsoft.EntityFrameworkCore;
using RestServiceCore.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace RestServiceCore.EntityFrameWork
{
    public class DataContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public DataContext
        (DbContextOptions<DataContext> options) : base(options)
        {
        }


        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<ContactTag> ContactTags { get; set; }
        //public DbSet<Position> Positions { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           

            //base.OnConfiguring(optionsBuilder);
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
        }

        public virtual DbSet<Tag> Tags { get; set; }


    }




}
