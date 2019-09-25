using System;
using AngularWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularWebAPI.Migrations
{
    public class Configuration
    {

        protected override void Seed()
        {
            using (var context = new EFCoreWebDemoContext())
            {
                context.Add(new AuctionItems
                {
                    auctionItemId = 1234,
                    BidderName = "XYZ industries",
                    CurrentBid = 0,
                    reservePrice = 100,
                    maxAutoBidAmountmax = 10
                });
                context.Add(new AuctionItems
                {
                    auctionItemId = 1233,
                    BidderName = "AMC industries",
                    CurrentBid = 10,
                    reservePrice = 1200,
                    maxAutoBidAmountmax = 1120
                });
                context.Add(new AuctionItems
                {
                    auctionItemId = 443,
                    BidderName = "AMC industries",
                    CurrentBid = 1001,
                    reservePrice = 12200,
                    maxAutoBidAmountmax = 11320
                });
                context.Add(new AuctionItems
                {
                    auctionItemId = 555,
                    BidderName = "AMC industries",
                    CurrentBid = 10,
                    reservePrice = 12010,
                    maxAutoBidAmountmax = 11220
                });
            }
  

        }
        public Configuration()
        {
        }
    }
}
