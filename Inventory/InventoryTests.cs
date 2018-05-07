using Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support;
using System.Data.SqlClient;
using System.IO;
using Selenium.Helper;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace Inventory
{
    public class InventoryTests
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

        public InventoryTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized"); 
            _driver = new ChromeDriver(options); 
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Inventory modül testi başladı.");
        }


        public void CategoryManagement()
        {
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
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(ChannelName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/p-dialog/div/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr");
                _helper.ClickByName("lookupSelect");

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

                System.Threading.Thread.Sleep(3000);

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

    }
}
