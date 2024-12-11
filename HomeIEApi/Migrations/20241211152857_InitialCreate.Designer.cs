﻿// <auto-generated />
using System;
using HomeIEApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeIEApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241211152857_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("HomeIEApi.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<DateTime>("ActivatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalLogoUrls")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuctionList")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BathString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BedsString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BerRating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BrochureMap")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BrochureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOnDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EnergyRatingMediaPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GroupLogoBgColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupLogoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupPremiumHeadTextColour")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupPremiumJointLogoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupPremiumLogoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupRectangularLogoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupUrlSlugIdentifier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasVideos")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasWebP")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBrandBooster")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBuildToRent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBuildToRentDevelopment")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFavourite")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMappedAccurately")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsNew")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPremiumAd")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPrivateLandlord")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSaleAgreed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTopSpot")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JointGroupPremiumJointLogo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JointGroupRectangularLogoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MainPhoto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MainPhotoWeb")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Negotiator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OpenViewings")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderedDisplayAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhotoCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Photos")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PriceAsString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("PriceChangeIsIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyClass")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PropertyClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyClassUrlSlug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RefreshedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("RelatedPropertiesTotal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaleTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SeoDisplayAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SeoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SizeStringMeters")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TravelTimes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VirtualViewings")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
