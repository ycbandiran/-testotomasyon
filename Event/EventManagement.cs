using Helpers;
using Inventory;
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
using Venue;
using Payment;
using Printing;


namespace Event
{
    public class EventManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        InventoryTests _inventory;
        VenueTests _venue;
        PaymentTests _payment;
        PrintingManagement _printing;

        //Oluşturulan yeni Serie name i tutulmalıdır.
        public string SerieName;

        //Oluşturulan yeni Leauge name i tutulmalıdır.
        public string LeaugeName;

        //Oluşturulan yeni Leauge name i tutulmalıdır.
        public string TeamName;

        //Oluşturulan yeni Organizer name i tutulmalıdır.
        public string OrganizerName;

        //Oluşturulan yeni Event Group name i tutulmalıdır.
        public string EventGroupName;

        //Oluşturulan yeni Sponsor name i tutulmalıdır.
        public string SponsorName;

        //Oluşturulan yeni Sub Genre name i tutulmalıdır.
        public string SubGenreName;

        //Oluşturulan yeni Genre name i tutulmalıdır.
        public string GenreName;



        public EventManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Event modül testi başladı.");
           
        }


       
        public void LeaugeManagement()
        {
            _helper.GivePassInfo("Leauge modül testi başladı.");

            try
            {
                //Leauge Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/league/list");

                //Leauge Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='league-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Leauge name'i tutulur
                LeaugeName = _helper.GetTextByName("name");

                //Random Leauge Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='league-crud--form']/div/div/form/fieldset/div/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='league-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.LeaugeManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void TeamManagement()
        {
            _helper.GivePassInfo("Team modül testi başladı.");

            try
            {
                //Team Management url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/team/list");

                //Team Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='team-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Team alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Team name'i tutulur
                TeamName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //View From Field Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='team-crud--form']/div/div/form/fieldset/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Add Leauge butonuna tıklanır
                _helper.ClickByXPath("//*[@id='team-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");
                                          
                System.Threading.Thread.Sleep(2000);

                //Leauge seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='team-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _driver.FindElement(By.Name("searchText")).SendKeys(LeaugeName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("//*[@id='team-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='team-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TeamManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void OrganizerManagement()
        {
            _helper.GivePassInfo("Organizer modül testi başladı.");

            try
            {
                // Organizer Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/organizer/list");

                //Organizer Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='organizer-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Organizer Name alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Organizer name'i tutulur
                OrganizerName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Trade Name alanına random text girilir
                _helper.SetRandomTextByName("TradeName");

                //Adress alanı için random text girilir
                _helper.SetRandomTextByName("Address");

                //Tax Administration alanı için random text girilir
                _helper.SetRandomTextByName("Administration");

                //Tax Number alanı için random değer girilir
                _helper.SetRandomIntegerByName("Number", 1000, 10000);

                //View From Field Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='organizer-crud--form']/div/div/form/fieldset[3]/div/div/div/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                /*
                //Add Terminal butonuna tıklanır
                _helper.ClickByXPath("//*[@id='organizer-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                //Random Selection yapılır
                _helper.SelectRandomDropdownElementByName("")
                */

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='organizer-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.OrganizerManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void GenreManagement()
        {
            _helper.GivePassInfo("Genre modül testi başladı.");

            try
            {
                //Genre Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/genre/list");

                //Genre Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='genre-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //General Genre alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Genre name'i tutulur
                GenreName = _helper.GetTextByName("name");

                //Add SubGenre butonuna tıklanır
                _helper.ClickByXPath("//*[@id='genre-crud--form']/div/div/form/fieldset[2]/tabset/div/tab/div/div[1]/button");

                //Leauge seçimi yapılır(GEÇİCİ)
                _driver.FindElement(By.Name("searchText")).SendKeys(LeaugeName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("//*[@id='genre-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("//*[@id='genre-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='genre-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.GenreManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void SubGenreManagement()
        {
            _helper.GivePassInfo("Sub Genre modül testi başladı.");

            try
            {
                // VenueTemplate Management url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/subgenre/list");

                //VenueTemplate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='subgenre-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //SubGenre alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Sub Genre name'i tutulur
                SubGenreName = _helper.GetTextByName("name");

                //Vat Rat alanına random yüzde girilir.
                _helper.SetRandomIntegerByName("TaxFee", 1, 100);

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='subgenre-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.SubGenreManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void SponsorManagement()
        {
            _helper.GivePassInfo("Sponsor modül testi başladı.");

            try
            {

                // Sponsor Management url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/sponsor/list");

                //Sponsor Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='sponsor-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Sponsor alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Sponsor name'i tutulur
                SponsorName = _helper.GetTextByName("name");

                //View From Field random Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='sponsor-crud--form']/div/div/form/fieldset/div/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Save butonuna tıklar
                _helper.ClickByXPath("//*[@id='sponsor-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.SponsorManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void EventGroupManagement()
        {
            _helper.GivePassInfo("Event Group modül testi başladı.");

            try
            {
                //Event Group Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/eventgroup/list");

                //Event Group Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='eventgroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Event Group alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Event Group name'i tutulur
                EventGroupName = _helper.GetTextByName("name");

                //Description alanına random text girilir
                _helper.SetRandomTextByName("description");

                //Random Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='eventgroup-crud--form']/div/div/form/fieldset/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventgroup-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.GenreManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void SerieManagement()
        {
            _helper.GivePassInfo("Serie modül testi başladı.");

            try
            {
                //Serie Management Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/serie/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='serie-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");

                //oluşturulan yeni Serie name i tutulmalıdır.
                SerieName = _helper.GetTextByName("name");

                //Genre seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[7]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + GenreName);
                //_driver.FindElement(By.XPath("/html/body/div[7]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Team seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[8]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + TeamName);
                //_driver.FindElement(By.XPath("/html/body/div[8]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[2]");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Sub Genre için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refSubGenreID");

                //Rastgele Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //TicketType seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[3]/button[1]");

                
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDating = _helper.SetRandomDateTimeByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[2]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDating);
                _helper.SetDateTimeByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[3]/p-calendar/span/input", finishDate);
                _helper.WaitUntilPageLoad();

                //Next butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/input");

                System.Threading.Thread.Sleep(3000);

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                /* _driver.FindElement(By.Name("searchText")).SendKeys("" + _venue.VenueName);
                 _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                 System.Threading.Thread.Sleep(2000);*/
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[3]/button[1]");

                //SalesPlan seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                /* System.Threading.Thread.Sleep(2000);
                 _driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.SalesPlanName);
                 _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);*/
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[3]/button[1]");

                //League seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[12]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + LeaugeName);
                //_driver.FindElement(By.XPath("/html/body/div[12]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[3]/button[1]");

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[14]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + OrganizerName);
                //_driver.FindElement(By.XPath("/html/body/div[14]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");
                             
                //League Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Venue Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                /* System.Threading.Thread.Sleep(2000);
                 _driver.FindElement(By.Name("searchText")).SendKeys("" + _venue.VenueTemplateName);
                 _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);*/
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[3]/button[1]");

                //Event Group seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[16]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + EventGroupName);
                //_driver.FindElement(By.XPath("/html/body/div[16]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[3]/button[1]");

                //Seat Class Configuraton seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                /* _driver.FindElement(By.Name("searchText")).SendKeys("" + _printing.SeatClassConfigurationName);
                 _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                 System.Threading.Thread.Sleep(2000);*/
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Next butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[4]/input[2]");

                System.Threading.Thread.Sleep(3000);

                //Payment Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                /* _driver.FindElement(By.Name("searchText")).SendKeys("" + _payment.PaymentPlanName);
                 _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                 System.Threading.Thread.Sleep(2000);*/
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                /* _driver.FindElement(By.Name("searchText")).SendKeys("" + _printing.TicketTemplateName);
                 _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                 System.Threading.Thread.Sleep(2000);*/
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Cofiguration Configuraton seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                /* _driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.VariantName);
                 _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                 System.Threading.Thread.Sleep(2000);*/
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Sponsor seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[18]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + SponsorName);
                //_driver.FindElement(By.XPath("/html/body/div[18]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[3]/button[1]");

                //Home Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Description alanını doldurur
                _helper.SetRandomTextByName("detailPageDescription");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);
            

                //FAZ 3 DE EDIT BOLUMU YAPILACAK !!! 


            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.SerieManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void EventManagement1()
        {
            _helper.GivePassInfo("Event1 modül testi başladı.");

            try
            {
                // Event Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/event/list");

                //Event Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Event alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Event Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);
                
                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[7]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + OrganizerName);
                //_driver.FindElement(By.XPath("/html/body/div[7]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                /* System.Threading.Thread.Sleep(2000);
                 _driver.FindElement(By.Name("searchText")).SendKeys("" + _venue.VenueName);
                 _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);*/
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Venue Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
               /* _driver.FindElement(By.Name("searchText")).SendKeys("" + _venue.VenueTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);*/
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[3]/button[1]");

                //Home Team seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[3]/button[1]");
                
                //Away Team seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[3]/button[1]");
                
                // Başlangıç tarihini belirler
                DateTime startDate3 = _helper.SetRandomDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[3]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate3 = _helper.SetRandomDateTimeAfterThisDateTime(startDate3);
                System.Threading.Thread.Sleep(2000);
                _helper.SetDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[3]/p-calendar/span/input", finishDate3);
                _helper.WaitUntilPageLoad();
                

                //Home Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Away Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");
                
                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[5]/input");

                System.Threading.Thread.Sleep(2000);

                //DETAİL BOLUMU

                //Genre seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[13]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + GenreName);
                //_driver.FindElement(By.XPath("/html/body/div[13]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[13]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[13]/div[2]/lookup/div/div[3]/button[1]");

                //Random SubGenre seçimi yapılır
                _helper.SelectRandomDropdownElementByName("refSubGenreID");

                //Random Week seçimi yapılır
                _helper.SelectRandomDropdownElementByName("week");

                //League seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[14]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + GenreName);
                //_driver.FindElement(By.XPath("/html/body/div[14]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");

                //Sponsor seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[15]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + SponsorName);
                //_driver.FindElement(By.XPath("/html/body/div[15]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[3]/button[1]");
                
                //Door Opening time seçilir
                DateTime startDate4 = _helper.SetRandomDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[3]/p-calendar/span/input");               
                _helper.WaitUntilPageLoad();

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[4]/input[2]");

                System.Threading.Thread.Sleep(2000);

                //CONF BOLUMU

                //Payment Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                /*_driver.FindElement(By.Name("searchText")).SendKeys("" + _payment.PaymentPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);*/
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[3]/button[1]");

                //Sales Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                /*_driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.SalesPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000); */
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Type seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[3]/button[1]");

                //Event Group seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.XPath("/html/body/div[19]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys("" + EventGroupName);
                //_driver.FindElement(By.XPath("/html/body/div[19]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[3]/button[1]");

                //Seat Class Configuration seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
               /* _driver.FindElement(By.Name("searchText")).SendKeys("" + _printing.SeatClassConfigurationName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);*/
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Configuration seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[3]/lookup-button/div/div/div/button");
               /* System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + _printing.VariantConfigurationName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);*/
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("//html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Primary Access seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[20]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[20]/div[2]/lookup/div/div[3]/button[1]");

                //Secondary Access seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[21]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[21]/div[2]/lookup/div/div[3]/button[1]");

                //Random Acs seçimi yapılır
                _helper.SelectRandomDropdownElementByName("eventType");

                //Random Acs Code girilir
                _helper.SetRandomTextByName("eventCode");

                //Ticket Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[4]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
               /* _driver.FindElement(By.Name("searchText")).SendKeys("" + _printing.TicketTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);*/
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Home Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Description 
                _helper.SetRandomTextByName("detailPageDescription");

                //Free Passcard Count
                _helper.SetRandomIntegerByName("freePasscardCount", 1, 50);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id'event-crud-1442--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);





                //EDIT BOLUMU:                                                                         //XPATH'LERİN DEĞİŞTİRİLMESİ GEREK !!!!

                /*
                //Event Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/event/list");

                //Event List den event seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Event Management sayfasında edit butonu tıklanır
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");

                System.Threading.Thread.Sleep(4000);

                //CATEGORY BOLUMU:

                //Catagory kısmına git
                _helper.ClickByXPath("//*[@id='tabControl']/li[4]/a");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud-1473--form']/div/div/form/fieldset/tabset/div/tab[4]/div[1]/div/div/div[2]/input[1]");

                System.Threading.Thread.Sleep(3000);

                //Category Mame için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refCategoryID");

                //Discount Rate için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refDiscountRateTypeID");

                //Price alanı için random değer girilir
                _helper.SetRandomIntegerByName("price", 500, 2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorycrud-1473-event--form']/div/div/form/fieldset/div[3]/div/div/input");
                System.Threading.Thread.Sleep(2000);

                //CHANNEL BOLUMU 

                //Channel seçimi yapılır
                //_helper.ClickByXPath("//*[@id='eventcategory-seatcategorychannelcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[1]/lookup-button/div/div/div/button");
                //System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.ChannelName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Display Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("displayName");

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorychannelcrud-1064-1473-118-event--form']/div/div/form/fieldset/div[2]/div/div[3]/input");
                System.Threading.Thread.Sleep(2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorychannelcrud-1064-1473-118-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                //TiCKET BOLUMU 

                //Channel seçimi yapılır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryticketcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.ChannelName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                //System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refTicketTypeID");

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryticketcrud-1064-1473-118-event--form']/div/div/form/fieldset/div[2]/div/div[3]/input");
                System.Threading.Thread.Sleep(2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryticketcrud-1064-1473-118-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                //VARIANT BOLUMU 

                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryvariantcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.ChannelName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                //System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Variant seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryvariantcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.VariantName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                //System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Value alanı için random değer girilir
                _helper.SetRandomIntegerByName("variantPriceValue", 500, 1000);

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryvariantcrud-1064-1473-118-event--form']/div/div/form/fieldset/div[4]/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryvariantcrud-1064-1473-118-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                //VARIANT BOLUMU 

                //Rate Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refDiscountRateTypeID");

                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.ChannelName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                //System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Product seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.ProductName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                //System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Product Value alanı için random değer girilir
                _helper.SetRandomIntegerByName("price", 500, 1000);

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1064-1473-118-event--form']/div/div/form/fieldset/div[3]/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1064-1473-118-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                

                //BENEFİCİARY BOLUMU

                
                 
                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorybeneficiarycrud-1015-1447-265-event--form']/div/div/form/fieldset/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + _inventory.ChannelName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                //System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refTicketTypeID");

                //Beneficiary için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refBeneficiaryID");

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorybeneficiarycrud-1064-1473-118-event--form']/div/div/form/fieldset/div[2]/div/div/input");
                System.Threading.Thread.Sleep(2000);

                //Close and finish butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorybeneficiarycrud-1064-1473-118-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");
                System.Threading.Thread.Sleep(7000);

                

                //BLOCK BOLUMU: (DİĞER FAZDA YAPILACAK)

                /*

                //VISA CONFIGURATION BOLUMU:

                
                //Vısa Conf butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tabControl']/li[6]/a");

                //Add New butonuna tıklanır
                _helper.ClickByXPath("//*[@id='blocklayoutgrid']/div[2]/input[1]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Visa End Date Control Strategy için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("visaEndDateControlStrategy");

                //Priority alanı için random değer girilir
                _helper.SetRandomIntegerByName("priority", 1, 10);

                //Update butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud-1465--form']/div/div/form/fieldset/tabset/div/tab[6]/div[1]/div/div[2]/div[2]/visa-configuration/div/form/div[4]/div/div/input");
                
                */

                //CARD RULE BOLUMU: (DİĞER FAZDA YAPILACAK)

                /*
                 
                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id'event-crud-1442--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

                */
            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.EventManagement1) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

    }
}


