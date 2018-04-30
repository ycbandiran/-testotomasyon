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

namespace AllModulesTesting
{
    public class TestingWhole
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;

        //Oluşturulan yeni Channel name i tutulmalıdır.
        public string ChannelName;

        //Oluşturulan yeni Ctagory name i tutulmalıdır.
        public string CatagoryName;

        //Oluşturulan yeni Channel Group name i tutulmalıdır.
        public string ChannelGroupName;

        //Oluşturulan yeni Variant name i tutulmalıdır.
        public string VariantName;

        //Oluşturulan yeni Priority name i tutulmalıdır.
        public string PriorityName;

        //Oluşturulan yeni Product name i tutulmalıdır.
        public string ProductName;

        //Oluşturulan yeni Sales Plan name i tutulmalıdır.
        public string SalesPlanName;

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

        //oluşturulan yeni venue id si tutulmalıdır.
        public string TicketTemplateName;

        //Oluşturulan yeni Seat Class Configuration name i tutulmalıdır.
        public string SeatClassConfigurationName;

        //Oluşturulan yeni Seat Class Configuration name i tutulmalıdır.
        public string VariantConfigurationName;

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

        //oluşturulan yeni Payment Gateway name i tutulmalıdır.
        public string PaymentGatewayName;

        //oluşturulan yeni Bin Number Group name i tutulmalıdır.
        public string BinNumberGroupName;

        //oluşturulan yeni Bin Number name i tutulmalıdır.
        public string BinNumberName;

        //Oluşturulan yeni Payment Plan name i tutulmalıdır.
        public string PaymentPlanName;

        //Oluşturulan yeni AC Setting name i tutulmalıdır.
        public string ACSettingName;

        //Oluşturulan yeni Telegram Queue name i tutulmalıdır.
        public string TelegramQueueName;

        //Oluşturulan yeni National ıd name i tutulmalıdır.
        public string NationalIDName;

