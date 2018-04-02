namespace Security
{
    class Program9
    {
        static void Main(string[] args)
        {
            SecurityManagement securityManagement = new SecurityManagement();
/*
            securityManagement.Clients();
            securityManagement.Users();
            securityManagement.Roles();
            securityManagement.ApprovableUsers();
            securityManagement.Terminals();
            //securityManagement.AdvancedSearch();
  */
            securityManagement.EntryPoint();

        }
    }
}
