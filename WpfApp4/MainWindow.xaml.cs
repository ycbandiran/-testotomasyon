using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AllModulesTesting;
using Helpers;
using AC;
using BlackList;
using Booking;
using Contact;
using Event;
using EventMenu;
using Inventory;
using Payment;
using Printing;
using QuickVenue;
using Security;
using Venue;

namespace FormApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestingWhole whole = new TestingWhole();

            whole.Contacts();
            whole.NationalIDManagement();
            whole.CategoryManagement();
            whole.ChannelManagement();
            whole.ChannelGroupManagement();
            whole.VariantManagement();
            whole.PriorityManagement();
            whole.ProductManagement();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ContactManagement contactManagement = new ContactManagement();

            contactManagement.Contacts();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InventoryTests inventoryTests = new InventoryTests();

            inventoryTests.CategoryManagement();
            inventoryTests.ChannelManagement();
            inventoryTests.ChannelGroupManagement();
            inventoryTests.VariantManagement();
            inventoryTests.PriorityManagement();
            inventoryTests.ProductManagement();
            inventoryTests.SalesPlanManagement();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ACManagement aCManagement = new ACManagement();

            aCManagement.ACSetting();
            aCManagement.TelegramQueueManagement();
            aCManagement.TelegramManagement();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            VenueTests venueTests = new VenueTests();

            venueTests.VenueManagement();
            venueTests.AreaManagement();
            venueTests.GateManagement();
            venueTests.TribuneManagement();
            venueTests.TurnstileManagement();
            venueTests.VenueTemplateManagement();
            venueTests.BlockManagement();
            venueTests.SeatClassManagement();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            VenueCreate venueCreate = new VenueCreate();

            venueCreate.VenueCreate1();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            BlackListManagement blackListManagement = new BlackListManagement();

            blackListManagement.NationalIDManagement();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            BookingManagement bookingManagement = new BookingManagement();

            bookingManagement.BookingActionTypes();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.LeaugeManagement();
            eventManagement.TeamManagement();
            eventManagement.OrganizerManagement();
            eventManagement.GenreManagement();
            eventManagement.SubGenreManagement();
            eventManagement.SponsorManagement();
            eventManagement.EventGroupManagement();
            eventManagement.SerieManagement();
            eventManagement.EventManagement1();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            EventManagementMenu eventManagementMenu = new EventManagementMenu();

            eventManagementMenu.SerieManagement();
            eventManagementMenu.EventManagement1();
            eventManagementMenu.EventGroupManagement();
            eventManagementMenu.ChannelGroupManagement();
            eventManagementMenu.SalesPlanManagement();
            eventManagementMenu.TicketTemplateManagement();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            PaymentTests paymentTest = new PaymentTests();

            paymentTest.PaymentGateway();
            paymentTest.BinNumberGroup();
            paymentTest.BinNumber();
            paymentTest.PaymentPlan();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            PrintingManagement printing = new PrintingManagement();

            printing.PrinterManagement();
            printing.TicketTemplateManagement();
            printing.VariantConfigurationManagement();
            printing.SeatClassConfigurationManagement();
            printing.PrinterManagement();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            SecurityManagement securityManagement = new SecurityManagement();

            securityManagement.Clients();
            securityManagement.Users();
            securityManagement.Roles();
            securityManagement.ApprovableUsers();
            securityManagement.Terminals();
            //securityManagement.AdvancedSearch();
            securityManagement.EntryPoint();
        }
    }
}
