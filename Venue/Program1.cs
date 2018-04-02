using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venue
{
    class Program1
    {
        static void Main(string[] args)
        {
            VenueTests venueTests = new VenueTests();

            //venueTests.VenueManagement();
            
            venueTests.AreaManagement();
            /*
            venueTests.BlockManagement();
            venueTests.GateManagement();
            venueTests.TribuneManagement();
            venueTests.TurnstileManagement();
            venueTests.VenueTemplateManagement();
            venueTests.SeatClassManagement();
            */
        }
    }
}
