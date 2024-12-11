namespace HomeIEApi.Models;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

public class Property
{
    [Key, JsonPropertyName("id")]
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public int GroupId { get; set; }
    public CustomData CustomData { get; set; } = new CustomData();
    public DateTime RefreshedOn { get; set; }
    public Location Location { get; set; } = new Location();
    public string Address { get; set; } = string.Empty;
    public string GroupPhoneNumber { get; set; } = string.Empty;
    public string GroupEmail { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
    public string GroupAddress { get; set; } = string.Empty;
    public string GroupUrlSlugIdentifier { get; set; } = string.Empty;
    public Negotiator Negotiator { get; set; } = new Negotiator();
    public DateTime CreatedOnDate { get; set; }
    public DateTime ActivatedOn { get; set; }
    public bool IsNew { get; set; }
    public bool IsSaleAgreed { get; set; }
    public string GroupLogoBgColor { get; set; } = string.Empty;
    public string GroupPremiumHeadTextColour { get; set; } = string.Empty;
    public string GroupLogoUrl { get; set; } = string.Empty;
    public string GroupPremiumLogoUrl { get; set; } = string.Empty;
    public string GroupPremiumJointLogoUrl { get; set; } = string.Empty;
    public string GroupRectangularLogoUrl { get; set; } = string.Empty;
    public string JointGroupRectangularLogoUrl { get; set; } = string.Empty;
    public string JointGroupPremiumJointLogo { get; set; } = string.Empty;
    public string GroupUrl { get; set; } = string.Empty;
    public bool IsPremiumAd { get; set; }
    public bool IsBuildToRent { get; set; }
    public bool IsBuildToRentDevelopment { get; set; }
    public bool IsPrivateLandlord { get; set; }
    public bool IsBrandBooster { get; set; }
    public bool IsActive { get; set; }
    public int SaleTypeId { get; set; }
    public bool IsFavourite { get; set; }
    public bool HasVideos { get; set; }
    public bool HasWebP { get; set; }
    public bool IsMappedAccurately { get; set; }
    public bool IsTopSpot { get; set; }
    public string BedsString { get; set; } = string.Empty;
    public string PriceAsString { get; set; } = string.Empty;
    public BrochureMap BrochureMap { get; set; } = new BrochureMap();
    public int SizeStringMeters { get; set; }
    public bool PriceChangeIsIncrease { get; set; }
    public string DisplayAddress { get; set; } = string.Empty;
    public int PropertyClassId { get; set; }
    public string PropertyClass { get; set; } = string.Empty;
    public string PropertyClassUrlSlug { get; set; } = string.Empty;
    public string PropertyStatus { get; set; } = string.Empty;
    public string PropertyType { get; set; } = string.Empty;
    public string BathString { get; set; } = string.Empty;
    public string BerRating { get; set; } = string.Empty;
    public string EnergyRatingMediaPath { get; set; } = string.Empty;
    public List<object> OpenViewings { get; set; } = new List<object>();
    public List<object> VirtualViewings { get; set; } = new List<object>();
    public string OrderedDisplayAddress { get; set; } = string.Empty;
    public string SeoDisplayAddress { get; set; } = string.Empty;
    public string BrochureUrl { get; set; } = string.Empty;
    public string SeoUrl { get; set; } = string.Empty;
    public int PhotoCount { get; set; }
    public string MainPhoto { get; set; } = string.Empty;
    public string MainPhotoWeb { get; set; } = string.Empty;
    public List<object> Photos { get; set; } = new List<object>();
    public List<object> TravelTimes { get; set; } = new List<object>();
    public List<object> AuctionList { get; set; } = new List<object>();
    public List<object> AdditionalLogoUrls { get; set; } = new List<object>();
    public int RelatedPropertiesTotal { get; set; }
}

public class CustomData
{
    public List<int> RelatedPropertyIDs { get; set; } = new List<int>();
    public bool IsMyHomePassport { get; set; }
}

public class Location
{
    [JsonPropertyName("lat")]
    public double Lat { get; set; }
    [JsonPropertyName("lon")]
    public double Lon { get; set; }
}

public class Negotiator
{
    public int NegotiatorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string WebSite { get; set; } = string.Empty;
}

public class BrochureMap
{
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
}
