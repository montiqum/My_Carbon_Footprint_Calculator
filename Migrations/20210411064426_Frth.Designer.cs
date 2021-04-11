﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCarbonFootprintCalculator.Data;

namespace MyCarbonFootprintCalculator.Migrations
{
    [DbContext(typeof(MyCarbonFootprintCalculatorContext))]
    [Migration("20210411064426_Frth")]
    partial class Frth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyCarbonFootprintCalculator.Models.FoodMod", b =>
                {
                    b.Property<int>("DietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Desserts")
                        .HasColumnType("int");

                    b.Property<string>("DietType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fast_foods")
                        .HasColumnType("int");

                    b.Property<int>("Fish")
                        .HasColumnType("int");

                    b.Property<int>("Fruits")
                        .HasColumnType("int");

                    b.Property<int>("Grains")
                        .HasColumnType("int");

                    b.Property<int>("Meat")
                        .HasColumnType("int");

                    b.Property<int>("Milk")
                        .HasColumnType("int");

                    b.Property<int>("Vegetables")
                        .HasColumnType("int");

                    b.HasKey("DietId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("MyCarbonFootprintCalculator.Models.FootprintMod", b =>
                {
                    b.Property<int>("CFPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HH_Emm")
                        .HasColumnType("int");

                    b.Property<int>("Total_emm")
                        .HasColumnType("int");

                    b.Property<int>("Travel_emm")
                        .HasColumnType("int");

                    b.Property<int>("Waste_emm")
                        .HasColumnType("int");

                    b.HasKey("CFPId");

                    b.ToTable("Footprint");
                });

            modelBuilder.Entity("MyCarbonFootprintCalculator.Models.GenInfoMod", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnualIncome")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("GenInfo");
                });

            modelBuilder.Entity("MyCarbonFootprintCalculator.Models.HouseMod", b =>
                {
                    b.Property<int>("HouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Energy_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Energy_Usage")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.HasKey("HouseId");

                    b.ToTable("House");
                });

            modelBuilder.Entity("MyCarbonFootprintCalculator.Models.VehicleMod", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfVehicles")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
