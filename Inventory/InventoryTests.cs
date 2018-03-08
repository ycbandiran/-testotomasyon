using Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory
{
    class InventoryTests
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;

        public InventoryTests()
        {
            _driver = new ChromeDriver();
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Inventory modül testi başladı.");
        }

        public void CategoryManagement()
        {
            try
            {                
                // Kullanıcı ismi ve şifre girişi
                //_helper.GoToUrl("http://backoffice.netasticketing.com/login");

                // Login ol
                //_helper.Login("superadmin", "Netas2017*-");

                // Inventory Management butonuna tıkla
                _helper.ClickByXPath("//*[@id='left-panel']/nav/ul/li[4]/a");

                // Inventory Management altındaki Category Management butonuna tıkla
                _helper.ClickByXPath("//*[@id='left-panel']/nav/ul/li[4]/ul/li[1]/a");

                // Category Management sayfasında Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='category-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                // Name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                // Color alanına rastgele değer gir
                _helper.SetRandomColorByName("color");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='category-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a/span[2]");

                // Gelen modaldan OK butonuna tıkla
                _helper.ClickByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div/div/div[3]/button[1]");
                //_helper.IsVisibleByXPath("//*[@id='category-list--default-widget']/div/div/div[2]/input");
            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.CategoryManagement) + exception.Message);
            }
        }

        public void ChannelManagement()
        {
            try
            {
                // Sol panelden Channel Management butonuna tıkla
                //_helper.ClickByXPath("//*[@id='left-panel']/nav/ul/li[4]/ul/li[2]/a");
                _driver.Navigate().GoToUrl("http://backoffice.netasticketing.com/channel/list");
                // Channel Management sayfasındaki Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='channel-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                // Gelen Channel Form sayfasındaki Name alanına değer gir ve Save butonuna tıkla
                _helper.SetRandomTextByName("name");

                // Rastgele bir rol seç
                _helper.SelectDropdownElementByName("clientApplicationRole");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='channel-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // modalın görünürlüğüne bak
                _helper.IsVisibleByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div");

                // Gelen modal üzerindeki OK butonuna tıkla
                _helper.ClickByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div/div/div[3]/button[1]");
                Thread.Sleep(3000);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        
        public void ChannelGroupManagement()
        {
            try
            {
                // Sol panelden ChannelGroup Management'a tıkla
                //_helper.ClickByXPath("//*[@id='left-panel']/nav/ul/li[4]/ul/li[3]/a");
                _driver.Navigate().GoToUrl("http://backoffice.netasticketing.com/channelgroup/list");                

                // ChannelGroup Management sayfasında Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='channelgroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                // ChannelGroup formunda name alanına random değer gir
                _helper.SetRandomTextByName("name");

                // ChannelGroup formunda Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='channelgroup-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a/span[2]");

                // Ekrana çıkan Uyarı modalından OK butonuna tıkla
                _helper.ClickByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div/div/div[3]/button[1]");

                //Thread.Sleep(3000);
                // Son eklenen ChannelGroup'u seç
                _helper.ClickByXPath("//*[@id='channelgroup-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

                // Edit butonuna tıklıyoruz
                _helper.ClickByXPath("//*[@id='channelgroup-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");
                
                // Random olarak checkbox'lara tıkla
                _helper.SelectRandomCheckboxesByName("ChannelList");

                // Alltaki Save butonuna tıkla
                _helper.ClickByXPath("//div/div/fieldset/div/div/input");
            }
            catch (Exception exception)
            {
                _helper.GiveError(exception.Message);
            }
        }

        public void VariantManagement()
        {
            try
            {
                _helper.GoToUrl("http://backoffice.netasticketing.com/variant/list");
                // Sol paneldel Variant Management bağlantısına tıkla
                //_helper.ClickByXPath("//*[@id='left-panel']/nav/ul/li[4]/ul/li[4]/a");

                // Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='variant-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");

                // name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                // displayName alanına rastgele değer gir
                _helper.SetRandomTextByName("displayName");

                // Rastgele bir resim yükle
                //_helper.SetRandomFileByXPhat("//*[@id='variant-crud--form']/div/div/form/fieldset/div/div/div[3]/file-upload/div/input", @"D:/Users/ocirakli/source/repos/TestOtomasyon/Excels/");
                //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='variant-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");
                
                // Çıkan modaldan OK butonua tıkla
                _helper.ClickByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div/div/div[3]/button[1]");

                //_helper.ClickByXPath("//*[@id='left-panel']/nav/ul/li[4]/ul/li[5]/a");
                //_helper.ClickByXPath("//*[@id='priority-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a/span[2]");
                //_helper.SetRandomTextByName("name");
                //_helper.ClickByName("refValidationIntegrationTypeID");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void PriorityManagement()
        {
            try
            {
                // Priority Management sayfasına git
                _helper.GoToUrl("http://backoffice.netasticketing.com/priority/list");

                // Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='priority-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Pri./Dis. Name alanına rastgele değer gir
                _helper.SetRandomTextByName("name");

                // Integration checkbox'ını seçer ya da seçmez
                _helper.SelectRandomCheckboxByName("isIntegration");

                // Rastgele bir tip seç ve seçilen option'un değerini typeSelectedValue değişkenine ata
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

                // Rastgele bir resim seç
               // _helper.SetRandomFileByXPhat("//*[@id='priority-crud--form']/div/div/form/fieldset[5]/div[1]/file-upload/div/input", @"D:/Users/ocirakli/source/repos/TestOtomasyon/Images/");

                // Resim düzgünce yüklendi mi
                _helper.IsVisibleByXPath("//*[@id='priority-crud--form']/div/div/form/fieldset[5]/div[1]/file-upload/table");

                // Description alanına rastgele bir değer gir
                //_driver.FindElement(By.Name("description")).Clear();
                //_helper.SetRandomTextByName("description");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='priority-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Çıkan modaldan OK butonuna tıkla
                _helper.ClickByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div/div/div[3]/button[1]");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message); ;
            }

        }

        public void ProductManagement()
        {
            try
            {
                // Product Management sayfasına git
                _helper.GoToUrl("http://backoffice.netasticketing.com/product/list");

                // Add New butonuna tıkla
                _helper.ClickByXPath("//*[@id='product-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Product Name alanına restgele değer gir
                _helper.SetRandomTextByName("name");

                // Product Type alanında rastgele seçim yap
                _helper.SelectDropdownElementByName("refProductCategoryID");

                // Save butonuna tıkla
                _helper.ClickByXPath("//*[@id='product-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                // Çıkan modaldan OK butonuna tıkla
                _helper.ClickByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div/div/div[3]/button[1]");
            }
            catch (Exception exception)
            {
                _helper.GiveError(exception.Message);
            }

        }

        public void SalesPlanManagement()
        {
            // Sales Plan Management sayfasına git
            _helper.GoToUrl("http://backoffice.netasticketing.com/salesplan/crud");

            // name alanına rastgele değer gir
            _helper.SetRandomTextByName("name");

            // Save butonuna tıkla
            _helper.ClickByXPath("//*[@id='salesplan-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

            // Çıkan modaldan OK butonuna tıkla
            _helper.ClickByXPath("/html/body/dialog-holder/dialog-wrapper/div/confirm-dialog/div/div/div[3]/button[1]");

            // Son kaydedilen Sales Plan'ı seç
            _helper.ClickByXPath("//*[@id='salesplan-list--default-widget']/div/div/p-datatable/div/div[1]/table/tbody/tr[1]");

            // Edit butonuna tıkla
            _helper.ClickByXPath("//*[@id='salesplan-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[3]/a");

            // Sales Plan Item Form'da bulunan satıra tıkla
            _helper.ClickByXPath("//*[@id='salesplan-crud-133--form']/div/div/salesplanitem-crud/div/div/div[2]/form/div[4]/div/p-datatable/div/div[1]/table/tbody/tr");

            // Priority alanını rastgele değiştir ya da değişiklik yapma
            
        }
    }
}
