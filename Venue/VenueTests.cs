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
    class VenueTests
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        //public IWebElement webElement;

        //oluşturulan yeni venue id si tutulmalıdır.
        //  string venue_id;

        public VenueTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

        public void VenueManagement()
        {
            try
            {
                //Venue Management butonuna tıklanır 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/venue/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venue-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");
                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                string venueName = _helper.GetTextByName("name");
                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Country seçimi için select butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[2]/div/div/div[1]/lookup-button/div/div/div/button");

                //Şimdilik listenin en üstündeki Country'i seçer
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");

                /*
                // Rastgele bir country seçeneğine tıklanır
                _helper.ClickRandomTagByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");
                */

                //seç butonuna tıklanır
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //City seçimi için seç butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[2]/div/div/div[2]/lookup-button/div/div/div/button");

                //Rastgele uygun olan City listesinden biri tıklanır
                _helper.ClickRandomTagByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");

                //Seç butonuna tıklanır
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                /*
                 County seçimi için seç butonu tıklanır.
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[2]/div/div/div[3]/lookup-button/div/div/div/button");
                
                 Rastgele uygun olan County listesinden biri tıklanır
                _helper.ClickRandomTagByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");
                
                
                //Seç butonuna tıklanır
                   _driver.FindElement(By.XPath("//div[contains(@class ,'form-group pull-right')]//button[contains(tag(),'Select')]")).Click();
                */

                //Adres alanına text girişi yapılır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[3]/div/div/div[1]/textarea[2]");
                _helper.SetRandomTextByName("address");
                //_helper.GetRandomString();

                //Description alanına text girişi yapılır.
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[3]/div/div/div[2]/textarea[2]");
                //_helper.GetRandomString();
                _helper.SetRandomTextByName("venueDescription");

                //Public Transportation alanına text girişi yapılır.
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[3]/div/div/div[3]/textarea[2]");
                //_helper.GetRandomString();
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
                //*[@id="venue-crud-166--form"]/div/div/form/fieldset[4]/div/div/div[2]/input

                //Longitude alanının random olarak girilmesi
                _helper.SetTextByName("longitude", _helper.GetRandomLatitude());

                //Logo için bir resim seçilmesi                
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");
                /*IWebElement element1 = _driver.FindElement(By.XPath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/input"));
                element1.SendKeys("D:\\Users\\yigitb\\Desktop\\BjkLogo.PNG");
                */

                //Venue Image eklenir
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");
                /*IWebElement element2 = _driver.FindElement(By.XPath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/input"));
                element2.SendKeys("D:\\Users\\yigitb\\Desktop\\BjkLogo.PNG");
                */

                //Panaromik Image eklenir
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");
                /*IWebElement element3 = _driver.FindElement(By.XPath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/input"));
                element3.SendKeys("D:\\Users\\yigitb\\Desktop\\BjkLogo.PNG");
                */
                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                //Kaydedilen Venue name'i tutulur
                //_helper.GetTextByPath("//*[@id='venue-crud-417;formtype=read--form']/div/div/form/fieldset[1]/div/div/div[1]/input");   

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.VenueManagement) + exception.Message);
            }
        }


        public void AreaManagement()
        {
            try
            {
                // Area Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/area/list");

                //Area Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='area-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                /*
                _driver.FindElement(By.ClassName("btn-default")).Click();
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input");
                _helper.SetTextByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input","");
                _driver.FindElement(By.XPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                */

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.AreaManagement) + exception.Message);
            }
        }
        public void BlockManagement()
        {
            try
            {
                // Block Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/block/list");

                //Block Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='main']/block-crud/div/div/div[2]/form/div/div[3]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                /*
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input");
                _helper.SetTextByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input", _helper.GetTextByPath(""));
                _driver.FindElement(By.XPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                */

                //NOT: Url de en sondaki rakam venue nün id si bu id get edilip set edilebilir.

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.BlockManagement) + exception.Message);
            }
        }

        public void GateManagement()
        {
            try
            {
                // Gate Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/gate/list");

                //Gate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='gate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[1]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 5 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 5);

                //Venue seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='gate-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                /*
                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input");
                _helper.SetTextByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input", _helper.GetTextByPath(""));
                _driver.FindElement(By.XPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                */

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='gate-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.GateManagement) + exception.Message);
            }
        }

        public void TribuneManagement()
        {
            try
            {
                // Tribune Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/tribune/list");

                //Tribune Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='tribune-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Sponsor alanı için random text girilir
                _helper.SetRandomTextByName("sponsor");

                //Venue seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='tribune-crud--form']/div/div/form/fieldset[2]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                /*
                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input");
                _helper.SetTextByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input", _helper.GetTextByPath(""));
                _driver.FindElement(By.XPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                */

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
            }
        }

        public void TurnstileManagement()
        {
            try
            {
                // Turnstile Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/turnstile/list");

                //Turnstile Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='turnstile-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='turnstile-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                /*
                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input");
                _helper.SetTextByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input", _helper.GetTextByPath(""));
                _driver.FindElement(By.XPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                */

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tribune-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TurnstileManagement) + exception.Message);
            }
        }

        public void VenueTemplateManagement()
        {
            try
            {
                // VenueTemplate Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/venuetemplate/list");

                //VenueTemplate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='venuetemplate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='venuetemplate-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                /*
                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input");
                _helper.SetTextByXPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input", _helper.GetTextByPath(""));
                _driver.FindElement(By.XPath("/html/body/div[4]/div[2]/lookup/div/div[1]/div[4]/div/div/input")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                */

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venuetemplate-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.VenueTemplateManagement) + exception.Message);
            }
        }

        public void SeatClassManagement()
        {
            // SeatClass Management butonuna tıkla
            _helper.GoToUrl("http://testbackoffice.netasticketing.com/seatclass/list");

            //SeatClass Management sayfasında add new butonu tıklanır
            _helper.ClickByXPath("//*[@id='seatclass-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

            //Name alanına random değer girilir
            _helper.SetRandomTextByName("name");

            //Code alanına random 3 haneli code girilir.
            _helper.SetLimitedRandomStringByName("code", 3);

            //Color seçimi yapılır
            _helper.SetRandomColorByName("color");

            //Rastgele bir SeatType seçilir
            _helper.ClickRandomTagByXPath("//*[@id='seatclass-crud--form']/div/div/form/fieldset/div[1]/div/div[4]/select", "tr");

            //Rastgele Visibility seçilir
            _helper.ClickRandomCheckbox("//*[@id='seatclass-crud--form']/div/div/form/fieldset/div[2]/div/div/p-checkbox/div/div[2]");
        }
    }
}

