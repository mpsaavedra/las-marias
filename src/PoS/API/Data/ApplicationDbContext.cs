namespace LasMarias.PoS.Data;

using Microsoft.EntityFrameworkCore;
using LasMarias.PoS.Domain.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<AttributeName> AttributeNames { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Stand> Stands { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

    }
}