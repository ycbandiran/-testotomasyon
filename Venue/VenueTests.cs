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




namespace Venue
{
    public class VenueTests
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        
        //Oluşturulan yeni venue name i tutulmalıdır.
        public string VenueName;

        //Oluşturulan yeni venue name i tutulmalıdır.
        public string VenueTemplateName;

        //Oluşturulan yeni area name i tutulmalıdır.
        public string AreaName;

        //Oluşturulan yeni turnstile name i tutulmalıdır.
        public string TurnstileName;

        //Oluşturulan yeni gate name i tutulmalıdır.
        public string GateName;

        //Oluşturulan yeni tribune name i tutulmalıdır.
        public string TribuneName;

        //Oluşturulan yeni Seat Class name i tutulmalıdır.
        public string SeatClassName;
       
        public VenueTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(70));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");                    
        }

        public void VenueManagement()
        {
            _helper.GivePassInfo("Venue modül testi başladı.");

            try
            {
                //Venue Management butonuna tıklanır 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/venue/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venue-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                System.Threading.Thread.Sleep(2000);

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Venue name'i tutulur
                VenueName = _helper.GetTextByName("name");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Rastgele Country seçimi yapılır
                _helper.ClickByName("Country");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByName("lookupSelect");

                /*
                // Rastgele bir country seçeneğine tıklanır   //ŞU AN İÇERİK OLMADIĞI İÇİN SEÇİLMİYOR
                _helper.ClickRandomTagByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");
                */

                //City seçimi için seç butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[2]/div/div/div[2]/lookup-button/div/div/div/button");

                System.Threading.Thread.Sleep(2000);

                //Rastgele uygun olan City listesinden biri tıklanır
                _helper.ClickRandomTagByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");

                //Seç butonuna tıklanır
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                /*  //ŞU AN İÇERİK OLMADIĞI İÇİN SEÇİLMİYOR
                 County seçimi için seç butonu tıklanır.
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[2]/div/div/div[3]/lookup-button/div/div/div/button");                
                _helper.ClickRandomTagByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");                                          
                _driver.FindElement(By.XPath("//div[contains(@class ,'form-group pull-right')]//button[contains(tag(),'Select')]")).Click();
                */

                //Adres alanına text girişi yapılır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[3]/div/div/div[1]/textarea[2]");
                _helper.SetRandomTextByName("address");

                //Description alanına text girişi yapılır.
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[3]/div/div/div[2]/textarea[2]");
                _helper.SetRandomTextByName("venueDescription");

                //Public Transportation alanına text girişi yapılır.
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[3]/div/div/div[3]/textarea[2]");
                _helper.SetRandomTextByName("publicTransportationDescription");

                //Has parkin area alanında random seçim yapılır
                int result = _helper.ClickRandomRadioButton("//*[@id='venue-crud--form']/div/div/form/fieldset[4]/div/div/div[1]/div/label[1]/input", "//*[@id='venue-crud--form']/div/div/form/fieldset[4]/div/div/div[1]/div/label[2]/input");
                if (result == 1)
                {
                    //Parking Area Capacity alanına random bir değer girilmesi 
                    _helper.SetRandomIntegerByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[5]/div/div/div/input", 30, 100);
                }

                //Latitude alanının random olarak girilmesi
                _helper.SetTextByName("latitude", _helper.GetRandomLatitude());

                //Longitude alanının random olarak girilmesi
                _helper.SetTextByName("longitude", _helper.GetRandomLatitude());

                //Logo için bir resim seçilmesi                
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"C:\Images\");

                //Venue Image eklenir
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"C:\Images\");

                //Panaromik Image eklenir
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"C:\Images\");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(4000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.VenueManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void AreaManagement()
        {
            _helper.GivePassInfo("Area modül testi başladı.");

            try
            {
                // Area Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/area/list");

                //Area Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='area-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                System.Threading.Thread.Sleep(2000);

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Kaydedilen Area name'i tutulur
                AreaName = _helper.GetTextByName("name");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır
                _helper.ClickByName("Venue");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByName("lookupSelect");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.AreaManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void GateManagement()
        {
            _helper.GivePassInfo("Gate modül testi başladı.");

            try
            {
                // Gate Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/gate/list");

                //Gate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='gate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[1]");

                System.Threading.Thread.Sleep(2000);

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Area name'i tutulur
                GateName = _helper.GetTextByName("name");

                //Code alanına random 5 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 5);

                //Venue seçimi yapılır
                _helper.ClickByName("Venue");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByName("lookupSelect");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='gate-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.GateManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void TribuneManagement()
        {
            _helper.GivePassInfo("Tribune modül testi başladı.");

            try
            {
                // Tribune Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/tribune/list");

                //Tribune Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='tribune-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                System.Threading.Thread.Sleep(2000);

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Tribune name'i tutulur
                TribuneName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Sponsor alanı için random text girilir
                _helper.SetRandomTextByName("sponsor");

                //Venue seçimi yapılır
                _helper.ClickByName("Venue");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByName("lookupSelect");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tribune-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                //View from tribune alanı için herhangi bir görsel seçilir
                //_helper.SetRandomFileByXpath("//*[@id='tribune-crud--form']/div/div/form/fieldset[2]/div/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //View from field alanı için herhangi bir görsel seçilir
                //_helper.SetRandomFileByXpath("//*[@id='tribune-crud--form']/div/div/form/fieldset[2]/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TribuneManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void TurnstileManagement()
        {
            _helper.GivePassInfo("Turnstile modül testi başladı.");

            try
            {
                // Turnstile Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/turnstile/list");

                //Turnstile Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='turnstile-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                System.Threading.Thread.Sleep(2000);

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Turnstile name'i tutulur
                TurnstileName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır
                _helper.ClickByName("Venue");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByName("lookupSelect");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='turnstile-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TurnstileManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void VenueTemplateManagement()
        {
            _helper.GivePassInfo("Venue Template modül testi başladı.");

            try
            {
                // VenueTemplate Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/venuetemplate/list");

                //VenueTemplate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='venuetemplate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                System.Threading.Thread.Sleep(2000);

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");
                VenueTemplateName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır
                _helper.ClickByName("Venue");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByName("lookupSelect");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venuetemplate-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.VenueTemplateManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void BlockManagement()
        {
            _helper.GivePassInfo("Block modül testi başladı.");

            try
            {
                // Block Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/block/list");

                //Block Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                System.Threading.Thread.Sleep(2000);

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır
                _helper.ClickByName("Venue");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByName("lookupSelect");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);



                //EDIT BOLUMU:

                //BLock Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/block/list");

                //Block List den event seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Event Management sayfasında edit butonu tıklanır
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");

                System.Threading.Thread.Sleep(2000);

                //Add new butonuna tıklanır
                _helper.ClickByName("AddNewButton");

                System.Threading.Thread.Sleep(2000);

                //Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name2");

                //Venue Template yapılır
                _helper.ClickByName("VenueTemplate");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(VenueTemplateName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Area seçimi yapılır
                _helper.ClickByName("Area");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(AreaName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Tribune seçimi yapılır
                _helper.ClickByName("Tribune");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(TribuneName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Rastgele Type seçilir
                _helper.ClickRandomRadioButton("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[2]/div[2]/div/label[1]/input", "//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[2]/div[2]/div/label[2]/input");

                //Row Count alanı için random değer girilir
                _helper.SetRandomIntegerByName("rowCount", 10, 20);

                //Column Count alanı için random değer girilir
                _helper.SetRandomIntegerByName("columnCount", 10, 20);

                //Seat Class için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("selectedSeatType");

                //Sort Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refSeatSortTypeID");

                //Increment Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("seatSequentialType");

                //Rastgele Ignore Gaps seçilir ya da seçilmez
                _helper.ClickRandomCheckboxByName("ignoreGaps");

                //Row Naming için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("rowNameTypeId");

                //Seat Start Number alanı için random değer girilir
                _helper.SetRandomIntegerByName("seatStartNumber", 1, 5);

                //Free Text alanına random değer girilir
                _helper.SetRandomTextByName("freeTextField");

                //Rastgele Top to Bottom Row Naming seçilir
                _helper.ClickRandomCheckboxByName("isRowNamingOrderDesc");

                //Gate seçimi yapılır
                _helper.ClickByName("Gate");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(GateName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Turnstile seçimi yapılır
                _helper.ClickByName("Turnstile");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(TurnstileName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[3]/button[1]");

                //Add butonu tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[1]/div[1]/div[5]/button");

                System.Threading.Thread.Sleep(2000);

                //Create butonu tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[2]/div/div/input");

                System.Threading.Thread.Sleep(4000);

                //OLUŞTURULAN KOLTUKLARI SEÇİP SEATTYPE ATAR

                IWebElement From = _driver.FindElement(By.XPath("//*[@id='block-seat-container']/div[1]/div[1]"));
                IWebElement To = _driver.FindElement(By.XPath("//*[@id='block-seat-container']/div[10]/div[10]"));
                Actions act = new Actions(_driver);
                act.DragAndDrop(From, To).Build().Perform();

                System.Threading.Thread.Sleep(3000);

                //Seat Class selection yapılır
                _helper.SelectRandomDropdownElementByXPath("/html/body/div[12]/div[2]/div[1]/div/div/div[1]/div/div/select");

                //Gate seçimi yapılır
                _helper.ClickByXPath("/html/body/div[12]/div[2]/div[2]/div/div[1]/div[1]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(GateName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[3]/button[1]");

                //Turnstile seçimi yapılır
                _helper.ClickByXPath("/html/body/div[12]/div[2]/div[2]/div/div[1]/div[2]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(TurnstileName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[3]/button[1]");

                /* //Sayfayı scroll eder 
                 var element = _driver.FindElement(By.Id("SaveButton12"));
                 Actions actions = new Actions(_driver);
                 actions.MoveToElement(element);
                 actions.Perform();
                 */

                //Save butonuna tıklanır
                _helper.ClickByName("SaveButton12");

                System.Threading.Thread.Sleep(2000);

                //Save Block Layout butonuna tıklar
                _helper.ClickByXPath("//*[@id='blocklayoutseat']/input");

                System.Threading.Thread.Sleep(3000);

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[1]/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(4000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.BlockManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void SeatClassManagement()
        {
            _helper.GivePassInfo("Seat Class modül testi başladı.");

            try
            {
                // SeatClass Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/seatclass/list");

                //SeatClass Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='seatclass-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                System.Threading.Thread.Sleep(2000);

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Seat Class name'i tutulur
                SeatClassName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Color seçimi yapılır
                _helper.SetRandomColorByName("rgb");

                //Rastgele bir SeatType seçilir
                _helper.SelectRandomDropdownElementByName("SeatClassType");

                //Rastgele Visibility seçilir
                _helper.ClickRandomCheckboxByXPath("//*[@id='seatclass-crud--form']/div/div/form/fieldset/div[2]/div/div/p-checkbox/div/div[2]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='seatclass-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.SeatClassManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }
    }
}

