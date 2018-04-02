namespace EventMenu
{
    class Program12
    {
        static void Main(string[] args)
        {
            EventManagementMenu eventManagementMenu = new EventManagementMenu();

            eventManagementMenu.SerieManagement();
            eventManagementMenu.EventManagement1();
            eventManagementMenu.EventGroupManagement();
            eventManagementMenu.ChannelGroupManagement();
            eventManagementMenu.SalesPlanManagement();
            eventManagementMenu.TicketTemplateManagement();
            
        }
    }
}
