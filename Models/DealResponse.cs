using System.Collections.Generic;
using BlackjackLib;

namespace IntroductionToCoreWebAPI.Models
{
    public class DealResponse
    {
        public DealResponse(Player dealer, List<Player> players)
        {
            Dealer = dealer;
            Players = players;

            Dealer.Cards.RemoveAt(1); 
        }

        public Player Dealer { get; set; }
        public List<Player> Players { get; set; }

      
    }
}