using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Selenium.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using Helpers;
using System.Threading;

namespace AllModulesTesting
{
    class Program0
    {
        static void Main(string[] args)
        {
            TestingWhole whole = new TestingWhole();

            /*  whole.Contacts();
              whole.NationalID();
              whole.CategoryManagement();
              whole.ChannelManagement();
              whole.ChannelGroupManagement();
              whole.VariantManagement();
              whole.PriorityManagement();
              whole.ProductManagement();
             */
            whole.SalesPlanManagement();
            whole.VenueManagement();
            whole.AreaManagement();
            whole.GateManagement();
            whole.TribuneManagement();
            whole.TurnstileManagement();
            whole.VenueTemplateManagement();
            whole.BlockManagement();
            whole.SeatClassManagement();
            whole.TicketTemplateManagement();
            whole.VariantConfigurationManagement();
            whole.SeatClassConfigurationManagement();
            whole.PrinterManagement();
            whole.LeaugeManagement();
            whole.TeamManagement();
            whole.OrganizerManagement();
            whole.GenreManagement();
            whole.SubGenreManagement();
            whole.SponsorManagement();
            whole.EventGroupManagement();
            whole.SerieManagement();
            whole.EventManagement1();
            whole.BookingActionTypes();
            whole.ACSetting();
            whole.TelegramQueueManagement();
            whole.TelegramManagement();
            whole.Clients();
            whole.Users();
            whole.Roles();
            whole.ApprovableUsers();
            whole.Terminals();
            //whole.AdvancedSearch();
            whole.EntryPoint();  
         }
    }
}
