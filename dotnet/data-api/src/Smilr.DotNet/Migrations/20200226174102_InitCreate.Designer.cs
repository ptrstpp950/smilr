﻿// <auto-generated />
using System;
using Smilr.DotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Smilr.DotNet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200226174102_InitCreate")]
    partial class InitCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Smilr.DotNet.Models.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("End")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Smilr.DotNet.Models.Feedback", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rating")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Sentiment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Topic")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("Smilr.DotNet.Models.Topic", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("Smilr.DotNet.Models.Topic", b =>
                {
                    b.HasOne("Smilr.DotNet.Models.Event", null)
                        .WithMany("Topics")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}