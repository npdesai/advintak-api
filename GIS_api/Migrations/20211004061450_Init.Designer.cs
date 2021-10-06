﻿// <auto-generated />
using GIS_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GIS_api.Migrations
{
    [DbContext(typeof(GisContext))]
    [Migration("20211004061450_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GIS_api.Models.Subnet.SubnetGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("GroupAddress")
                        .HasColumnType("text");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.HasKey("GroupId");

                    b.ToTable("SubnetGroup");
                });

            modelBuilder.Entity("GIS_api.Models.Subnet.SubnetMask", b =>
                {
                    b.Property<int>("MaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MaskDescription")
                        .HasColumnType("text");

                    b.Property<string>("MaskName")
                        .HasColumnType("text");

                    b.HasKey("MaskId");

                    b.ToTable("SubnetMask");
                });

            modelBuilder.Entity("GIS_api.Models.Subnet.Subnets", b =>
                {
                    b.Property<int>("SubnetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("SubnetAddress")
                        .HasColumnType("text");

                    b.Property<string>("SubnetDescription")
                        .HasColumnType("text");

                    b.Property<int>("SubnetGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("SubnetMaskId")
                        .HasColumnType("integer");

                    b.Property<string>("SubnetName")
                        .HasColumnType("text");

                    b.Property<string>("VlanName")
                        .HasColumnType("text");

                    b.HasKey("SubnetId");

                    b.HasIndex("SubnetGroupId");

                    b.HasIndex("SubnetMaskId");

                    b.ToTable("Subnets");
                });

            modelBuilder.Entity("GIS_api.Models.Subnet.Subnets", b =>
                {
                    b.HasOne("GIS_api.Models.Subnet.SubnetGroup", "SubnetGroup")
                        .WithMany()
                        .HasForeignKey("SubnetGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GIS_api.Models.Subnet.SubnetMask", "SubnetMask")
                        .WithMany()
                        .HasForeignKey("SubnetMaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubnetGroup");

                    b.Navigation("SubnetMask");
                });
#pragma warning restore 612, 618
        }
    }
}
