﻿// <auto-generated />
using System;
using IPAM_Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IPAM_Repo.Migrations
{
    [DbContext(typeof(IPAMDbContext))]
    [Migration("20211016095038_ServerType")]
    partial class ServerType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("IPAM_Repo.Models.ServerType", b =>
                {
                    b.Property<Guid>("ServerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ServerTypeId");

                    b.ToTable("ServerType");
                });

            modelBuilder.Entity("IPAM_Repo.Models.Subnet", b =>
                {
                    b.Property<Guid>("SubnetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("SubnetAddress")
                        .HasColumnType("text");

                    b.Property<string>("SubnetDescription")
                        .HasColumnType("text");

                    b.Property<Guid>("SubnetGroupId")
                        .HasColumnType("uuid");

                    b.Property<int>("SubnetMaskId")
                        .HasColumnType("integer");

                    b.Property<Guid>("SubnetMaskMaskId")
                        .HasColumnType("uuid");

                    b.Property<string>("SubnetName")
                        .HasColumnType("text");

                    b.Property<string>("VlanName")
                        .HasColumnType("text");

                    b.HasKey("SubnetId");

                    b.HasIndex("SubnetGroupId");

                    b.HasIndex("SubnetMaskMaskId");

                    b.ToTable("Subnet");
                });

            modelBuilder.Entity("IPAM_Repo.Models.SubnetGroup", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("GroupAddress")
                        .HasColumnType("text");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.HasKey("GroupId");

                    b.ToTable("SubnetGroup");
                });

            modelBuilder.Entity("IPAM_Repo.Models.SubnetMask", b =>
                {
                    b.Property<Guid>("MaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Addresses")
                        .HasColumnType("integer");

                    b.Property<string>("CIDR")
                        .HasColumnType("text");

                    b.Property<string>("Class")
                        .HasColumnType("text");

                    b.Property<int>("Hosts")
                        .HasColumnType("integer");

                    b.Property<string>("NetMask")
                        .HasColumnType("text");

                    b.HasKey("MaskId");

                    b.ToTable("SubnetMask");
                });

            modelBuilder.Entity("IPAM_Repo.Models.Subnet", b =>
                {
                    b.HasOne("IPAM_Repo.Models.SubnetGroup", "SubnetGroup")
                        .WithMany()
                        .HasForeignKey("SubnetGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPAM_Repo.Models.SubnetMask", "SubnetMask")
                        .WithMany()
                        .HasForeignKey("SubnetMaskMaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubnetGroup");

                    b.Navigation("SubnetMask");
                });
#pragma warning restore 612, 618
        }
    }
}
