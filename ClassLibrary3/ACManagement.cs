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




namespace AC
{
    class ACManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        //public IWebElement webElement;

        //oluşturulan yeni venue id si tutulmalıdır.
        //  string venue_id;

        public ACManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

        public void ACSetting()
        {
            try
            {
                //AC Setting Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/accesscontrolsetting/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='accesscontrolsetting-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir text girilir
                _helper.SetRandomTextByName("name");
                //string venueName = _helper.GetTextByName("name");

                //Random AC Control Provider seçimi yapılır
                _helper.SelectRandomDropdownElementByName("accessControlProvider");

                //Destination alanına rastgele bir text girilir
                _helper.SetRandomTextByName("destination");

                //Destination alanına rastgele bir int girilir
                _helper.SetRandomIntegerByXpath("//*[@id='accesscontrolsetting-crud--form']/div/div/form/fieldset/div[2]/div/div[1]/input",10,100);

                //İsteğe bağlı Auto Send fonksiyonu yazılabilir.

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='accesscontrolsetting-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.ACSetting) + exception.Message);
            }
        }


        public void TelegramQueueManagement()
        {
            try
            {
                //Telegram Queue Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/telegramqueue/list");

                //Telegram Queue Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='telegramqueue-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Booking Ticket seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='telegramqueue-crud--form']/div/div/form/fieldset/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Event Access Control Setting seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='telegramqueue-crud--form']/div/div/form/fieldset/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Random Action seçimi yapılır
                _helper.SelectRandomDropdownElementByName("action");

                //Random Type seçimi yapılır
                _helper.SelectRandomDropdownElementByName("type");

                //Random State seçimi yapılır
                _helper.SelectRandomDropdownElementByName("state");

                //Void Reason Alanına text girişi yapılır
                _helper.SetTextByName("voidReason","Live a life you will remember");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='telegramqueue-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TelegramQueueManagement) + exception.Message);
            }
        }
        public void TelegramManagement()
        {
            try
            {
                // Bin Number Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/telegram/list");

                //Telegram Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='telegram-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Telegram Queue seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='telegram-crud--form']/div/div/form/fieldset/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                /*
                //Request tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='telegram-crud--form']/div/div/form/fieldset/div[1]/div/div[2]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='telegram-crud--form']/div/div/form/fieldset/div[1]/div/div[3]/p-calendar/span/input", finishDate);
                _helper.WaitUntilPageLoad();
                */
                //Random State seçimi yapılır
                _helper.SelectRandomDropdownElementByName("state");

                //Request alanına random değer girilir
                _helper.SetRandomTextByName("request");

                //Response alanına random değer girilir
                _helper.SetRandomTextByName("response");

                //Fail Reason alanına random değer girilir
                _helper.SetRandomTextByName("failReason");

                //Bin number alanına random int girilir.
                _helper.SetRandomIntegerByXpath("//*[@id='binnumbergroupitem-crud--form']/div/div/form/fieldset/div/div/div[2]/input", 1, 5);

                //Bin Number Goup alanına İd si tutulan değer girilir(OLMASI GEREKEN)

                //Bin Number Goup seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='binnumbergroupitem-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='telegram-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TelegramManagement) + exception.Message);
            }
        }
    }
}




