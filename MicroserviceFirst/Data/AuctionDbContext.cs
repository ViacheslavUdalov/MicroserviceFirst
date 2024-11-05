using MicroserviceFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceFirst.Data;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Auction> Auctions { get; set; }
}