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




namespace EventMenu
{
    class EventManagementMenu
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;

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

        public EventManagementMenu()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

        //VENUETEST DE YAPILAN HATA DÜZELTİLECEK !!!!!!!!!!!!!!
        public void EventGroupManagement()
        {
            try
            {
                // Block Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/eventgroup/list");

                //Leauge Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='eventgroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Event Group name'i tutulur
                EventGroupName = _helper.GetTextByName("name");

                //Description alanını doldurur
                _helper.SetRandomTextByName("detailPageDescription");

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
                _helper.GiveError("In : " + nameof(this.EventGroupManagement) + exception.Message);
            }
        }

        public void ChannelGroupManagement()
        {
            try
            {
                //Channel Group Management url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/channelgroup/list");

                //Channel Group sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='channelgroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Add Channel butonuna tıklanır
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.ChannelGroupManagement) + exception.Message);
            }
        }

        public void SalesPlanManagement()
        {
            try
            {
                //Sales Plan Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/salesplan/list");

                //Sales Plan Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='salesplan-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='salesplan-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //SALES PLAN ITEM FORM İÇERİĞİ DOLDURUR:

                //Priority için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refValidationIntegrationID");

                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='salesplan-crud-319--form']/div/div/form/fieldset/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                /*
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='salesplan-crud-319--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-319--form']/div/div/form/fieldset/div[2]/div/div[2]/p-calendar/span/input", finishDate);
                _helper.WaitUntilPageLoad();
                */
                //Insert butonuna tıklanır
                _helper.ClickByXPath("//*[@id='salesplan-crud-319--form']/div/div/form/fieldset/div[3]/div/div[3]/input");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='salesplan-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.SalesPlanManagement) + exception.Message);
            }
        }

        public void TicketTemplateManagement()
        {
            try
            {
                //Genre Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/tickettemplate/list");

                //Ticket Template alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Rastgele Background Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='tickettemplate-crud--form']/div/div/form/fieldset/div[1]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Add Design Hover butonunda Add new Text butonuna tıklanır(ÇALIŞTIĞI BELLİ DEĞİL)
                WebDriverWait wait = new WebDriverWait(_driver,new TimeSpan(0,0,5));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tickettemplate-crud--']/div/div/form/fieldset/div/div/p-menubar/div/p-menubarsub/ul/li[1]/a")));
                _driver.FindElement(By.XPath("//*[@id='tickettemplate-crud--']/div/div/p-dialog")).Click();

                //Text Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("Text Type");

                //Font için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("Font");

                //Rastgele Format seçilir
                _helper.ClickRandomCheckbox("//*[@id='tickettemplate-crud--']/div/div/p-dialog/div/div[2]/div/div[3]/div/div/div[1]/p-checkbox/div/div[2]");

                //Text alanına random text girilir
                _helper.SetRandomTextByName("Text");

                //Add New butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tickettemplate-crud--']/div/div/p-dialog/div/div[2]/div/div[7]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tickettemplate-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TicketTemplateManagement) + exception.Message);
            }
        }

        public void SerieManagement()
        {
            try
            {
                //Serie Management Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/serie/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='serie-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //GENERAL BOLUMU: 

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                string SerieName = _helper.GetTextByName("name");

                //Genre seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[1]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Team seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[1]/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
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
                System.Threading.Thread.Sleep(2000);

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[3]/div/div/div[3]/p-calendar/span/input", finishDate);
                System.Threading.Thread.Sleep(2000);
                */

                //Next butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/input");

                //DETAİL BOLUMU: 

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
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[3]/button[1]");

                //Organizer seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[5]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");

                //Leauge image seçimi yapılır
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset[5]/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Venue Template seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
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

                //Next butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[4]/input[2]");

                //CONFİGURATİON BOLUMU: 

                //Payment Plan seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[7]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Template Name seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[7]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Cofiguration seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[7]/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Sponsor seçimi yapılır(GEÇİCİ)
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

                System.Threading.Thread.Sleep(5000);

               
                
                
                
                
                
                
                /*                                                                       
                 
                //EDIT BOLUMU:                                                                 //FAZ 3 DE YAPILACAK !!!!

                // Event Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/event/list");

                //Event List den event seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Event Management sayfasında edit butonu tıklanır
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");

                //CATEGORY BOLUMU:

                //Catagory butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tabControl']/li[4]/a");

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

                //PRODUCT TYPE BOLUMU 

                //Rate Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refDiscountRateTypeID");

                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Product seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Product Value alanı için random değer girilir
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


                //BLOCK BOLUMU: (DİĞER FAZDA YAPILACAK)


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

                //Insert butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud-1446--form']/div/div/form/fieldset/tabset/div/tab[6]/div[1]/div/div[2]/div[2]/visa-configuration/div/form/div[4]/div/div/input");

                //Update butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud-1446--form']/div/div/form/fieldset/tabset/div/tab[6]/div[1]/div/div[2]/div[2]/visa-configuration/div/form/div[4]/div/div/input");


                //CARD RULE BOLUMU: (DİĞER FAZDA YAPILACAK)


                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id'event-crud-1442--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

                */
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
                //Event url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/event/list");

                //Event sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //GENERAL BÖLÜMÜ

                //Event alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Code alanına rastgele 3 karakter girilir
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
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Serie seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Home Team seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[3]/button[1]");

                //Away Team seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[3]/button[1]");
                /*
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[3]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();
                */
                //Home Team image seçimi yapılır
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Away Team image seçimi yapılır
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");
                /*
                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[3]/p-calendar/span/input", finishDate);
                _helper.WaitUntilPageLoad();
                */
                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[5]/input");

                //DETAİL BÖLÜMÜ

                //Genre seçimi yapılır(GEÇİCİ)
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
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");

                //League image seçimi yapılır
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Event image seçimi yapılır
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate1 = _helper.SetRandomDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[3]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[4]/input[2]");

                //CONFİGURATİON BÖLÜMÜ

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
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[3]/button[1]");

                //Seat Class Configuraton seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Configuraton seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[7]/div/div/div[1]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[3]/button[1]");

                //Primary Access Control Setting seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[20]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[20]/div[2]/lookup/div/div[3]/button[1]");

                //Secondary Access Control Setting seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[7]/div/div/div[1]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[3]/button[1]");

                /*
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate1 = _helper.SetRandomDateTimeByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[3]/div/div/div[2]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();
                */

                //Random Acs seçimi yapılır
                _helper.SelectRandomDropdownElementByName("eventType");

                //Random Acs Code girilir
                _helper.SetRandomTextByName("eventCode");

                //Ticket Template Name seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[4]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Home Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Description alanına rastgele bir text girilir.
                _helper.SetRandomTextByName("detailPageDescription");

                //Free Passcard Count alanına rastgele değer girilir
                _helper.SetRandomIntegerByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[6]/div/div/div/input", 1, 10);

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);





                /*
                 
                //EDIT BOLUMU:                                                          //XPATH'LER DEĞİŞTİRİLECEK !!!!!

                // Event Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/event/list");

                //Event List den event seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Event Management sayfasında edit butonu tıklanır
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");

                //CATEGORY BOLUMU:

                //Catagory butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tabControl']/li[4]/a");

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

                //PRODUCT TYPE BOLUMU 

                //Rate Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refDiscountRateTypeID");

                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Product seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Product Value alanı için random değer girilir
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


                //BLOCK BOLUMU: (DİĞER FAZDA YAPILACAK)

                //VISA CONFIGURATION BOLUMU:

                /*
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
            }
        }
    }
}


