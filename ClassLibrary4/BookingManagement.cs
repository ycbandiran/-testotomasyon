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



namespace Booking
{
    class BookingManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        //public IWebElement webElement;

        //oluşturulan yeni venue id si tutulmalıdır.
        //  string venue_id;

        public BookingManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

        public void BookingActionTypes()
        {
            try
            {
                //Booking Action Type Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/bookingactiontype/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='bookingactiontype-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                string SerieName = _helper.GetTextByName("name");

                //Action Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("actionTypeCmb");

                //Organizer seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='bookingactiontype-crud--booking-action-type-form']/div/div/fieldset[2]/tabset/div/tab/div/div[1]/form/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Payment Plan seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='bookingactiontype-crud--booking-action-type-form']/div/div/fieldset[2]/tabset/div/tab/div/div[1]/form/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Add to Row butonuna tıklanır
                _helper.ClickByXPath("//*[@id='bookingactiontype-crud--booking-action-type-form']/div/div/fieldset[2]/tabset/div/tab/div/div[1]/form/div[3]/button");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='bookingactiontype-crud--booking-action-type-form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                //Kaydedilen Venue name'i tutulur
                //_helper.GetTextByPath("//*[@id='venue-crud-417;formtype=read--form']/div/div/form/fieldset[1]/div/div/div[1]/input");   

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.BookingActionTypes) + exception.Message);
            }                
        }
    }
}


