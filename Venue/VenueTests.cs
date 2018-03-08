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
            _driver = new ChromeDriver();
            _task = new WebDriverWait(_driver,TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver,_task,"YigitCan","1");
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

                // Rastgele bir country seçeneğine tıklanır
                _helper.ClickRandomTagByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");


                //seç butonuna tıklanır
                // Find an element

                IWebElement elementToClick = _driver.FindElement(By.XPath("Your xpath"));



                // Scroll the browser to the element's X position

                ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0," + elementToClick.getLocation().x + ")");



                // Click the element

                elementToClick.click();

                /*IWebDriver driver = new ChromeDriver();
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("window.scrollBy(737,604)", "");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                WaitUntilPageLoad();*/


                /*IWebElement button = _driver.FindElement(By.XPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]")); // locate the button, can be done with any other selector
                Actions action = new Actions(_driver);
                action.MoveToElement(button).Perform(); // move to the button
                button.Click();*/



                //City seçimi için seç butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[2]/div/div/div[2]/lookup-button/div/div/div");
               
                //Rastgele uygun olan City listesinden biri tıklanır
                _helper.ClickRandomTagByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");
                
                //Seç butonuna tıklanır
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");
                
                //County seçimi için seç butonu tıklanır.
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[2]/div/div/div[3]/lookup-button/div/div/div/button");
               
                //Rastgele uygun olan County listesinden biri tıklanır
                _helper.ClickRandomTagByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");

                //Seç butonuna tıklanır
                //   _driver.FindElement(By.XPath("//div[contains(@class ,'form-group pull-right')]//button[contains(tag(),'Select')]")).Click();

               
                //Adres alanına  tex girişi yapılır
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
                int result = _helper.ClickRandomRadioButton("//*[@id='venue-crud--form']/div/div/form/fieldset[4]/div/div/div[1]/div/label[1]/input","//*[@id='venue-crud--form']/div/div/form/fieldset[4]/div/div/div[1]/div/label[2]/input");
                if (result==1)
                {
                    //Parking Area Capacity alanına random bir değer girilmesi 
                    _helper.SetRandomIntegerByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[5]/div/div/div/input",30,100);
                }

                //Latitude alanının random olarak girilmesi
                _helper.SetTextByName("latitude", _helper.GetRandomLatitude());

                //*[@id="venue-crud-166--form"]/div/div/form/fieldset[4]/div/div/div[2]/input

                //Longitude alanının random olarak girilmesi
                _helper.SetTextByName("longitude", _helper.GetRandomLatitude());

                //Logo için bir resim seçilmesi
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\BjkLogo\");
                
                //*[@id="venue-crud-166--form"]/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input
                //*[@id="venue-crud--form"]/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input
                //Venue Image eklenir
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\BjkLogo\");

                //Panaromik Image eklenir
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\BjkLogo\");
                 
                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a/span[2]");
                //Gelen modal da OK tıklanır
                _helper.ClickByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div/div/div[3]/button[1]");

                //Kaydedilen Venue id si tutulur
                _helper.GetTextByPath("//*[@id='venue-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody");

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
                _helper.GoToUrl("http://backoffice.netasticketing.com/area/list");

                //Area Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='area-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi için look up açılır.
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");

                //Herhangi bir Venue seçimi yapılır

                _helper.ClickRandomTagByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");

                //Select butonu tıklanır
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a/span[2]");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div/div/div[3]/button[1]");


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
                _helper.GoToUrl("http://backoffice.netasticketing.com/block/list");

                //Block Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code",3);

                //VENUE SEÇİMİ YAPILACAK


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GateManagement()
        {
            try
            {
                // Gate Management butonuna tıkla
                _helper.GoToUrl("http://backoffice.netasticketing.com/gate/list");

                //Gate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='gate-list--default-widget]/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 5 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 5);

                //VENUE GİRİLECEKTİR
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void TribuneManagement()
        {
            try
            {
                // Tribune Management butonuna tıkla
                _helper.GoToUrl("http://backoffice.netasticketing.com/tribune/list");

                //Tribune Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='tribune-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Sponsor alanı için random text girilir
                _helper.SetRandomTextByName("sponsor");

                //VENUE SEÇİLECEK

                //View from tribune alanı için herhangi bir görsel seçilir
                _helper.SetRandomFileByXpath("//*[@id='tribune-crud--form']/div/div/form/fieldset[2]/div/div/div[2]/file-upload/div/input", @"D:\Users\kubra.ay\Desktop\Ekranlar\");

                //View from field alanı için herhangi bir görsel seçilir
                _helper.SetRandomFileByXpath("//*[@id='tribune-crud--form']/div/div/form/fieldset[2]/div/div/div[3]/file-upload/div/input", @"D:\Users\kubra.ay\Desktop\Ekranlar\");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void TurnstileManagement()
        {
            try
            {
                // Turnstile Management butonuna tıkla
                _helper.GoToUrl("http://backoffice.netasticketing.com/turnstile/list");

                //Turnstile Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='turnstile-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //VENUE SEÇİLECEKTİR
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void VenueTemplateManagement()
        {
            try
            {
                // VenueTemplate Management butonuna tıkla
                _helper.GoToUrl("http://backoffice.netasticketing.com/venuetemplate/list");

                //VenueTemplate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='venuetemplate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //VENUE SEÇİLECEKTİR

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SeatClassManagement()
        {
            // SeatClass Management butonuna tıkla
            _helper.GoToUrl("http://backoffice.netasticketing.com/seatclass/list");

            //SeatClass Management sayfasında add new butonu tıklanır
            _helper.ClickByXPath("//*[@id='seatclass-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

            //Name alanına random değer girilir
            _helper.SetRandomTextByName("name");

            //Code alanına random 3 haneli code girilir.
            _helper.SetLimitedRandomStringByName("code", 3);

            //Color seçimi yapılır
            _helper.SetRandomColorByName("color");
        }
        }
    }

