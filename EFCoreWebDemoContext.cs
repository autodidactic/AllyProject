using System;
using Microsoft.EntityFrameworkCore;

namespace AngularWebAPI.Models
{
    public class EFCoreWebDemoContext : DbContext
    {
        
            public DbSet<AuctionItems> auctions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=Auctions;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
     
    }
}
