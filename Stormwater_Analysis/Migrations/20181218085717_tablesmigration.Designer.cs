﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stormwater_Analysis;

namespace Stormwater_Analysis.Migrations
{
    [DbContext(typeof(AssetManagementModel))]
    [Migration("20181218085717_tablesmigration")]
    partial class tablesmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stormwater_Analysis.Manhole", b =>
                {
                    b.Property<int>("ManholeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DrainageArea");

                    b.Property<DateTime>("InstallationDt");

                    b.Property<string>("ManagedBy");

                    b.Property<int>("PipeID");

                    b.HasKey("ManholeID")
                        .HasName("PK_Manholes");

                    b.ToTable("Manholes");
                });

            modelBuilder.Entity("Stormwater_Analysis.ManholeMaintenance", b =>
                {
                    b.Property<int>("MaintenanceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CheckedBy")
                        .IsRequired();

                    b.Property<string>("CoverCondition");

                    b.Property<string>("FrameCondition");

                    b.Property<string>("FrameSealCondition");

                    b.Property<DateTime>("LastMaintenanceDt");

                    b.Property<string>("MaintenanceIssues");

                    b.Property<int>("MaintenanceLevel");

                    b.Property<int>("ManholeID");

                    b.HasKey("MaintenanceID")
                        .HasName("PK_Maintenance");

                    b.ToTable("ManholesMaintenance");
                });

            modelBuilder.Entity("Stormwater_Analysis.Pipe", b =>
                {
                    b.Property<int>("Pipe_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Critical_Infrastructure");

                    b.Property<bool>("Critical_Structure");

                    b.Property<DateTime>("DateOfInstallation");

                    b.Property<int>("Depth");

                    b.Property<int>("Est_Life");

                    b.Property<int>("Maintenance_Records_ID");

                    b.Property<int>("Material");

                    b.Property<decimal>("Pipe_Length");

                    b.Property<int>("Pipe_Type");

                    b.Property<decimal>("Slope");

                    b.Property<int>("Start_Manhole_ID");

                    b.HasKey("Pipe_ID")
                        .HasName("PK_Pipes");

                    b.ToTable("Pipes");
                });
#pragma warning restore 612, 618
        }
    }
}
