using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RestServiceCore.EntityFrameWork;

namespace RestServiceCore.EntityFrameWork.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170606170703_contact")]
    partial class contact
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

                    b.Property<int?>("ContactId");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("RestServiceCore.Domain.Entities.Contact", b =>
                {
                    b.HasOne("RestServiceCore.Domain.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RestServiceCore.Domain.Entities.Tag", b =>
                {
                    b.HasOne("RestServiceCore.Domain.Entities.Contact")
                        .WithMany("Tags")
                        .HasForeignKey("ContactId");
                });
        }
    }
}
