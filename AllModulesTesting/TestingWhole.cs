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

        public TestingWhole()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

        //CONTACT MANAGEMENT BOLUMU
        public void Contacts()
        {
            try
            {
                //Contact Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/contact/list");
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

                //Country Code için rastgele selection yapılır
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[1]/form/div[2]/div[2]/div/p-dropdown/div/label");
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[1]/form/div[2]/div[2]/div/p-dropdown/div/div[4]/div/ul/li[1]");

                //Mobile Phone alanına random rakam girilir
                _helper.SetRandomIntegerByXpath("//*[@id='contact-crud--contact-form']/div/fieldset[1]/form/div[2]/div[3]/div/input", 10, 10);

                //Mail alanına rastgele bir değer girilir
                _helper.SetRandomEmailByName("email");

                //National Id alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("nationalId", 7);

                //GEÇİCİ YAPILAN SEÇİMLERDE İLERİKİ AŞAMADA CONTRY CODE GİBİ SEÇENEKLER NATİONAL ID Yİ ETKİLEYECEĞİ İÇİN İNDEKSE GÖRE CASE YAZILACAK.

                //Country için rastgele selection yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[1]/div/p-dropdown/div/label");
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[1]/div/p-dropdown/div/div[4]/div/ul/li[2]");

                //City için rastgele selection yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[2]/div/p-dropdown/div/label");
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[2]/div/p-dropdown/div/div[4]/div/ul/li[4]");

                //County için rastgele selection yapılır
                //_helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[3]/div/p-dropdown/div/label");
                //_helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[1]/form/div[2]/div[2]/div/p-dropdown/div/div[4]/div/ul/li[1]");

                //Address Type için rastgele selection yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[4]/div/p-dropdown/div/label");
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[1]/div[4]/div/p-dropdown/div/div[4]/div/ul/li[3]");

                //Address Detail için random text girilir
                _helper.SetRandomTextByName("txtAddressDetail");

                //ADD butonuna tıklanır
                _helper.ClickByXPath("//*[@id='contact-crud--contact-form']/div/fieldset[2]/tabset/div/tab[1]/form[2]/div/button");

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
        public void NationalID()
        {
            try
            {
                //NationalID Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/nationalidprobation/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='nationalidprobation-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //National ID alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("nationalId");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                string SerieName = _helper.GetTextByName("name");

                //DATETİME FONKSİYONU ÇALIŞMIYOR!!!!
                
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[1]/div/div/div[3]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                //Random Letter No girilir
                _helper.SetRandomIntegerByXpath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[2]/div/div/div[1]/input", 1, 10);

                //Last Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("lastName");
                
                //Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);                
                _helper.SetDateTimeByXPath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[2]/div/div/div[3]/p-calendar/span/input", finishDate);
                _helper.WaitUntilPageLoad();

                //Country Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("countryCode", 3);

                //Rastgele checkbox seçimi yapar
                _helper.SelectRandomCheckboxesByName("status");

                //Probation Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[3]/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.NationalID) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        //INVENTORY BOLUMU
        public void CategoryManagement()
        {
            try
            {
                //Catagory Management sayfasına git           
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/category/list");

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
            try
            {
                //Channel Management sayfasına git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/channel/list");

                // Channel Management sayfasındaki Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='channel-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Gelen Channel Form sayfasındaki Name alanına değer gir 
                _helper.SetRandomTextByName("name");

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
            try
            {
                //Channel Group Management sayfasına git           
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/channelgroup/list");

                // ChannelGroup Management sayfasında Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='channelgroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // ChannelGroup formunda name alanına random değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan channel group name i tutulur
                ChannelGroupName = _helper.GetTextByName("name");

                //Add Channel butonuna tıkla
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                //Channel seçimi yapılır
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + ChannelName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a/span[2]");
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
            try
            {
                //Variant Management sayfasına git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/variant/list");

                // Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='variant-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan variant name i tutulur
                VariantName = _helper.GetTextByName("name");

                // displayName alanına rastgele değer gir
                _helper.SetRandomTextByName("displayName");

                // Rastgele bir resim yükle
                _helper.SetRandomFileByXpath("//*[@id='variant-crud--form']/div/div/form/fieldset/div/div[1]/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

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
            try
            {
                // Priority Management sayfasına git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/priority/list");

                // Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='priority-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Pri./Dis. Name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan priortiy name i tutulur
                PriorityName = _helper.GetTextByName("name");

                //Priorty Type seç
                //_helper.SelectRandomDropdownElementByName("refValidationIntegrationTypeID");                
               
                // Rastgele bir Type seç ve seçilen option'un değerini typeSelectedValue değişkenine ata
                string typeSelectedValue = _helper.SelectRandomDropdownElementByName("refValidationIntegrationTypeID");

                if(typeSelectedValue == "Discount")
                {
                    if(typeSelectedValue.Equals("Priority"))
                    {
                        _helper.ClickByXPath("//*[@id='priority-crud--form']/div/div/form/fieldset[2]/div/div/div/div/div/p-checkbox/div/div[2]");
                    }

                    string selectedValueUrlList = _helper.SelectRandomDropdownElementByName("refPriorityValidationTypeID");

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
                       _helper.SetRandomFileByXpath("//*[@id='priority-crud--form']/div/div/form/fieldset[4]/div/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");                      
                    }
                    
                }              
                
                //Photo için bir resim seçilmesi                
                _helper.SetRandomFileByXpath("//*[@id='priority-crud--form']/div/div/form/fieldset[5]/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");
                System.Threading.Thread.Sleep(2000);

                // Description alanına rastgele bir değer gir
                //_helper.SetRandomTextByName("description");

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
            try
            {
                // Product Management sayfasına git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/product/list");

                // Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='product-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Product Name alanına restgele değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan product name i tutulur
                PriorityName = _helper.GetTextByName("name");

                // Product Type alanında rastgele seçim yap
                _helper.SelectRandomDropdownElementByName("refProductCategoryID");

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
            try
            {
                // Sales Plan Management sayfasına git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/salesplan/crud");

                // name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                //Oluşturulan Sales Plan name i tutulur
                SalesPlanName = _helper.GetTextByName("name");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='salesplan-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Çıkan modaldan OK butonuna tıkla
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(3000);

                //Rastgele Priority seç(GEÇİCİ)
                _helper.SelectRandomDropdownElementByName("refValidationIntegrationID");

                //Channel seçimi yapılır(GEÇİCİ)            
                _helper.ClickByXPath("//*[@id='salesplan-crud-330--form']/div/div/form/fieldset/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(3000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + ChannelName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Rastgele Limit koyar
                _helper.SetRandomIntegerByName("ticketLimit", 10, 100);

                
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='salesplan-crud-294--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/input");
                _helper.WaitUntilPageLoad();

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/div", finishDate);
                _helper.WaitUntilPageLoad();
                

                //Rastgele total seat sayısı belirler
                _helper.SetRandomIntegerByName("totalSeatCount", 10, 100);

                //İnsert Butonuna basar
                _helper.ClickByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[3]/div/div[3]/input");

                //Save butonuna tıklar
                _helper.ClickByXPath("//*[@id='salesplan-crud-324--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Çıkan modulde ok butonuna basar
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

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
            try
            {
                //Venue Management butonuna tıklanır 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/venue/list");
                _helper.WaitUntilPageLoad();

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
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Venue Image eklenir
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Panaromik Image eklenir
                _helper.SetRandomFileByXpath("//*[@id='venue-crud--form']/div/div/form/fieldset[6]/div/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

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
            try
            {
                // Area Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/area/list");
                _helper.WaitUntilPageLoad();

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
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueName);
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
            try
            {
                // Gate Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/gate/list");
                _helper.WaitUntilPageLoad();

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
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueName);
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
            try
            {
                // Tribune Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/tribune/list");
                _helper.WaitUntilPageLoad();

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
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueName);
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
            try
            {
                // Turnstile Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/turnstile/list");
                _helper.WaitUntilPageLoad();

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
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='turnstile-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]");
                
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
            try
            {
                // VenueTemplate Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/venuetemplate/list");
                _helper.WaitUntilPageLoad();

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
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venuetemplate-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");
                                       
                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                _helper.WaitUntilPageLoad();

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='venuetemplate-crud-594--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");
                
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
            try
            {
                // Block Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/block/list");
                _helper.WaitUntilPageLoad();

                //Block Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div/div/div[2]/form/div/div[3]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);



                //EDIT BOLUMU:

                //Block List den event seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Event Management sayfasında edit butonu tıklanır
                _helper.ClickByXPath("//*[@id='block-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");
                _helper.WaitUntilPageLoad();

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='blocklayoutgrid']/div[2]/input[1]");
                _helper.WaitUntilPageLoad();

                //Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[1]/div[1]/div/input");

                //Venue Template yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[1]/div[2]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Area seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[1]/div[3]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + AreaName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Tribune seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[2]/div[1]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + TribuneName);
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
                _helper.ClickRandomCheckbox("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[4]/div[3]/div/input");

                //Row Naming için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("rowNameTypeId");

                //Seat Start Number alanı için random değer girilir
                _helper.SetRandomIntegerByName("seatStartNumber", 1, 5);

                //Free Text alanına random değer girilir
                _helper.SetRandomTextByName("freeTextField");

                //Rastgele Top to Bottom Row Naming seçilir
                _helper.ClickRandomCheckbox("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/form/div[6]/div/div/input");

                //Gate seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[1]/div[1]/div[1]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + GateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Turnstile seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[1]/div[1]/div[2]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + TurnstileName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[3]/button[1]");

                //Add butonu tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[1]/div[1]/div[5]/button");

                //Create butonu tıklanır
                _helper.ClickByXPath("//*[@id='main']/block-crud/div[2]/div[2]/div[2]/block-layout/div/div[2]/div/div/input");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='blocklayoutseat']/input");

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
            try
            {
                // SeatClass Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/seatclass/list");
                _helper.WaitUntilPageLoad();

                //SeatClass Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='seatclass-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Seat Class name'i tutulur
                SeatClassName = _helper.GetTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Color seçimi yapılır
                //_helper.SetRandomColorByName("color");

                //Rastgele bir SeatType seçilir
                _helper.SelectRandomDropdownElementByName("SeatClassType");

                //Rastgele Visibility seçilir
                _helper.ClickRandomCheckbox("//*[@id='seatclass-crud--form']/div/div/form/fieldset/div[2]/div/div/p-checkbox/div/div[2]");

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='seatclass-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);
            }

            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.BlockManagement) + exception.Message);
                _helper.ErrorLogging(exception);
            }

        }

        //PRINTING BOLUMU
        public void TicketTemplateManagement()
        {
            try
            {
                //Ticket Template Management butonuna tıklanır 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/tickettemplate/list");
                _helper.WaitUntilPageLoad();

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tickettemplate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                TicketTemplateName = _helper.GetTextByName("name");

                //Rastgele Backround Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='tickettemplate-crud--form']/div/div/form/fieldset/div[1]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

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
            try
            {
                // Variant Configuration Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/variantconfiguration/list");
                _helper.WaitUntilPageLoad();

                //Variant Configuration Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='variantconfiguration-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Kaydedilen Variant conf Group name'i tutulur
                VariantConfigurationName = _helper.GetTextByName("name");

                //Add New butonuna tıklar
                _helper.ClickByXPath("//*[@id='variantconfiguration-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                //Variant seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='variantconfiguration-crud--form']/div/div/p-dialog/div/div[2]/div/div/div[1]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VariantName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Rastgele Variants Logo seçilir
                _helper.SetRandomFileByXpath("//*[@id='variantconfiguration-crud--form']/div/div/p-dialog/div/div[2]/div/div/div[3]/div/input", @"D:\Users\yigitb\Desktop\Images\");

                // Display Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("DisplayName");

                //Descripton alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("Description");

                //Add New butonuna tıklar
                _helper.ClickByXPath("//*[@id='variantconfiguration-crud--form']/div/div/p-dialog/div/div[2]/button");

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
            try
            {
                // Seat Class Conf. Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/seatclassconfiguration/list");
                _helper.WaitUntilPageLoad();

                //Seat Class Conf. Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Seat Class Conf name'i tutulur
                SeatClassConfigurationName = _helper.GetTextByName("name");

                //Add New butonuna tıklar
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                //Seat Class seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-crud--form']/div/div/p-dialog/div/div[2]/div/div/div[1]/div/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + SeatClassName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Add New butonuna tıklar
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-crud--form']/div/div/p-dialog/div/div[2]/button");

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
            try
            {
                // Printer Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/printer/list");
                _helper.WaitUntilPageLoad();

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
            try
            {
                //Leauge Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/league/list");
                _helper.WaitUntilPageLoad();

                //Leauge Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='league-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Leauge name'i tutulur
                LeaugeName = _helper.GetTextByName("name");

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
                _helper.ErrorLogging(exception);
            }
        }

        public void TeamManagement()
        {
            try
            {
                //Team Management url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/team/list");
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
                _helper.SetRandomFileByXpath("//*[@id='team-crud--form']/div/div/form/fieldset/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Add Leauge butonuna tıklanır
                _helper.ClickByXPath("//*[@id='team-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                System.Threading.Thread.Sleep(2000);

                //Leauge seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='team-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + LeaugeName);
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
            try
            {
                // Organizer Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/organizer/list");
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
                _helper.ErrorLogging(exception);
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

                //Kaydedilen Genre name'i tutulur
                GenreName = _helper.GetTextByName("name");

                //Add SubGenre butonuna tıklanır
                _helper.ClickByXPath("//*[@id='genre-crud--form']/div/div/form/fieldset[2]/tabset/div/tab/div/div[1]/button");

                //Leauge seçimi yapılır(GEÇİCİ)
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + LeaugeName);
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
            try
            {
                // VenueTemplate Management url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/subgenre/list");

                //VenueTemplate Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='subgenre-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //SubGenre alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Sub Genre name'i tutulur
                SubGenreName = _helper.GetTextByName("name");

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
                _helper.ErrorLogging(exception);
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

                //Kaydedilen Sponsor name'i tutulur
                SponsorName = _helper.GetTextByName("name");

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
                _helper.ErrorLogging(exception);
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

                //Kaydedilen Event Group name'i tutulur
                EventGroupName = _helper.GetTextByName("name");

                //Description alanına random text girilir
                _helper.SetRandomTextByXPath("//*[@id='eventgroup-crud--form']/div/div/form/fieldset/div/div/div[2]/input");

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
                _helper.ErrorLogging(exception);
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

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");

                //oluşturulan yeni Serie name i tutulmalıdır.
                SerieName = _helper.GetTextByName("name");

                //Genre seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + GenreName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Team seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + TeamName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Sub Genre için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("refSubGenreID");

                //Rastgele Team Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //TicketType seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[9]/div[2]/lookup/div/div[3]/button[1]");

                /*
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[3]/div/div/div[2]/p-calendar/span/input");

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/div", finishDate);
                */

                //Next butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[4]/input");

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[10]/div[2]/lookup/div/div[3]/button[1]");

                //SalesPlan seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + SalesPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[11]/div[2]/lookup/div/div[3]/button[1]");

                //League seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + LeaugeName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[12]/div[2]/lookup/div/div[3]/button[1]");

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + OrganizerName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");

                /*
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate2 = _helper.SetRandomDateTimeByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset[3]/div/div/div[2]/p-calendar/span/input");

                // Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate2 = _helper.SetRandomDateTimeAfterThisDateTime(startDate2);
                _helper.SetDateTimeByXPath("//*[@id='salesplan-crud-302--form']/div/div/form/fieldset/div[2]/div/div[1]/p-calendar/span/div", finishDate2);
                */

                //League Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Venue Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[3]/button[1]");

                //Event Group seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + EventGroupName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[3]/button[1]");

                //Seat Class Configuraton seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + SeatClassConfigurationName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Next butonu tıklanır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[4]/input[2]");

                //Payment Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + PaymentPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[17]/div[2]/lookup/div/div[3]/button[1]");

                //Ticket Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + TicketTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Cofiguration Configuraton seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VariantName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Sponsor seçimi yapılır
                _helper.ClickByXPath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + SponsorName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[18]/div[2]/lookup/div/div[3]/button[1]");

                //Home Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[3]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

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

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[1]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + OrganizerName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");

                //Venue seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[8]/div[2]/lookup/div/div[3]/button[1]");

                //Venue Template seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[1]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VenueTemplateName);
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

                //Genre seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + GenreName);
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
                _driver.FindElement(By.Name("searchText")).SendKeys("" + GenreName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[14]/div[2]/lookup/div/div[3]/button[1]");

                //Sponsor seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + SponsorName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[15]/div[2]/lookup/div/div[3]/button[1]");
                /*
                //Door Opening time seçilir
                DateTime startDate4 = _helper.SetRandomDateTimeByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[3]/div/div[3]/p-calendar/span/input");
                */
                //Next butonuna tıklanır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[2]/div[4]/input[2]");

                //CONF BOLUMU

                //Payment Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + PaymentPlanName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[16]/div[2]/lookup/div/div[3]/button[1]");

                //Sales Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[1]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + SalesPlanName);
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
                _driver.FindElement(By.Name("searchText")).SendKeys("" + EventGroupName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[19]/div[2]/lookup/div/div[3]/button[1]");

                //Seat Class Configuration seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + SeatClassConfigurationName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Variant Configuration seçimi yapılır
                _helper.ClickByXPath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[2]/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys("" + VariantConfigurationName);
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
                _driver.FindElement(By.Name("searchText")).SendKeys("" + TicketTemplateName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]/td[1]");
                _helper.ClickByXPath("/html/body/div[6]/div[2]/lookup/div/div[3]/button[1]");

                //Home Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='event-crud--form']/div/div/form/fieldset/tabset/div/tab[3]/div[5]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Detail Page Description 
                _helper.SetRandomTextByName("detailPageDescription");

                //Free Passcard Count
                _helper.SetRandomIntegerByName("freePasscardCount", 1, 50);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id'event-crud-1442--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);





                //EDIT BOLUMU:

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
            try
            {
                //Booking Action Type Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/bookingactiontype/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='bookingactiontype-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");

                //Action Type için rastgele selection yapılır
                _helper.SelectRandomDropdownElementByName("actionTypeCmb");

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='bookingactiontype-crud--booking-action-type-form']/div/div/fieldset[2]/tabset/div/tab/div/div[1]/form/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + OrganizerName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Payment Plan seçimi yapılır
                _helper.ClickByXPath("//*[@id='bookingactiontype-crud--booking-action-type-form']/div/div/fieldset[2]/tabset/div/tab/div/div[1]/form/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + PaymentPlanName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
                _helper.ErrorLogging(exception);
            }
        }

        //AC BOLUMU
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

                //Kaydedilen AC Setting name'i tutulur
                ACSettingName = _helper.GetTextByName("name");

                //Random AC Control Provider seçimi yapılır
                _helper.SelectRandomDropdownElementByName("accessControlProvider");

                //Destination alanına rastgele bir text girilir
                _helper.SetRandomTextByName("destination");

                //Destination alanına rastgele bir int girilir
                _helper.SetRandomIntegerByXpath("//*[@id='accesscontrolsetting-crud--form']/div/div/form/fieldset/div[2]/div/div[1]/input", 10, 100);

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
            try
            {
                //Telegram Queue Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/telegramqueue/list");

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
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + ACSettingName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
            try
            {
                // Bin Number Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/telegram/list");

                //Telegram Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='telegram-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Telegram Queue seçimi yapılır
                _helper.ClickByXPath("//*[@id='telegram-crud--form']/div/div/form/fieldset/div[1]/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + TelegramQueueName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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

                //Bin Number Goup seçimi yapılır
                _helper.ClickByXPath("//*[@id='binnumbergroupitem-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + BinNumberGroupName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
                _helper.ErrorLogging(exception);
            }
        }

        //SECURITY BOLUMU
        public void Clients()
        {
            try
            {
                //Users Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/client/list");

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
                _helper.SetRandomIntegerByXpath("//*[@id='client-crud--form']/div/div/form/fieldset[3]/div/div/div[2]/input", 10, 10);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='client-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                //Kaydedilen Venue name'i tutulur
                //_helper.GetTextByPath("//*[@id='venue-crud-417;formtype=read--form']/div/div/form/fieldset[1]/div/div/div[1]/input");   

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
            try
            {
                //Users Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/bookingoperator/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='bookingoperator-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //First Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("firstname");
                string FirstName = _helper.GetTextByName("firstname");

                //Last Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("lastname");

                //MobilePhone alanına rastgele bir int girilir
                _helper.SetRandomIntegerByXpath("//*[@id='bookingoperator-crud--user-form']/div/div/fieldset[1]/div/form/div[1]/div[3]/div/input", 10, 10);

                //User Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("username");

                //Password alanına rastgele bir değer girilir
                _helper.SetRandomIntegerByXpath("//*[@id='bookingoperator-crud--user-form']/div/div/fieldset[1]/div/form/div[2]/div[2]/div/input", 5, 8);

                //Random Email girilir
                _helper.SetRandomEmailByName("email");

                //Operator Image alanına random resim eklenir
                _helper.SetRandomFileByXpath("//*[@id='bookingoperator-crud--user-form']/div/div/fieldset[1]/div/form/div[3]/div/div/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Add Role butonuna tıklanır
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/div/fieldset[2]/tabset/div/tab[1]/div/div[1]/button");

                System.Threading.Thread.Sleep(2000);

                //Role seçimi yapılır
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/p-dialog/div/div[2]/lookup/div/div[3]/button[1]");


                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='bookingoperator-crud--user-form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                //Kaydedilen Venue name'i tutulur
                //_helper.GetTextByPath("//*[@id='venue-crud-417;formtype=read--form']/div/div/form/fieldset[1]/div/div/div[1]/input");   

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
            try
            {
                //Roles Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/scrole/list");

                //Roles sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='scrole-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir text girilir
                _helper.SetRandomTextByName("name");

                //Description alanına rastgele bir text girilir
                _helper.SetRandomTextByXPath("//*[@id='scrole-crud--role-form']/div/fieldset/form/div[2]/div/textarea");

                //Rastgele yüzde girilir
                _helper.SetRandomIntegerByXpath("//*[@id='scrole-crud--role-form']/div/div[2]/fieldset/tabset/div/tab[1]/div[1]/input", 1, 100);

                //Business Rights butonuna tıklar
                _helper.ClickByXPath("//*[@id='tabControl']/li[2]/a");

                //Rastgele yüzde girilir
                _helper.SetRandomIntegerByXpath("//*[@id='scrole-crud--role-form']/div/div[2]/fieldset/tabset/div/tab[2]/div/div/input", 1, 100);

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
            try
            {
                //ApprovableUsers url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/scapprovableuser/list");

                //User seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='scapprovableuser-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                //Approve butonuna tıklar
                _helper.ClickByXPath("//*[@id='scapprovableuser-list--default-widget']/div/div/div[2]/button");

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
            try
            {
                //Terminals url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/terminal/list");

                //Terminals sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='terminal-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random text girilir
                _helper.SetRandomTextByName("name");

                //Code alanına random 3 haneli code girilir.
                _helper.SetLimitedRandomStringByName("code", 3);

                //Terminal Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='terminal-crud--form']/div/div/form/fieldset/div[2]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //Ticket Printer seçimi yapılır
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/form/fieldset/div[2]/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Add Organizer butonuna tıkla
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                System.Threading.Thread.Sleep(2000);

                //Organizer seçimi yapılır
                _helper.ClickByXPath("//*[@id='terminal-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                //_driver.FindElement(By.Name("searchText")).SendKeys("" + OrganizerName);
                //_driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
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
            try
            {
                //Entry Point url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/entrypoint/list");

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
                _helper.SetRandomIntegerByXpath("//*[@id='entrypoint-crud--form']/div/div/div[2]/div[3]/input", 100, 1000);

                //Add butonuna tıklanır
                _helper.ClickByXPath("//*[@id='entrypoint-crud--form']/div/div/div[2]/div[4]/div/button");

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

