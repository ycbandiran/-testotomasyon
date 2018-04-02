namespace Event
{
    class Program5
    {
        static void Main(string[] args)
        {
            EventManagement eventManagement = new EventManagement();

            eventManagement.SerieManagement();
            eventManagement.EventManagement1();
            eventManagement.LeaugeManagement();
            eventManagement.TeamManagement();
            eventManagement.OrganizerManagement();
            eventManagement.GenreManagement();
            eventManagement.SubGenreManagement();
            eventManagement.SponsorManagement();
            eventManagement.EventGroupManagement();

        }
    }
}