        public TestingWhole()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(70));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

        //CONTACT MANAGEMENT BOLUMU
        public void Contacts()
        {
            _helper.GivePassInfo("CONTACT MODÜLÜ:");
            _helper.GivePassInfo("Contacts modül testi başladı.");

            try
            {
                //Contact Url gidilir 
                _helper.GoToUrl("http://localhost:4200/contact/list");
                System.Threading.Thread.Sleep(3000);

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='contact-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //First Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("firstname");
                string FirstName = _helper.GetTextByName("firstname");

                //Last Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("lastname");
                string LastName = _helper.GetTextByName("lastname");

                //User Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("username");
                string userName = _helper.GetTextByName("username");

                //Password alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("password");
                string Password = _helper.GetTextByName("password");

                //GEÇİCİ
                //Country Code için rastgele selection yapılır
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[1]/form/div[2]/div[2]/div/p-dropdown/div/label");
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[1]/form/div[2]/div[2]/div/p-dropdown/div/div[4]/div/ul/li[1]");

                //Mobile Phone alanına random rakam girilir
                _helper.SetRandomIntegerByName("MobilePhone", 10, 10);

                //Mail alanına rastgele bir değer girilir
                _helper.SetRandomEmailByName("email");

                //National Id alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("nationalId", 7);

                //Bazı modellerin içi doldurulduğu zaman yorum açılacak.

                /*
                //Country için rastgele selection yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[1]/div/p-dropdown/div/label");
                System.Threading.Thread.Sleep(1000);
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[1]/div/p-dropdown/div/div[4]/div/ul/li[2]");

                //City için rastgele selection yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[2]/div/p-dropdown/div/label");
                System.Threading.Thread.Sleep(1000);
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[2]/div/p-dropdown/div/div[4]/div/ul/li[5]");

                //County için rastgele selection yapılır
                //_helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[3]/div/p-dropdown/div/label");
                //_helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[1]/form/div[2]/div[2]/div/p-dropdown/div/div[4]/div/ul/li[1]");

                //Address Type için rastgele selection yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[4]/div/p-dropdown/div/label");
                System.Threading.Thread.Sleep(1000);
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[4]/div/p-dropdown/div/div[4]/div/ul/li[2]");

                //Address Detail için random text girilir
                _helper.SetRandomTextByName("txtAddressDetail");

                //ADD butonuna tıklanır
                _helper.ClickByXPath("AddButtonAddress");               
                */

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.Contacts) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        //BLACKLIST BOLUMU
        public void NationalIDManagement()
        {
            _helper.GivePassInfo("BLACKLIST MODÜLÜ:");
            _helper.GivePassInfo("National Id modül testi başladı.");

            try
            {
                //NationalID Url gidilir 
                _helper.GoToUrl("http://localhost:4200/nationalidprobation/list");
                System.Threading.Thread.Sleep(2000);

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='nationalidprobation-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //National ID alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("nationalId");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                NationalIDName = _helper.GetTextByName("name");

                //Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime StartDate = _helper.SetRandomDateTimeByXPath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[1]/div/div/div[3]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                //Random Letter No girilir
                _helper.SetRandomIntegerByName("officalLetterNo", 1, 10);

                //Last Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("lastName");

                //Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(StartDate);
                _helper.SetDateTimeByXPath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[2]/div/div/div[3]/p-calendar/span/input", finishDate);
                _helper.WaitUntilPageLoad();

                //Country Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("countryCode", 3);

                //Rastgele checkbox seçimi yapar
                _helper.SelectRandomCheckboxesByName("status");

                //Probation Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[3]/div/div/div[3]/file-upload/div/input", @"C:\Images\");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.NationalIDManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        //INVENTORY BOLUMU
        public void CategoryManagement()
        {
            _helper.GivePassInfo("INVENTORY MODÜLÜ:");
            _helper.GivePassInfo("Catagory modül testi başladı.");

            try
            {
                //Catagory Management sayfasına git           
                _helper.GoToUrl("http://localhost:4200/category/list");

                // Category Management sayfasında Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='category-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan channel name i tutulur
                CatagoryName = _helper.GetTextByName("name");

                // Color alanına rastgele değer gir
                _helper.SetRandomColorByName("color");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='category-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Gelen modaldan OK butonuna tıkla
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.CategoryManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void ChannelManagement()
        {
            _helper.GivePassInfo("Channel modül testi başladı.");

            try
            {
                //Channel Management sayfasına git
                _helper.GoToUrl("http://localhost:4200/channel/list");

                // Channel Management sayfasındaki Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='channel-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Gelen Channel Form sayfasındaki Name alanına değer gir 
                _helper.SetRandomChannelTextByName("name");

                //Oluşturulan channel name i tutulur
                ChannelName = _helper.GetTextByName("name");

                // Rastgele bir rol seç
                _helper.SelectRandomDropdownElementByName("clientApplicationRole");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='channel-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Gelen modal üzerindeki OK butonuna tıkla
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void ChannelGroupManagement()
        {
            _helper.GivePassInfo("Channel Group modül testi başladı.");

            try
            {
                //Channel Group Management sayfasına git           
                _helper.GoToUrl("http://localhost:4200/channelgroup/list");

                // ChannelGroup Management sayfasında Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='channelgroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // ChannelGroup formunda name alanına random değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan channel group name i tutulur
                ChannelGroupName = _helper.GetTextByName("name");

                //Add Channel butonuna tıkla
                _helper.ClickByName("AddChannelButton");

                //Channel seçimi yapılır
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(ChannelName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Gelen modal üzerindeki OK butonuna tıkla
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError(exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void VariantManagement()
        {
            _helper.GivePassInfo("Variant modül testi başladı.");

            try
            {
                //Variant Management sayfasına git
                _helper.GoToUrl("http://localhost:4200/variant/list");

                // Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='variant-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan variant name i tutulur
                VariantName = _helper.GetTextByName("name");

                // displayName alanına rastgele değer gir
                _helper.SetRandomTextByName("displayName");

                // Rastgele bir resim yükle
                _helper.SetRandomFileByXpath("//*[@id='variant-crud--form']/div/div/form/fieldset/div/div[1]/div[3]/file-upload/div/input", @"C:\Images\");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='variant-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Çıkan modaldan OK butonua tıkla
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void PriorityManagement()
        {
            _helper.GivePassInfo("Priority modül testi başladı.");

            try
            {
                // Priority Management sayfasına git
                _helper.GoToUrl("http://localhost:4200/priority/list");

                // Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='priority-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Pri./Dis. Name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan priortiy name i tutulur
                PriorityName = _helper.GetTextByName("name");

                //Priorty Type seç
                _helper.ClickByXPath("//*[@id='priority-crud--form']/div/div/form/fieldset[1]/div/div/div[2]/div/select");
                _helper.ClickByXPath("//*[@id='priority-crud--form']/div/div/form/fieldset[1]/div/div/div[2]/div/select/option[2]");


                /*
                // Rastgele bir Type seç ve seçilen option'un değerini typeSelectedValue değişkenine ata
                string typeSelectedValue = _helper.SelectDropdownElementByName("refValidationIntegrationTypeID");

                bool isSelected = _helper.SelectRandomCheckboxByName("isIntegration");

                if(typeSelectedValue == "Discount" || isSelected)
                {
                    if(typeSelectedValue.Equals("Priority") && isSelected)
                    {
                        _helper.ClickByXPath("//*[@id='priority-crud--form']/div/div/form/fieldset[2]/div/div/div/div/div/p-checkbox/div/div[2]");
                    }

                    string selectedValueUrlList = _helper.SelectDropdownElementByName("refPriorityValidationTypeID");

                    if(selectedValueUrlList == "URL" || selectedValueUrlList == "EXCEL LIST")
                    {
                        _helper.SetRandomTextByName("parameter1");
                        _helper.SetRandomTextByName("parameter2");
                    }
                    if(selectedValueUrlList == "URL")
                    {
                        _helper.SetRandomTextByName("url");
                    }
                    else
                    {                        
                    //    _helper.SetRandomFileByXPhat("//*[@id='priority-crud--form']/div/div/form/fieldset[4]/div/div/div[2]/file-upload/div/input", @"D:/Users/ocirakli/source/repos/TestOtomasyon/Excels/");
                        //*[@id='priority-crud--form']/div/div/form/fieldset[4]/div/div/div[2]/file-upload/div/input
                    }
                    
                }              
                */

                //Photo için bir resim seçilmesi                
                _helper.SetRandomFileByXpath("//*[@id='priority-crud--form']/div/div/form/fieldset[5]/div[1]/file-upload/div/input", @"C:\Images\");

                // Description alanına rastgele bir değer gir
                _helper.ClickByXPath("//*[@id='priority-crud--form']/div/div/form/fieldset[5]/div[2]/div/textarea[2]");
                _helper.SetRandomTextByXPath("//*[@id='priority-crud--form']/div/div/form/fieldset[5]/div[2]/div/textarea[2]");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='priority-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Çıkan modaldan OK butonuna tıkla
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                _helper.ErrorLogging(exception);
            }

        }

        public void ProductManagement()
        {
            _helper.GivePassInfo("Product modül testi başladı.");

            try
            {
                // Product Management sayfasına git
                _helper.GoToUrl("http://localhost:4200/product/list");

                // Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='product-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Product Name alanına restgele değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan product name i tutulur
                PriorityName = _helper.GetTextByName("name");

                // Product Type alanında rastgele seçim yap        SOURCE KOD GÜNCELLENENE KADAR YORUM AÇILMAYACAK
                //_helper.SelectRandomDropdownElementByName("refProductCategoryID");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='product-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Çıkan modaldan OK butonuna tıkla
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError(exception.Message);
                _helper.ErrorLogging(exception);
            }

        }

        public void SalesPlanManagement()
        {
            _helper.GivePassInfo("Sales Pllan modül testi başladı.");

            try
            {
                // Sales Plan Management sayfasına git
                _helper.GoToUrl("http://localhost:4200/salesplan/crud");

                // name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan Sales Plan name i tutulur
                SalesPlanName = _helper.GetTextByName("name");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='salesplan-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Çıkan modaldan OK butonuna tıkla
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(2000);

                //BURADAN SONRASINDA PATHLERİN HER REFRESH DEN SONRA DEĞİŞMESİNDEN DOLAYI SORUN ÇIKIYOR XPATH LER YERİNE NAME LER GELDİKTEN SONRA YORUM KALDIRILACAK!!!!!!!!

                /*
                //Rastgele Priority seç(GEÇİCİ)
                _helper.SelectRandomDropdownElementByName("refValidationIntegrationID");
                System.Threading.Thread.Sleep(2000);
               
                //Channel seçimi yapılır(GEÇİCİ)            
                _helper.ClickByXPath("//*[@id='salesplan-crud-341--form']/div/div/form/fieldset/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(3000);
                _driver.FindElement(By.Name("searchText")).SendKeys(ChannelName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Rastgele Limit koyar
                _helper.SetRandomIntegerByName("ticketLimit", 10, 100);
               
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='salesplan-crud-341--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/div", finishDate);
                _helper.WaitUntilPageLoad();
                

                //Rastgele total seat sayısı belirler
                _helper.SetRandomIntegerByName("totalSeatCount", 10, 100);

                //İnsert Butonuna basar
                _helper.ClickByName("InsertButton");

                //Save butonuna tıklar
                _helper.ClickByXPath("//*[@id='salesplan-crud-324--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Çıkan modulde ok butonuna basar
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);
                */
            }
            catch (Exception exception)
            {
                _helper.GiveError(exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        //VENUE BOLUMU
        public void VenueManagement()
        {
            _helper.GivePassInfo("VENUE MODÜLÜ:");
            _helper.GivePassInfo("Venue modül testi başladı.");

            try
            {
                //Venue Management butonuna tıklanır 
                _helper.GoToUrl("http://localhost:4200/venue/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venue-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Venue name'i tutulur
                VenueName = _helper.GetTextByName("name");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Rastgele Country seçimi yapılır
                _helper.ClickByXPath("//*[@id='venue-crud--form']/div/div/form/fieldset[2]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                /*
                // Rastgele bir country seçeneğine tıklanır
                _helper.ClickRandomTagByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody", "tr");
                */

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
                _helper.GoToUrl("http://localhost:4200/area/list");

                //Area Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='area-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");
                //Kaydedilen Area name'i tutulur
                AreaName = _helper.GetTextByName("name");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='area-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

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
                _helper.GoToUrl("http://localhost:4200/gate/list");

                //Gate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='gate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[1]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Area name'i tutulur
                GateName = _helper.GetTextByName("name");

                //Code alanına random 5 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 5);

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='gate-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

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
                _helper.GoToUrl("http://localhost:4200/tribune/list");

                //Tribune Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='tribune-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Tribune name'i tutulur
                TribuneName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Sponsor alanı için random text girilir
                _helper.SetRandomTextByName("sponsor");

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='tribune-crud--form']/div/div/form/fieldset[2]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

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
                _helper.GoToUrl("http://localhost:4200/turnstile/list");

                //Turnstile Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='turnstile-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Turnstile name'i tutulur
                TurnstileName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='turnstile-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

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
            _helper.GivePassInfo("Venue TEmplate modül testi başladı.");

            try
            {
                // VenueTemplate Management butonuna tıkla
                _helper.GoToUrl("http://localhost:4200/venuetemplate/list");

                //VenueTemplate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='venuetemplate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");
                VenueTemplateName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='venuetemplate-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

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
                _helper.GoToUrl("http://localhost:4200/block/list");

                //Block Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div/div/div[2]/form/div/div[3]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);



                //EDIT BOLUMU:

                //BLock Management Url git
                _helper.GoToUrl("http://localhost:4200/block/list");

                //Block List den event seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Event Management sayfasında edit butonu tıklanır
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");

                //Add new butonuna tıklanır
                _helper.ClickByName("AddNewButton");

                //Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Venue Template yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[1]/div[2]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Area seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[1]/div[3]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(AreaName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Tribune seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[2]/div[1]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(TribuneName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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

                //Rastgele Ignore Gaps seçilir
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
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[1]/div[1]/div[1]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(GateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Turnstile seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[1]/div[1]/div[2]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(TurnstileName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[3]/button[1]");

                //Add butonu tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[1]/div[1]/div[5]/button");

                //Create butonu tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[2]/div/div/input");

                //Save Block Layout butonuna tıklar
                _helper.ClickByXPath("//*[@id='blocklayoutseat']/input");

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
                _helper.GoToUrl("http://localhost:4200/seatclass/list");

                //SeatClass Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='seatclass-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Seat Class name'i tutulur
                SeatClassName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Color seçimi yapılır
                _helper.SetRandomColorByName("color");

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

        //PRINTING BOLUMU
        public void TicketTemplateManagement()
        {
            _helper.GivePassInfo("PRINTING MODÜLÜ:");
            _helper.GivePassInfo("Ticket Template modül testi başladı.");

            try
            {
                //Ticket Template Management butonuna tıklanır 
                _helper.GoToUrl("http://localhost:4200/tickettemplate/list");

                System.Threading.Thread.Sleep(2000);

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tickettemplate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                TicketTemplateName = _helper.GetTextByName("name");

                //Rastgele Backround Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='tickettemplate-crud--form']/div/div/form/fieldset/div[1]/div/div[2]/file-upload/div/input", @"C:\Images\");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='tickettemplate-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TicketTemplateManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void VariantConfigurationManagement()
        {
            _helper.GivePassInfo("Variant Configuration modül testi başladı.");

            try
            {
                // Variant Configuration Management Url git
                _helper.GoToUrl("http://localhost:4200/variantconfiguration/list");

                //Variant Configuration Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='variantconfiguration-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Kaydedilen Variant conf Group name'i tutulur
                VariantConfigurationName = _helper.GetTextByName("name");

                //Add New butonuna tıklar
                _helper.ClickByName("AddNewButton1");

                //Variant seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='variantconfiguration-crud--form']/div/div/p-dialog/div/div[2]/div/div/div[1]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VariantName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                 System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Rastgele Variants Logo seçilir
                _helper.SetRandomFileByXpath("//*[@id='variantconfiguration-crud--form']/div/div/p-dialog/div/div[2]/div/div/div[3]/div/input", @"C:\Images\");

                // Display Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("DisplayName");

                //Descripton alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("Description");

                //Add New butonuna tıklar
                _helper.ClickByName("AddNewButton2");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='variantconfiguration-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.VariantConfigurationManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }
        public void SeatClassConfigurationManagement()
        {
            _helper.GivePassInfo("Seat Class Configuration modül testi başladı.");

            try
            {
                // Seat Class Conf. Management Url git
                _helper.GoToUrl("http://localhost:4200/seatclassconfiguration/list");

                //Seat Class Conf. Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Seat Class Conf name'i tutulur
                SeatClassConfigurationName = _helper.GetTextByName("name");

                //Add New butonuna tıklar
                _helper.ClickByName("AddNewButton1");

                //Seat Class seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-crud--form']/div/div/p-dialog/div/div[2]/div/div/div[1]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(SeatClassName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                 System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Add New butonuna tıklar
                _helper.ClickByName("AddNewButton2");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.SeatClassConfigurationManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void PrinterManagement()
        {
            _helper.GivePassInfo("Printer modül testi başladı.");

            try
            {
                // Printer Management butonuna tıkla
                _helper.GoToUrl("http://localhost:4200/printer/list");

                //Printer Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='printer-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Rastgele Driver Type seçilir
                _helper.SelectRandomDropdownElementByName("DriverType");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='printer-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.PrinterManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        //EVENT BOLUMU
        public void LeaugeManagement()
        {
            _helper.GivePassInfo("EVENT MODÜLÜ:");
            _helper.GivePassInfo("Event modül testi başladı.");
            try
            {
                //Leauge Management butonuna tıkla
                _helper.GoToUrl("http://localhost:4200/league/list");
                _helper.WaitUntilPageLoad();

                //Leauge Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='league-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Leauge name'i tutulur
                LeaugeName = _helper.GetTextByName("name");

                //Random Leauge Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='league-crud--form']/div/div/form/fieldset/div/div/div[2]/file-upload/div/input", @"C:\Images\");

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
                _helper.GoToUrl("http://localhost:4200/team/list");
                _helper.WaitUntilPageLoad();

                //Team Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='team-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Team alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Team name'i tutulur
                TeamName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //View From Field Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='team-crud--form']/div/div/form/fieldset/div/div/div[3]/file-upload/div/input", @"C:\Images\");

                //Add Leauge butonuna tıklanır
                _helper.ClickByName("AddLeaugeButton");

                System.Threading.Thread.Sleep(2000);

                //Leauge seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='team-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(LeaugeName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
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
                _helper.GoToUrl("http://localhost:4200/organizer/list");
                _helper.WaitUntilPageLoad();

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
                _helper.SetRandomFileByXpath("//*[@id='organizer-crud--form']/div/div/form/fieldset[3]/div/div/div/file-upload/div/input", @"C:\Images\");

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
                _helper.GoToUrl("http://localhost:4200/genre/list");

                //Genre Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='genre-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //General Genre alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Genre name'i tutulur
                GenreName = _helper.GetTextByName("name");

                //Add SubGenre butonuna tıklanır
                _helper.ClickByName("AddSubGenreButton");

                //Leauge seçimi yapılır(GEÇİCİ)
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(LeaugeName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
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
            _helper.GivePassInfo("SubGenre modül testi başladı.");

            try
            {
                // VenueTemplate Management url git
                _helper.GoToUrl("http://localhost:4200/subgenre/list");

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
                _helper.GoToUrl("http://localhost:4200/sponsor/list");

                //Sponsor Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='sponsor-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Sponsor alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Sponsor name'i tutulur
                SponsorName = _helper.GetTextByName("name");

                //View From Field random Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='sponsor-crud--form']/div/div/form/fieldset/div/div/div[2]/file-upload/div/input", @"C:\Images\");

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
                _helper.GoToUrl("http://localhost:4200/eventgroup/list");

                //Event Group Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='eventgroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Event Group alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Event Group name'i tutulur
                EventGroupName = _helper.GetTextByName("name");

                //Description alanına random text girilir
                _helper.SetRandomTextByXPath("//*[@id='eventgroup-crud--form']/div/div/form/fieldset/div/div/div[2]/input");

                //Random Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='eventgroup-crud--form']/div/div/form/fieldset/div/div/div[3]/file-upload/div/input", @"C:\Images\");

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
                _helper.GoToUrl("http://localhost:4200/serie/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='serie-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");

                //oluşturulan yeni Serie name i tutulmalıdır.
                SerieName = _helper.GetTextByName("name");

                //Genre seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(GenreName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Team seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(TeamName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Sub Genre için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refSubGenreID");

                //Rastgele Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[3]/file-upload/div/input", @"C:\Images\");

                //TicketType seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[3]/button[1]");
                
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[3]/div/div/div[2]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/div", finishDate);
                _helper.WaitUntilPageLoad();

                //Next butonu tıklanır
                _helper.ClickByName("NextButton1");

                System.Threading.Thread.Sleep(3000);

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[3]/button[1]");

                //SalesPlan seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(SalesPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[3]/button[1]");

                //League seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(LeaugeName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[3]/button[1]");

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(OrganizerName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");
                                
                //League Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[3]/file-upload/div/input", @"C:\Images\");

                //Venue Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[3]/button[1]");

                //Event Group seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(EventGroupName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[3]/button[1]");

                //Seat Class Configuraton seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(SeatClassConfigurationName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Next butonu tıklanır
                _helper.ClickByName("NextButton2");

                System.Threading.Thread.Sleep(3000);

                //Payment Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(PaymentPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(TicketTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Cofiguration Configuraton seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VariantName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Sponsor seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(SponsorName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[3]/button[1]");

                //Home Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[1]/file-upload/div/input", @"C:\Images\");

                //Detail Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[2]/file-upload/div/input", @"C:\Images\");

                //Detail Page Description alanını doldurur
                _helper.SetRandomTextByName("detailPageDescription");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

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
                _helper.GoToUrl("http://localhost:4200/event/list");

                //Event Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Event alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Event Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(OrganizerName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Venue Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VenueTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
                
                //Home Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[1]/file-upload/div/input", @"C:\Images\");

                //Away Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/div/div[2]/file-upload/div/input", @"C:\Images\");
                
                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate3 = _helper.SetRandomDateTimeAfterThisDateTime(startDate3);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/div", finishDate3);

                //Next butonuna tıklanır
                _helper.ClickByName("NextButton1");

                //DETAİL BOLUMU

                //Genre seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(GenreName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[13]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[13]/div[2]/lookup/div/div[3]/button[1]");

                //Random SubGenre seçimi yapılır
                _helper.SelectRandomDropdownElementByName("refSubGenreID");

                //Random Week seçimi yapılır
                _helper.SelectRandomDropdownElementByName("week");

                //League seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(GenreName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");

                //Sponsor seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(SponsorName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[3]/button[1]");
                
                //Door Opening time seçilir
                DateTime startDate4 = _helper.SetRandomDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[3]/p-calendar/span/input");

                //Next butonuna tıklanır
                _helper.ClickByName("NextButton2");

                //CONF BOLUMU

                //Payment Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(PaymentPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[3]/button[1]");

                //Sales Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(SalesPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
                _driver.FindElement(By.Name("searchText")).SendKeys(EventGroupName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[3]/button[1]");

                //Seat Class Configuration seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(SeatClassConfigurationName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Configuration seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(VariantConfigurationName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
                _driver.FindElement(By.Name("searchText")).SendKeys(TicketTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Home Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[1]/file-upload/div/input", @"C:\Images\");

                //Detail Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[2]/file-upload/div/input", @"C:\Images\");

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
                // Event Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/event/list");

                //Event List den event seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Event Management sayfasında edit butonu tıklanır
                _helper.ClickByXPath("//*[@id='event-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");

                System.Threading.Thread.Sleep(4000);

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

                //Channel seçimi yapılır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategorychannelcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + ChannelName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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

                //Channel seçimi yapılır
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryticketcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + ChannelName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + ChannelName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Variant seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryvariantcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + VariantName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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

                //Channel seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + ChannelName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Product seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='eventcategory-seatcategoryproductcrud-1015-1447-265-event--form']/div/div/form/fieldset/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + ProductName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + ChannelName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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

                //Update butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud-1465--form']/div/div/form/fieldset/tabset/div/tab[6]/div[1]/div/div[2]/div[2]/visa-configuration/div/form/div[4]/div/div/input");


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
                _helper.GiveError("In : " + nameof(this.EventManagement1) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        //BOOKING BOLUMU
        public void BookingActionTypes()
        {
            _helper.GivePassInfo("BOOKING MODÜLÜ:");
            _helper.GivePassInfo("BookingAction modül testi başladı.");

            try
            {
                //Booking Action Type Url gidilir 
                _helper.GoToUrl("http://localhost:4200/bookingactiontype/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='bookingactiontype-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");

                //Action Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("actionTypeCmb");

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='bookingactiontype-crud--booking-action-type-form']/div/div/fieldset[2]/tabset/div/tab/div/div[1]/form/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(OrganizerName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Payment Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='bookingactiontype-crud--booking-action-type-form']/div/div/fieldset[2]/tabset/div/tab/div/div[1]/form/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(PaymentPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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

        //AC BOLUMU
        public void ACSetting()
        {
            _helper.GivePassInfo("AC MODÜLÜ:");
            _helper.GivePassInfo("AC modül testi başladı.");

            try
            {
                //AC Setting Url git
                _helper.GoToUrl("http://localhost:4200/accesscontrolsetting/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='accesscontrolsetting-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen AC Setting name'i tutulur
                ACSettingName = _helper.GetTextByName("name");

                //Random AC Control Provider seçimi yapılır
                _helper.SelectRandomDropdownElementByName("accessControlProvider");

                //Destination alanına rastgele bir text girilir
                _helper.SetRandomTextByName("destination");

                //Destination alanına rastgele bir int girilir
                _helper.SetRandomIntegerByName("destination", 10, 100);

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
                _helper.GoToUrl("http://localhost:4200/telegramqueue/list");
                _helper.WaitUntilPageLoad();

                //Telegram Queue Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='telegramqueue-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Kaydedilen Telegram Queue name'i tutulur
                TelegramQueueName = _helper.GetTextByName("name");

                //Booking Ticket seçimi yapılır
                _helper.ClickByXPath("//*[@id='telegramqueue-crud--form']/div/div/form/fieldset/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Event Access Control Setting seçimi yapılır
                _helper.ClickByXPath("//*[@id='telegramqueue-crud--form']/div/div/form/fieldset/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(ACSettingName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
                _helper.GoToUrl("http://localhost:4200/telegram/list");
                _helper.WaitUntilPageLoad();

                //Telegram Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='telegram-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Telegram Queue seçimi yapılır
                _helper.ClickByXPath("//*[@id='telegram-crud--form']/div/div/form/fieldset/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(TelegramQueueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                
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

                //GEÇİCİ OLARAK KALACAK
                /*
                //Bin number alanına random int girilir.
                _helper.SetRandomIntegerByXpath("//*[@id='binnumbergroupitem-crud--form']/div/div/form/fieldset/div/div/div[2]/input", 1, 5);

                //Bin Number Goup seçimi yapılır
                _helper.ClickByXPath("//*[@id='binnumbergroupitem-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + BinNumberGroupName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");
                */

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

        //SECURITY BOLUMU
        public void Clients()
        {
            _helper.GivePassInfo("SECURITY MODÜLÜ:");
            _helper.GivePassInfo("Client modül testi başladı.");

            try
            {
                //Users Url gidilir 
                _helper.GoToUrl("http://localhost:4200/client/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='client-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                string Name = _helper.GetTextByName("name");

                //Secret alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("secret");
                string Secret = _helper.GetTextByName("secret");

                //Client Id alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("clientId");
                string ClientId = _helper.GetTextByName("clientId");

                //Allowed Origin alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("allowedOrigin");
                string allowedOrigin = _helper.GetTextByName("allowedOrigin");

                //Refresh Token Life Time alanına rastgele bir int girilir
                _helper.SetRandomIntegerByName("refreshTokenLifeTime", 10, 10);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='client-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.Users) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void Users()
        {
            _helper.GivePassInfo("User modül testi başladı.");

            try
            {
                //Users Url gidilir 
                _helper.GoToUrl("http://localhost:4200/bookingoperator/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='bookingoperator-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //First Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("firstname");
                string FirstName = _helper.GetTextByName("firstname");

                //Last Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("lastname");

                //MobilePhone alanına rastgele bir int girilir
                _helper.SetRandomIntegerByName("MobilePhone", 10, 10);

                //User Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("username");

                //Password alanına rastgele bir değer girilir
                _helper.SetRandomIntegerByName("password", 5, 8);

                //Random Email girilir
                _helper.SetRandomEmailByName("email");

                //Operator Image alanına random resim eklenir
                _helper.SetRandomFileByXpath("//*[@id='bookingoperator-crud--user-form']/div/div/fieldset[1]/div/form/div[3]/div/div/file-upload/div/input", @"C:\Images\");

                //Add Role butonuna tıklanır
                _helper.ClickByName("AddRoleButton");

                System.Threading.Thread.Sleep(2000);

                //Role seçimi yapılır
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");

                //TERMINAL RIGHTS BOLUMU YAPILACAK (ADD TERMINAL RIGHTS BUTONU HTML DE NAME VERILDI)!!!!!!!

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.Users) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void Roles()
        {
            _helper.GivePassInfo("Roles modül testi başladı.");

            try
            {
                //Roles Url git
                _helper.GoToUrl("http://localhost:4200/scrole/list");

                //Roles sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='scrole-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir text girilir
                _helper.SetRandomTextByName("name");

                //Description alanına rastgele bir text girilir
                _helper.SetRandomTextByXPath("//*[@id='scrole-crud--role-form']/div/fieldset/form/div[2]/div/textarea");

                //Rastgele yüzde girilir
                _helper.SetRandomIntegerByName("filterBackOfficeTxt", 1, 100);

                //Business Rights butonuna tıklar
                _helper.ClickByXPath("//*[@id='tabControl']/li[2]/a");

                //Rastgele yüzde girilir
                _helper.SetRandomIntegerByName("filterBusinessTxt", 1, 100);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='scrole-crud--role-form']/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.Roles) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void ApprovableUsers()
        {
            _helper.GivePassInfo("Approvable Users modül testi başladı.");

            try
            {
                //ApprovableUsers url git
                _helper.GoToUrl("http://localhost:4200/scapprovableuser/list");

                //User seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='scapprovableuser-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Approve butonuna tıklar
                _helper.ClickByName("AproveButton");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.ApprovableUsers) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void Terminals()
        {
            _helper.GivePassInfo("Terminals modül testi başladı.");

            try
            {
                //Terminals url git
                _helper.GoToUrl("http://localhost:4200/terminal/list");

                //Terminals sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='terminal-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Terminal Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='terminal-crud--form']/div/div/form/fieldset/div[2]/div/div[1]/file-upload/div/input", @"C:\Images\");

                //Ticket Printer seçimi yapılır
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Add Organizer butonuna tıkla
                _helper.ClickByName("AddOrganizerButton");

                System.Threading.Thread.Sleep(2000);

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _driver.FindElement(By.Name("searchText")).SendKeys(OrganizerName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.Terminals) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        //Advanced Search eklenecek!!
        /*public void AdvancedSearch()
        {
            try
            {
                //Advanced Search butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/advancedsearch/list");

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
                _helper.GiveError("In : " + nameof(this.AdvancedSearch) + exception.Message);
            }
        }
        */

        public void EntryPoint()
        {
            _helper.GivePassInfo("Entry Point modül testi başladı.");

            try
            {
                //Entry Point url git
                _helper.GoToUrl("http://localhost:4200/entrypoint/list");

                //Entry Point sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='entrypoint-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Entry Point Name alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Entry Point Description alanına rastgele bir text girilir
                _helper.SetRandomTextByXPath("//*[@id='entrypoint-crud--form']/div/div/form/fieldset/div/div/div[2]/input");

                //Entity Point seçimi yapılır
                _helper.ClickByXPath("//*[@id='entrypoint-crud--form']/div/div/div[2]/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Description alanına random text girilir
                _helper.SetRandomTextByName("entryPointDetailProxyDescription");

                //Order no alanına rastgele int girilir
                _helper.SetRandomIntegerByName("entryPointDetailOrderNo", 100, 1000);

                //Add butonuna tıklanır
                _helper.ClickByName("AddButton1");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='entrypoint-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.EntryPoint) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }
    }
}

