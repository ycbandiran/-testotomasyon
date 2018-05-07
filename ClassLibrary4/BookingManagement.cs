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
using Event;
using Payment;

namespace Booking
{
    public class BookingManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        EventManagement _event;
        PaymentTests _payment;


        public BookingManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Booking modül testi başladı.");

        }

        public void BookingActionTypes()
        {
            _helper.GivePassInfo("Booking Action Types modül testi başladı.");

            try
            {
                //Booking Action Type Url gidilir 
                _helper.GoToUrl("http://localhost:4200/bookingactiontype/list");
                _helper.WaitUntilPageLoad();

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='bookingactiontype-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");

                //Action Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("actionTypeCmb");

                //Organizer seçimi yapılır
                _helper.ClickByName("Organizer");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByName("lookupSelect");

                //Payment Plan seçimi yapılır
                _helper.ClickByName("PaymentPlan");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Add to Row butonuna tıklanır
                _helper.ClickByName("AddToRowButton1");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='bookingactiontype-crud--booking-action-type-form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.BookingActionTypes) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }
    }
}


