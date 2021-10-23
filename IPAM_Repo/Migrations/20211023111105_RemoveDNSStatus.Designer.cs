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
    [Migration("20211023111105_RemoveDNSStatus")]
    partial class RemoveDNSStatus
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

                    b.Property<Guid>("SubnetMaskId")
                        .HasColumnType("uuid");

                    b.Property<string>("SubnetName")
                        .HasColumnType("text");

                    b.Property<string>("VlanName")
                        .HasColumnType("text");

                    b.HasKey("SubnetId");

                    b.HasIndex("SubnetGroupId");

                    b.HasIndex("SubnetMaskId");

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

            modelBuilder.Entity("IPAM_Repo.Models.SubnetIP", b =>
                {
                    b.Property<Guid>("SubnetIPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AliasName")
                        .HasColumnType("text");

                    b.Property<string>("AssetTag")
                        .HasColumnType("text");

                    b.Property<string>("ConnectedSwitch")
                        .HasColumnType("text");

                    b.Property<string>("DeviceType")
                        .HasColumnType("text");

                    b.Property<string>("IPAddress")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastScan")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("MacAddress")
                        .HasColumnType("text");

                    b.Property<string>("ReservedStatus")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<Guid>("SubnetId")
                        .HasColumnType("uuid");

                    b.Property<string>("SystemLocation")
                        .HasColumnType("text");

                    b.HasKey("SubnetIPId");

                    b.HasIndex("SubnetId");

                    b.ToTable("SubnetIP");
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
                        .HasForeignKey("SubnetMaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubnetGroup");

                    b.Navigation("SubnetMask");
                });

            modelBuilder.Entity("IPAM_Repo.Models.SubnetIP", b =>
                {
                    b.HasOne("IPAM_Repo.Models.Subnet", "Subnet")
                        .WithMany()
                        .HasForeignKey("SubnetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subnet");
                });
#pragma warning restore 612, 618
        }
    }
}
