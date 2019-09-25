using System.ComponentModel.DataAnnotations;

namespace AngularWebAPI.Models

{

    public class AuctionItems
    {
       
        public int auctionItemId { get; set; }
        public int CurrentBid { get; set; }
        public int reservePrice { get; set; }
        [StringLength(255)]
        public string BidderName { get; set; }
        public int maxAutoBidAmountmax { get; set; }


    }
}