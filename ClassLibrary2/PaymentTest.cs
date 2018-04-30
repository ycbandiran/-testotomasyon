using Helpers;
using Inventory;
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




namespace Payment
{
    public class PaymentTests
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        InventoryTests _inventory;

        //oluşturulan yeni Payment Gateway name i tutulmalıdır.
        public string PaymentGatewayName;

        //oluşturulan yeni Bin Number Group name i tutulmalıdır.
        public string BinNumberGroupName;

        //oluşturulan yeni Bin Number name i tutulmalıdır.
        public string BinNumberName;

        //Oluşturulan yeni Payment Plan name i tutulmalıdır.
        public string PaymentPlanName;


        public PaymentTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Payment modül testi başladı.");

        }

        public void PaymentGateway()
        {
            _helper.GivePassInfo("Payment Gateway modül testi başladı.");

            try
            {
                //Payment Gateway Url git
                _helper.GoToUrl("http://localhost:4200/paymentgateway/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='paymentgateway-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                
                //Kaydedilen Payment Gateway name'i tutulur
                PaymentGatewayName = _helper.GetTextByName("name");

                //TerminalId alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("terminalId", 3);

                //MerchantId alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("terminalMerchantId", 3);

                //ProvUserId alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("terminalProvUserId", 3);

                //ProwPassword alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("terminalProvPassword", 3);

                //StoreKey alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("storeKey", 3);

                //ApiVersion alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("apiVersion", 3);

                //3D Securiy level alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("threeDSecurityLevel", 3);

                //UserId alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("userId", 3);

                //3D Pay Gateway Url alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("threeDPaymentGatewayUrl", 3);

                //Payment Gateway Url alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("normalPaymentGatewayUrl", 3);

                //Success Url alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("successUrl", 3);

                //Fail Url alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("failUrl", 3);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='paymentgateway-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.PaymentGateway) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }


        public void BinNumberGroup()
        {
            _helper.GivePassInfo("Bin Number Group modül testi başladı.");

            try
            {
                // Bin number Group Url git
                _helper.GoToUrl("http://localhost:4200/binnumbergroup/list");

                //Bin number Group sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='binnumbergroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");
               
                //Kaydedilen Bin Number Group name'i tutulur
                BinNumberGroupName = _helper.GetTextByName("name");

                //Payment Gateway seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='binnumbergroup-crud--form']/div/div/form/fieldset/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(PaymentGatewayName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='binnumbergroup-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.BinNumberGroup) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }
        public void BinNumber()
        {
            _helper.GivePassInfo("Bin Number modül testi başladı.");

            try
            {
                // Bin Number Url git
                _helper.GoToUrl("http://localhost:4200/binnumbergroupitem/list");

                //Block Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='binnumbergroupitem-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Kaydedilen Bin Number name'i tutulur
                BinNumberName = _helper.GetTextByName("name");

                //Bin number alanına random int girilir.
                _helper.SetRandomIntegerByName("binNumber", 1, 5);

                //Bin Number Goup seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='binnumbergroupitem-crud--form']/div/div/form/fieldset/div/div/div[3]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _driver.FindElement(By.Name("searchText")).SendKeys(BinNumberGroupName);
                _driver.FindElement(By.Name("searchText")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='binnumbergroupitem-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.BinNumberGroup) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }

        public void PaymentPlan()
        {
            _helper.GivePassInfo("Payment Plan modül testi başladı.");

            try
            {
                //Payment Plan Url git
                _helper.GoToUrl("http://localhost:4200/paymentplan/list");

                //Payment Plan sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='paymentplan-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Girilen Payment Plan Name değeri tutulur
                PaymentPlanName = _helper.GetTextByName("name");

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='main']/paymentplan-crud/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

                //Yapılmış Payment Plan ı edit için bulur
                _driver.FindElement(By.XPath("//*[@id='paymentplan-list--default-widget']/div/div/div[2]/input")).SendKeys(BinNumberGroupName);
                _driver.FindElement(By.XPath("//*[@id='paymentplan-list--default-widget']/div/div/div[2]/input")).SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("//*[@id='paymentplan-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr");

                //Payment Plan sayfasında edit butonu tıklanır
                _helper.ClickByXPath("//*[@id='paymentplan-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");

                //Payment Plan sayfasında add new butonu tıklanır
                _helper.ClickByName("AddNewButton");

                //Bin Number Group seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[1]/div[1]/div/angular2-multiselect/div/div[1]/button");
                _driver.FindElement(By.XPath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[1]/div[1]/div/angular2-multiselect/div/div[2]/div[2]/div[2]/input")).SendKeys(BinNumberGroupName);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[1]/div[1]/div/angular2-multiselect/div/div[2]/div[2]/ul/li[1]");

                //Channel seçimi yapılır
                _helper.ClickByXPath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[1]/div[2]/div/angular2-multiselect/div/div[1]/button");
                //_driver.FindElement(By.XPath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[1]/div[2]/div/angular2-multiselect/div/div[2]/div[2]/div[2]/input")).SendKeys("" + _inventory.ChannelName);
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[1]/div[2]/div/angular2-multiselect/div/div[2]/div[2]/ul/li[1]");

                //Installment alanına random değer girilir
                _helper.ClickByXPath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[2]/div/div/div/div/div[2]/div[1]/input");
                _helper.SetRandomIntegerByXpath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[2]/div/div/div/div/div[2]/div[1]/input", 10,100);

                //Interest Rate alanına random değer girilir
                _helper.SetRandomIntegerByXpath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[2]/div/div/div/div/div[2]/div[2]/input", 5, 30);

                //Discount alanına random değer girilir
                _helper.SetRandomIntegerByXpath("//*[@id='main']/paymentplan-crud/div/div[3]/form/div/div[2]/div/div/div/div/div[2]/div[3]/input", 5, 50);

                //Submit butonuna tıklanır
                _helper.ClickByName("SubmitButton");

                System.Threading.Thread.Sleep(3000);

                //Save butonuna tıklanır
                _helper.ClickByXPath("//*[@id='main']/paymentplan-crud/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");
                                    
                //Gelen modal dan OK butonuna tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.PaymentPlan) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }
    }
}




