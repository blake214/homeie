using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeIEApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomData = table.Column<string>(type: "TEXT", nullable: false),
                    RefreshedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    GroupPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    GroupEmail = table.Column<string>(type: "TEXT", nullable: false),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false),
                    GroupAddress = table.Column<string>(type: "TEXT", nullable: false),
                    GroupUrlSlugIdentifier = table.Column<string>(type: "TEXT", nullable: false),
                    Negotiator = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActivatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsNew = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSaleAgreed = table.Column<bool>(type: "INTEGER", nullable: false),
                    GroupLogoBgColor = table.Column<string>(type: "TEXT", nullable: false),
                    GroupPremiumHeadTextColour = table.Column<string>(type: "TEXT", nullable: false),
                    GroupLogoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    GroupPremiumLogoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    GroupPremiumJointLogoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    GroupRectangularLogoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    JointGroupRectangularLogoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    JointGroupPremiumJointLogo = table.Column<string>(type: "TEXT", nullable: false),
                    GroupUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsPremiumAd = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsBuildToRent = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsBuildToRentDevelopment = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPrivateLandlord = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsBrandBooster = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    SaleTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFavourite = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasVideos = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasWebP = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMappedAccurately = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsTopSpot = table.Column<bool>(type: "INTEGER", nullable: false),
                    BedsString = table.Column<string>(type: "TEXT", nullable: false),
                    PriceAsString = table.Column<string>(type: "TEXT", nullable: false),
                    BrochureMap = table.Column<string>(type: "TEXT", nullable: false),
                    SizeStringMeters = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceChangeIsIncrease = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisplayAddress = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyClass = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyClassUrlSlug = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyStatus = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyType = table.Column<string>(type: "TEXT", nullable: false),
                    BathString = table.Column<string>(type: "TEXT", nullable: false),
                    BerRating = table.Column<string>(type: "TEXT", nullable: false),
                    EnergyRatingMediaPath = table.Column<string>(type: "TEXT", nullable: false),
                    OpenViewings = table.Column<string>(type: "TEXT", nullable: false),
                    VirtualViewings = table.Column<string>(type: "TEXT", nullable: false),
                    OrderedDisplayAddress = table.Column<string>(type: "TEXT", nullable: false),
                    SeoDisplayAddress = table.Column<string>(type: "TEXT", nullable: false),
                    BrochureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    SeoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PhotoCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MainPhoto = table.Column<string>(type: "TEXT", nullable: false),
                    MainPhotoWeb = table.Column<string>(type: "TEXT", nullable: false),
                    Photos = table.Column<string>(type: "TEXT", nullable: false),
                    TravelTimes = table.Column<string>(type: "TEXT", nullable: false),
                    AuctionList = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalLogoUrls = table.Column<string>(type: "TEXT", nullable: false),
                    RelatedPropertiesTotal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
