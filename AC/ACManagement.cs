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
using Booking;
using Payment;


namespace AC
{
    public class ACManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        BookingManagement _booking;
        PaymentTests _payment;

        //Oluşturulan yeni AC Setting name i tutulmalıdır.
        public string ACSettingName;

        //Oluşturulan yeni Telegram Queue name i tutulmalıdır.
        public string TelegramQueueName;


        public ACManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("AC Management modül testi başladı.");
        }

        public void ACSetting()
        {
            _helper.GivePassInfo("AC modül testi başladı.");

            try
            {
                //AC Setting Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/accesscontrolsetting/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='accesscontrolsetting-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                System.Threading.Thread.Sleep(2000);

                //Name alanına rastgele bir text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen AC Setting name'i tutulur
                ACSettingName = _helper.GetTextByName("name");

                //Random AC Control Provider seçimi yapılır
                _helper.SelectRandomDropdownElementByName("accessControlProvider");

                //Destination alanına rastgele bir text girilir
                _helper.SetRandomTextByName("destination");

                //Destination alanına rastgele bir int girilir
                _helper.SetRandomIntegerByName("batchSize", 1, 500);

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
                _helper.ErrorLogging(exception);
            }
        }

        public void TelegramQueueManagement()
        {
            _helper.GivePassInfo("Telegram Queue modül testi başladı.");

            try
            {
                //Telegram Queue Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/telegramqueue/list");
                _helper.WaitUntilPageLoad();

                //Telegram Queue Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='telegramqueue-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                System.Threading.Thread.Sleep(2000);

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Kaydedilen Telegram Queue name'i tutulur
                TelegramQueueName = _helper.GetTextByName("name");

                //Booking Ticket seçimi yapılır
                _helper.ClickByName("BookingTicket");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByName("lookupSelect");

                //Event Access Control Setting seçimi yapılır
                _helper.ClickByName("EventAccessControlSetting");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(ACSettingName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                //System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Random Action seçimi yapılır
                _helper.SelectRandomDropdownElementByName("action");

                //Random Type seçimi yapılır
                _helper.SelectRandomDropdownElementByName("type");

                //Random State seçimi yapılır
                _helper.SelectRandomDropdownElementByName("state");

                //Void Reason Alanına text girişi yapılır
                _helper.SetTextByName("voidReason", "Live a life you will remember");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='telegramqueue-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TelegramQueueManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void TelegramQueueManagement2()
        {
            _helper.GivePassInfo("Telegram Queue modül testi başladı.");

            try
            {
                //Telegram Queue Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/telegramqueue/list");
                _helper.WaitUntilPageLoad();

                //Telegram Queue Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='telegramqueue-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                System.Threading.Thread.Sleep(2000);

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Kaydedilen Telegram Queue name'i tutulur
                TelegramQueueName = _helper.GetTextByName("name");

                //Booking Ticket seçimi yapılır
                _helper.ClickByName("BookingTicket");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByName("lookupSelect");

                //Event Access Control Setting seçimi yapılır
                _helper.ClickByName("EventAccessControlSetting");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(ACSettingName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                //System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Random Action seçimi yapılır
                _helper.SelectRandomDropdownElementByName("action");

                //Random Type seçimi yapılır
                _helper.SelectRandomDropdownElementByName("type");

                //Random State seçimi yapılır
                _helper.SelectRandomDropdownElementByName("state");

                //Void Reason Alanına text girişi yapılır
                _helper.SetTextByName("voidReason", "Live a life you will remember");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='telegramqueue-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TelegramQueueManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void TelegramManagement()
        {
            _helper.GivePassInfo("Telegram modül testi başladı.");

            try
            {
                // Bin Number Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/telegram/list");
                _helper.WaitUntilPageLoad();

                //Telegram Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='telegram-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                System.Threading.Thread.Sleep(2000);

                //Telegram Queue seçimi yapılır
                _helper.ClickByName("TelegramQueue");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys(TelegramQueueName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                //System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByName("lookupSelect");

                //Request tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='telegram-crud--form']/div/div/form/fieldset/div[1]/div/div[2]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='telegram-crud--form']/div/div/form/fieldset/div[1]/div/div[3]/p-calendar/span/input", finishDate);
                _helper.WaitUntilPageLoad();

                //Random State seçimi yapılır
                _helper.SelectRandomDropdownElementByName("state");

                //Request alanına random değer girilir
                _helper.SetRandomTextByName("request");

                //Response alanına random değer girilir
                _helper.SetRandomTextByName("response");

                //Fail Reason alanına random değer girilir
                _helper.SetRandomTextByName("failReason");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='telegram-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TelegramManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }
    }
}




