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




namespace Event
{
    class EventManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        //public IWebElement webElement;

        //oluşturulan yeni venue id si tutulmalıdır.
        //  string venue_id;

        public EventManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

        public void SerieManagement()
        {
            try
            {
                //Serie Management Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/serie/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='serie-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                string SerieName = _helper.GetTextByName("name");

                //Genre seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[1]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Team seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[1]/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[2]");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Sub Genre için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refSubGenreID");

                //Rastgele Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset[2]/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //TicketType seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[3]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[3]/button[1]");
                /*
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[3]/div/div/div[2]/p-calendar/span/input");

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/div", finishDate);
                */
                //Venue seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[4]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[3]/button[1]");


                //SalesPlan seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[4]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[3]/button[1]");

                //League seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[4]/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[3]/button[1]");

                //Organizer seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[5]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");

                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate2 = _helper.SetRandomDateTimeByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[3]/div/div/div[2]/p-calendar/span/input");

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate2 = _helper.SetRandomDateTimeAfterThisDateTime(startDate2);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/div", finishDate2);

                //Venue Template seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[3]/button[1]");

                //Event Group seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[6]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[3]/button[1]");

                //Seat Class Configuraton seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[6]/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Payment Plan Configuraton seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[7]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Template Configuraton seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[7]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Cofiguration Configuraton seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[7]/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Sponsor Configuraton seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[8]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[3]/button[1]");

                //Home Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset[9]/div/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset[9]/div/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Description alanını doldurur
                _helper.SetRandomTextByName("detailPageDescription");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                //Kaydedilen Venue name'i tutulur
                //_helper.GetTextByPath("//*[@id='venue-crud-417;formtype=read--form']/div/div/form/fieldset[1]/div/div/div[1]/input");   

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.SerieManagement) + exception.Message);
            }
        }


        public void EventManagement1()
        {
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

                //Organizer seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Venue seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Venue Template seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[3]/button[1]");

                //Home Team seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[3]/button[1]");

                //Away Team seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[3]/button[1]");
                /*
                // Başlangıç tarihini belirler
                DateTime startDate3 = _helper.SetRandomDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[3]/p-calendar/span/input");
                */
                //Home Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Away Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");
                /*
                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate3 = _helper.SetRandomDateTimeAfterThisDateTime(startDate3);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/div", finishDate3);
                */
                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[5]/input");

                //DETAİL BOLUMU

                //Genre seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[13]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[13]/div[2]/lookup/div/div[3]/button[1]");

                //Random SubGenre seçimi yapılır
                _helper.SelectRandomDropdownElementByName("refSubGenreID");

                //Random Week seçimi yapılır
                _helper.SelectRandomDropdownElementByName("week");

                //League seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");

                //Sponsor seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[3]/button[1]");
                /*
                //Door Opening time seçilir
                DateTime startDate4 = _helper.SetRandomDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[3]/p-calendar/span/input");
                */
                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[4]/input[2]");

                //CONF BOLUMU

                //Payment Plan seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[3]/button[1]");

                //Sales Plan seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Type seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[3]/button[1]");

                //Event Group seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[3]/button[1]");

                //Seat Class Configuration seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Configuration seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("//html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Primary Access seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[20]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[20]/div[2]/lookup/div/div[3]/button[1]");

                //Secondary Access seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[21]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[21]/div[2]/lookup/div/div[3]/button[1]");

                //Random Acs seçimi yapılır
                _helper.SelectRandomDropdownElementByName("eventType");

                //Random Acs Code girilir
                _helper.SetRandomTextByName("eventCode");

                //Ticket Template seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[4]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Home Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Description 
                _helper.SetRandomTextByName("detailPageDescription");

                //Free Passcard Count
                _helper.SetRandomIntegerByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[6]/div/div/div/input", 1, 50);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud-1447--form']/div/div/form/fieldset/tabset/div/tab[3]/div[7]/input[2]");
                System.Threading.Thread.Sleep(2000);

                
                
                
                
                









                
                
                
                //CATEGORY BOLUMU:

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud-1447--form']/div/div/form/fieldset/tabset/div/tab[4]/div[1]/div/div/div[2]/input[1]");

                System.Threading.Thread.Sleep(3000);

                //Category Mame için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refCategoryID");

                //Discount Rate için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refDiscountRateTypeID");

                //Price alanı için random değer girilir
                _helper.SetRandomIntegerByName("price", 500, 2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorycrud-1447-event--form']/div/div/form/fieldset/div[3]/div/div/input");
                System.Threading.Thread.Sleep(2000);

                //CHANNEL BOLUMU 

                //Channel seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorychannelcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                
                //Display Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("displayName");

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorychannelcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[3]/input");
                System.Threading.Thread.Sleep(2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorychannelcrud-1015-1447-265-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");

                //TiCKET BOLUMU 

                //Channel seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryticketcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refTicketTypeID");

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryticketcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[3]/input");
                System.Threading.Thread.Sleep(2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryticketcrud-1015-1447-265-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                //VARIANT BOLUMU 

                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryvariantcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Variant seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryvariantcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Value alanı için random değer girilir
                _helper.SetRandomIntegerByName("variantPriceValue", 500, 1000);

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryvariantcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[4]/div/div/input");
                System.Threading.Thread.Sleep(2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryvariantcrud-1015-1447-265-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                //VARIANT BOLUMU 

                //Rate Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refDiscountRateTypeID");

                //Variant seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Variant seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Value alanı için random değer girilir
                _helper.SetRandomIntegerByName("price", 500, 1000);

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[3]/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");
                System.Threading.Thread.Sleep(2000);

                //BENEFİCİARY BOLUMU

                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorybeneficiarycrud-1015-1447-265-event--form']/div/div/form/fieldset/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refTicketTypeID");

                //Beneficiary için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refBeneficiaryID");

                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorybeneficiarycrud-1003-1442-123-event--form']/div/div/form/fieldset/div[2]/div/div/input");
                System.Threading.Thread.Sleep(2000);

                //Close and finish butonuna tıklanır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorybeneficiarycrud-1003-1442-123-event--form']/div/div/form/fieldset/fieldset[2]/div/div/div[2]/input");
                System.Threading.Thread.Sleep(7000);
















                //BLOCK BOLUMU: (SİSTEMDE HATA VAR SONRA YAPILACAK !!!)
                /*
                //Block butonuna tıklanır(ÇALIŞIP ÇALIŞMADIĞI BELLİ DEĞİL)
                _helper.ClickByXPath("//*[@id='tabControl']/li[5]/a");
               
                //Make Block Seats butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud-1442--form']/div/div/form/fieldset/tabset/div/tab[5]/div[1]/div/div/div[2]/div[1]/input");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");
                */

                //CARD RULE BOLUMU:

                //Block butonuna tıklanır(ÇALIŞIP ÇALIŞMADIĞI BELLİ DEĞİL)
                _helper.ClickByXPath("//*[@id='tabControl']/li[6]/a");


                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.EventManagement1) + exception.Message);
            }
        }
        public void LeaugeManagement()
        {
            try
            {
                // Block Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/league/list");

                //Leauge Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='league-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

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
            }
        }

        public void TeamManagement()
        {
            try
            {
                //Team Management url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/team/list");

                //Team Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='team-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Team alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //View From Field Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='team-crud--form']/div/div/form/fieldset/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Add Leauge butonuna tıklanır
                _helper.ClickByXPath("//*[@id='team-crud--form2]/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                //Leauge seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='team-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
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
            }
        }

        public void OrganizerManagement()
        {
            try
            {
                // Organizer Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/organizer/list");

                //Organizer Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='organizer-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Organizer Name alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Trade Name alanına random text girilir
                _helper.SetRandomTextByName("TradeName");

                //Adress alanı için random text girilir
                _helper.SetRandomTextByName("Address");

                //Tax Administration alanı için random text girilir
                _helper.SetRandomTextByName("Administration");

                //Tax Number alanı için random değer girilir
                _helper.SetRandomIntegerByXpath("//*[@id='organizer-crud--form']/div/div/form/fieldset[2]/div/div/div[3]/input", 1000, 10000);

                //View From Field Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='organizer-crud--form']/div/div/form/fieldset[3]/div/div/div/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                /*
                //Add Terminal butonuna tıklanır
                _helper.ClickByXPath("//*[@id='organizer-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                //Random Selection yapılır
                _helper.SelectRandomDropdownElementByName("")
                */

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
                _helper.ClickByXPath("//*[@id='organizer-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.OrganizerManagement) + exception.Message);
            }
        }

        public void GenreManagement()
        {
            try
            {
                //Genre Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/genre/list");

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
                _helper.GiveError("In : " + nameof(this.GenreManagement) + exception.Message);
            }
        }

        public void SubGenreManagement()
        {
            try
            {
                // VenueTemplate Management url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/subgenre/list");

                //VenueTemplate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='subgenre-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //SubGenre alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Vat Rat alanına random yüzde girilir.
                _helper.SetRandomIntegerByXpath("//*[@id='subgenre-crud--form']/div/div/form/fieldset/div/div/div[2]/input", 1, 100);

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='subgenre-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.SubGenreManagement) + exception.Message);
            }
        }

        public void SponsorManagement()
        {
            try
            {

                // Sponsor Management url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/sponsor/list");

                //Sponsor Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='sponsor-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Sponsor alanına random text girilir
                _helper.SetRandomTextByName("name");

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
            }
        }
        public void EventGroupManagement()
        {
            try
            {
                //Event Group Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/eventgroup/list");

                //Event Group Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='eventgroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Event Group alanına random text girilir
                _helper.SetRandomTextByName("name");

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
            }
        }

    }
}


