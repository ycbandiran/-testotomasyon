using Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Printing;
using Event;


namespace Security
{
    public class SecurityManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        PrintingManagement _printing;
        EventManagement _event;

        public SecurityManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Security modül testi başladı.");
            
        }


        public void Clients()
        {
            _helper.GivePassInfo("Clients modül testi başladı.");

            try
            {
                //Users Url gidilir 
                _helper.GoToUrl("http://localhost:4200/client/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='client-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                string Name = _helper.GetTextByName("name");

                //Secret alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("secret");
                string Secret = _helper.GetTextByName("secret");

                //Client Id alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("clientId");
                string ClientId = _helper.GetTextByName("clientId");

                //Allowed Origin alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("allowedOrigin");
                string allowedOrigin = _helper.GetTextByName("allowedOrigin");

                //Refresh Token Life Time alanına rastgele bir int girilir
                _helper.SetRandomIntegerByName("refreshTokenLifeTime", 10, 10);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='client-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.Users) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void Users()
        {
            _helper.GivePassInfo("Users modül testi başladı.");

            try
            {
                //Users Url gidilir 
                _helper.GoToUrl("http://localhost:4200/bookingoperator/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='bookingoperator-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //First Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("firstname");
                string FirstName = _helper.GetTextByName("firstname");

                //Last Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("lastname");

                //MobilePhone alanına rastgele bir int girilir
                _helper.SetRandomIntegerByName("MobilePhone", 10, 10);

                //User Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("username");

                //Password alanına rastgele bir değer girilir
                _helper.SetRandomIntegerByName("password", 5, 8);

                //Random Email girilir
                _helper.SetRandomEmailByName("email");

                //Operator Image alanına random resim eklenir
                _helper.SetRandomFileByXpath("//*[@id='bookingoperator-crud--user-form']/div/div/fieldset[1]/div/form/div[3]/div/div/file-upload/div/input", @"C:\Images\");

                //Add Role butonuna tıklanır
                _helper.ClickByName("AddRoleButton");

                System.Threading.Thread.Sleep(2000);

                //Role seçimi yapılır
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");

                //TERMINAL RIGHTS BOLUMU YAPILACAK (ADD TERMINAL RIGHTS BUTONU HTML DE NAME VERILDI)!!!!!!!

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.Users) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void Roles()
        {
            _helper.GivePassInfo("Roles modül testi başladı.");

            try
            {
                //Roles Url git
                _helper.GoToUrl("http://localhost:4200/scrole/list");

                //Roles sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='scrole-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir text girilir
                _helper.SetRandomTextByName("name");

                //Description alanına rastgele bir text girilir
                _helper.SetRandomTextByXPath("//*[@id='scrole-crud--role-form']/div/fieldset/form/div[2]/div/textarea");

                //Rastgele yüzde girilir
                _helper.SetRandomIntegerByName("filterBackOfficeTxt", 1, 100);

                //Business Rights butonuna tıklar
                _helper.ClickByXPath("//*[@id='tabControl']/li[2]/a");

                //Rastgele yüzde girilir
                _helper.SetRandomIntegerByName("filterBusinessTxt", 1, 100);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='scrole-crud--role-form']/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.Roles) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void ApprovableUsers()
        {
            _helper.GivePassInfo("Approvable Users modül testi başladı.");

            try
            {
                //ApprovableUsers url git
                _helper.GoToUrl("http://localhost:4200/scapprovableuser/list");

                //User seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='scapprovableuser-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Approve butonuna tıklar
                _helper.ClickByName("AproveButton");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.ApprovableUsers) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void Terminals()
        {
            _helper.GivePassInfo("Terminals modül testi başladı.");

            try
            {
                //Terminals url git
                _helper.GoToUrl("http://localhost:4200/terminal/list");

                //Terminals sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='terminal-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Terminal Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='terminal-crud--form']/div/div/form/fieldset/div[2]/div/div[1]/file-upload/div/input", @"C:\Images\");

                //Ticket Printer seçimi yapılır
                _helper.ClickByName("TicketPrinter");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByName("lookupSelect");

                //Add Organizer butonuna tıkla
                _helper.ClickByName("AddOrganizerButton");

                System.Threading.Thread.Sleep(2000);

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/p-dialog[1]/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.Terminals) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        //Advanced Search eklenecek!!
        /*public void AdvancedSearch()
        {
            try
            {
                //Advanced Search butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/advancedsearch/list");

                //Genre Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='genre-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //General Genre alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Add SubGenre butonuna tıklanır
                _helper.ClickByXPath("//*[@id='genre-crud--form']/div/div/form/fieldset[2]/tabset/div/tab/div/div[1]/button");

                //Leauge seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='genre-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("//*[@id='genre-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='genre-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.AdvancedSearch) + exception.Message);
            }
        }
        */

        public void EntryPoint()
        {
            _helper.GivePassInfo("Entry Point modül testi başladı.");

            try
            {
                //Entry Point url git
                _helper.GoToUrl("http://localhost:4200/entrypoint/list");

                //Entry Point sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='entrypoint-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Entry Point Name alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Entry Point Description alanına rastgele bir text girilir
                _helper.SetRandomTextByXPath("//*[@id='entrypoint-crud--form']/div/div/form/fieldset/div/div/div[2]/input");

                //Entity Point seçimi yapılır
                _helper.ClickByName("EntityPoint");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByName("lookupSelect");

                //Description alanına random text girilir
                _helper.SetRandomTextByName("entryPointDetailProxyDescription");

                //Order no alanına rastgele int girilir
                _helper.SetRandomIntegerByName("entryPointDetailOrderNo", 100, 1000);

                //Add butonuna tıklanır
                _helper.ClickByName("AddButton1");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='entrypoint-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                _helper.CatchExceptionPopUp();

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.EntryPoint) + exception.Message);
                _helper.ErrorLogging(exception);
                
            }
        }
    }    
}


