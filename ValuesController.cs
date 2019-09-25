using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Threading.Tasks;
using AngularWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using LiteDB;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AngularWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ApiControllerAttribute
    {
         static HttpClient client1 = new HttpClient();

        public ValuesController()
        {
            using (var db = new LiteDatabase(@"Auctions.db"))
            {
                var items = db.GetCollection<AuctionItems>("auctionitems");
                var auctionlist = new AuctionItems
                {
                    auctionItemId = 1234,
                    BidderName = "",
                    CurrentBid = 0,
                    reservePrice = 10450
                };
                items.Insert(auctionlist);
            }

        }

       
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<AuctionItems> GetAuctionItems(int id)
        {

             var db = new LiteDatabase(@"Auctions.db");

            var collection = db.GetCollection<AuctionItems>("auctionItems");

            AuctionItems auction = collection.FindById(id);
             

            if (auction != null) return auction;
            return auction;
        }
        [HttpGet]
        public static async Task<List<AuctionItems>> GetAuctionAsync(string path)

        { 
             
         using(HttpClient client = new HttpClient())
            {

                var response = await client.GetAsync(path);
                return (await response.Content.ReadAsAsync<List<AuctionItems>>());
            }
            
        }

        [HttpPost]
        public static async Task<Uri> CreateAuctionAsync(AuctionItems auctionItems)
        {
            using (var db = new LiteDatabase(@"Auctions.db"))
            {
                var items = db.GetCollection<AuctionItems>("auctionitems");

                var record = items.FindById(auctionItems.auctionItemId);

                HttpResponseMessage response = await client1.PostAsJsonAsync("api/bids", items);
                response.EnsureSuccessStatusCode();

                if (ReservePriceCheck(record.auctionItemId))
                {

                    record.CurrentBid = Math.Max(record.CurrentBid, record.maxAutoBidAmountmax);
                }

                if (record.CurrentBid - record.maxAutoBidAmountmax > 1)

                {
                    Logger Log = new Logger();
                    Log.Write(255, "You have been outbid by higher bidder");
                }
                var maxAutoBidAmountmaxCurrent = record.maxAutoBidAmountmax;
                return response.Headers.Location;
            }
    }
        public static bool ReservePriceCheck(int id)
        {
            
            var db = new LiteDatabase(@"Auctions.db");

            var items = db.GetCollection<AuctionItems>("auctionitems");

            var item = items.FindById(id); 

            if (item.CurrentBid != item.reservePrice) return true;
            Logger Log = new Logger();
            Log.Write(255, "Reserve Price met ");
            return false;
        }
        public static async Task RunAsync()
        { 

            client1.BaseAddress = new Uri("");

            client1.DefaultRequestHeaders.Accept.Clear();
            client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                AuctionItems items = new AuctionItems
                {
                    auctionItemId = 1234,
                    BidderName = "ABC Dealership",
                     maxAutoBidAmountmax = 9500

                };

                var url = await CreateAuctionAsync(items);
                Console.WriteLine($"Created at {url}");

                items = await GetAuctionAsync(url);
                

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();


        }

        private static Task<AuctionItems> GetAuctionAsync(Uri url)
        {
            throw new NotImplementedException();
        }
        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
    }
