using HomeIEApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using System.Linq.Expressions;

namespace HomeIEApi.Database;

public class AppDbContext : DbContext
{
    public DbSet<Property>? Properties { get; set; }

    // Constructor for the in memory tests
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // We configure only when
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=Database/properties.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Primary key init
        modelBuilder.Entity<Property>().HasKey(p => p.Id);

        modelBuilder.Entity<Property>().Property(p => p.Id).ValueGeneratedNever();

        // Serialize CustomData as a JSON object
        ConfigureObjectSerialization<Property, CustomData>(modelBuilder, p => p.CustomData);

        // Serialize Location as a JSON object
        ConfigureObjectSerialization<Property, Location>(modelBuilder, p => p.Location);

        // Serialize Negotiator as a JSON object
        ConfigureObjectSerialization<Property, Negotiator>(modelBuilder, p => p.Negotiator);

        // Serialize BrochureMap as a JSON object
        ConfigureObjectSerialization<Property, BrochureMap>(modelBuilder, p => p.BrochureMap);

        // Serialize OpenViewings as a JSON list
        ConfigureListSerialization<Property, object>(modelBuilder, p => p.OpenViewings);

        // Serialize VirtualViewings as a JSON list
        ConfigureListSerialization<Property, object>(modelBuilder, p => p.VirtualViewings);

        // Serialize Photos as a JSON list
        ConfigureListSerialization<Property, object>(modelBuilder, p => p.Photos);

        // Serialize TravelTimes as a JSON list
        ConfigureListSerialization<Property, object>(modelBuilder, p => p.TravelTimes);

        // Serialize AuctionList as a JSON list
        ConfigureListSerialization<Property, object>(modelBuilder, p => p.AuctionList);

        // Serialize AdditionalLogoUrls as a JSON list
        ConfigureListSerialization<Property, object>(modelBuilder, p => p.AdditionalLogoUrls);
    }

    private static void ConfigureObjectSerialization<TEntity, TObject>(
        ModelBuilder modelBuilder,
        Expression<Func<TEntity, TObject>> propertyExpression)
        where TEntity : class
        where TObject : class, new()
    {
        var jsonSerializerOptions = new JsonSerializerOptions();
        var objectComparer = new ValueComparer<TObject>(
            (c1, c2) => JsonSerializer.Serialize(c1, jsonSerializerOptions) == JsonSerializer.Serialize(c2, jsonSerializerOptions),
            c => JsonSerializer.Serialize(c, jsonSerializerOptions).GetHashCode(),
            c => JsonSerializer.Deserialize<TObject>(
                JsonSerializer.Serialize(c, jsonSerializerOptions),
                jsonSerializerOptions
            ) ?? new TObject()
        );

        modelBuilder.Entity<TEntity>()
            .Property(propertyExpression)
            .HasConversion(
                v => JsonSerializer.Serialize(v, jsonSerializerOptions), // Serialize object to JSON
                v => JsonSerializer.Deserialize<TObject>(v, jsonSerializerOptions) ?? new TObject() // Deserialize JSON to object
            )
            .Metadata.SetValueComparer(objectComparer); // Attach ValueComparer
    }

    private static void ConfigureListSerialization<TEntity, TElement>(
        ModelBuilder modelBuilder,
        Expression<Func<TEntity, List<TElement>>> propertyExpression)
        where TEntity : class
    {
        var jsonSerializerOptions = new JsonSerializerOptions();
        var listComparer = new ValueComparer<List<TElement>>(
            (c1, c2) => (c1 ?? new List<TElement>()).SequenceEqual(c2 ?? new List<TElement>()),
            c => (c ?? new List<TElement>()).Aggregate(0, (a, v) => HashCode.Combine(a, v != null ? v.GetHashCode() : 0)),
            c => c == null ? new List<TElement>() : c.ToList()
        );

        modelBuilder.Entity<TEntity>()
            .Property(propertyExpression)
            .HasConversion(
                v => JsonSerializer.Serialize(v, jsonSerializerOptions), // Serialize list to JSON
                v => JsonSerializer.Deserialize<List<TElement>>(v, jsonSerializerOptions) ?? new List<TElement>() // Deserialize JSON to list
            )
            .Metadata.SetValueComparer(listComparer); // Compare new list with old before updating
    }
}
