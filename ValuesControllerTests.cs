using System;
using System.Threading.Tasks;
using AngularWebAPI.Controllers;
using AngularWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 
namespace AngularWebAPI.UnitTests
{
    [TestClass]
    public class ValuesControllerTests
    {   
        string path = "/auctionItems";
        [TestMethod]
        public async Task<AuctionItems> GetAuctionAsyncTests()
       
        {
            AuctionItems items = null; 
            var controller = new ValuesController();
            AuctionItems result = await controller.GetAuctionAsync((string)items);
            Assert.IsNotNull(result, "error");
            return result;
        }

        public async Task<Uri> CreateAuctionAsyncTests()
        {
            var controller = new ValuesController();
            AuctionItems items = new AuctionItems
            {
                  auctionItemId=1234,  maxAutoBidAmountmax=9500, BidderName="ABC DealerShip"
            };
            Uri result = await controller.CreateAuctionAsync(items);
            Assert.AreEqual(result, "success");
            return result;
        }
    }
}
