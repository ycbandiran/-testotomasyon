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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.LeaugeManagement();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.TeamManagement();

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            SecurityManagement securityManagement = new SecurityManagement();

            securityManagement.Roles();

        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.OrganizerManagement();

        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.GenreManagement();

        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.SubGenreManagement();

        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.SponsorManagement();

        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.EventGroupManagement();

        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.SerieManagement();

        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.EventManagement1();

        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            VenueTests venueTests = new VenueTests();

            venueTests.VenueManagement();

        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            VenueTests venueTests = new VenueTests();

            venueTests.AreaManagement();

        }

        private void Button_Click_25(object sender, RoutedEventArgs e)
        {
            VenueTests venueTests = new VenueTests();

            venueTests.GateManagement();

        }

        private void Button_Click_26(object sender, RoutedEventArgs e)
        {
            VenueTests venueTests = new VenueTests();

            venueTests.TribuneManagement();

        }

        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            VenueTests venueTests = new VenueTests();

            venueTests.TurnstileManagement();

        }

        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            VenueTests venueTests = new VenueTests();

            venueTests.VenueTemplateManagement();

        }

        private void Button_Click_29(object sender, RoutedEventArgs e)
        {
            VenueTests venueTests = new VenueTests();

            venueTests.BlockManagement();

        }

        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            VenueTests venueTests = new VenueTests();

            venueTests.SeatClassManagement();

        }

        private void Button_Click_31(object sender, RoutedEventArgs e)
        {
            ACManagement aCManagement = new ACManagement();

            aCManagement.ACSetting();

        }

        private void Button_Click_32(object sender, RoutedEventArgs e)
        {
            ACManagement aCManagement = new ACManagement();

            aCManagement.TelegramManagement();

        }

        private void Button_Click_33(object sender, RoutedEventArgs e)
        {
            ACManagement aCManagement = new ACManagement();

            aCManagement.TelegramQueueManagement();

        }

        private void Button_Click_34(object sender, RoutedEventArgs e)
        {
            InventoryTests inventoryTests = new InventoryTests();

            inventoryTests.VariantManagement();

        }

        private void Button_Click_35(object sender, RoutedEventArgs e)
        {
            InventoryTests inventoryTests = new InventoryTests();

            inventoryTests.CategoryManagement();

        }

        private void Button_Click_36(object sender, RoutedEventArgs e)
        {
            InventoryTests inventoryTests = new InventoryTests();

            inventoryTests.ChannelManagement();

        }

        private void Button_Click_37(object sender, RoutedEventArgs e)
        {
            InventoryTests inventoryTests = new InventoryTests();

            inventoryTests.ChannelGroupManagement();

        }

        private void Button_Click_38(object sender, RoutedEventArgs e)
        {
            InventoryTests inventoryTests = new InventoryTests();

            inventoryTests.PriorityManagement();

        }

        private void Button_Click_39(object sender, RoutedEventArgs e)
        {
            InventoryTests inventoryTests = new InventoryTests();

            inventoryTests.ProductManagement();

        }

        private void Button_Click_40(object sender, RoutedEventArgs e)
        {
            InventoryTests inventoryTests = new InventoryTests();

            inventoryTests.SalesPlanManagement();

        }

        private void Button_Click_41(object sender, RoutedEventArgs e)
        {
            PrintingManagement printing = new PrintingManagement();

            printing.TicketTemplateManagement();

        }

        private void Button_Click_42(object sender, RoutedEventArgs e)
        {
            PrintingManagement printing = new PrintingManagement();

            printing.VariantConfigurationManagement();

        }

        private void Button_Click_43(object sender, RoutedEventArgs e)
        {
            PrintingManagement printing = new PrintingManagement();

            printing.PrinterManagement();

        }

        private void Button_Click_44(object sender, RoutedEventArgs e)
        {
            PrintingManagement printing = new PrintingManagement();

            printing.SeatClassConfigurationManagement();

        }

        private void Button_Click_45(object sender, RoutedEventArgs e)
        {
            PaymentTests paymentTest = new PaymentTests();

            paymentTest.PaymentGateway();

        }

        private void Button_Click_46(object sender, RoutedEventArgs e)
        {
            PaymentTests paymentTest = new PaymentTests();

            paymentTest.BinNumberGroup();

        }

        private void Button_Click_47(object sender, RoutedEventArgs e)
        {
            PaymentTests paymentTest = new PaymentTests();

            paymentTest.BinNumber();

        }

        private void Button_Click_48(object sender, RoutedEventArgs e)
        {
            PaymentTests paymentTest = new PaymentTests();

            paymentTest.PaymentPlan();

        }

        private void Button_Click_49(object sender, RoutedEventArgs e)
        {
            SecurityManagement securityManagement = new SecurityManagement();

            securityManagement.Clients();

        }

        private void Button_Click_50(object sender, RoutedEventArgs e)
        {
            SecurityManagement securityManagement = new SecurityManagement();

            securityManagement.Users();

        }

        private void Button_Click_51(object sender, RoutedEventArgs e)
        {
            SecurityManagement securityManagement = new SecurityManagement();

            securityManagement.ApprovableUsers();

        }

        private void Button_Click_52(object sender, RoutedEventArgs e)
        {
            SecurityManagement securityManagement = new SecurityManagement();

            securityManagement.Terminals();

        }

        private void Button_Click_53(object sender, RoutedEventArgs e)
        {
            SecurityManagement securityManagement = new SecurityManagement();

            securityManagement.EntryPoint();

        }
    }
}
