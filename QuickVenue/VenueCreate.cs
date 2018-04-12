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




namespace QuickVenue
{
    public class VenueCreate
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        //public IWebElement webElement;

        //oluşturulan yeni venue id si tutulmalıdır.
        //  string venue_id;

        public VenueCreate()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

        public void VenueCreate1()
        {
            try
            {
                //Venue Create Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/quickvenue/crud");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                string venuename = _helper.GetTextByName("name");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("code", 3);

                //Country seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[2]/div/div/div[1]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[4]/div[2]/lookup/div/div[3]/button[1]");

                //City seçimi yapılır(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[2]/div/div/div[2]/lookup-button/div/div/div/button");
                System.Threading.Thread.Sleep(2000);
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[5]/div[2]/lookup/div/div[3]/button[1]");

                /*
                //County seçimi yapılır(GEÇİCİ)(ŞU AN KULLANILMIYOR)
                _helper.ClickByXPath("//*[@id="quickvenue-crud--form"]/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[2]/div/div/div[3]/lookup-button/div/div/div/button");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[2]/p-datatable/div/div[1]/div/div[2]/div/table/tbody/tr[1]");
                _helper.ClickByXPath("/html/body/div[7]/div[2]/lookup/div/div[3]/button[1]");
                */

                //Address alanına rastgele bir text girilir
                _helper.SetRandomTextByName("address");

                //Description alanına rastgele bir text girilir
                _helper.SetRandomTextByName("venueDescription");

                //Public Transportation alanına rastgele bir text girilir
                _helper.SetRandomTextByName("hasParkingArea");

                //Has parkin area alanında random seçim yapılır
                int result = _helper.ClickRandomRadioButton("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[4]/div/div/div[1]/div/label[1]/input", "//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[4]/div/div/div[1]/div/label[2]/input");
                if (result == 1)
                {
                    //Parking Area Capacity alanına random bir değer girilmesi 
                    _helper.SetRandomIntegerByXpath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[5]/div/div/div/input", 30, 100);
                }

                //Latitude alanının random olarak girilmesi
                _helper.SetTextByName("latitude", _helper.GetRandomLatitude());

                //Longitude alanının random olarak girilmesi
                _helper.SetTextByName("longitude", _helper.GetRandomLatitude());

                //Rastgele Logo Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[6]/div[1]/div/div[1]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");

                //3. FAZDA YAPILACAK!!
                /*
                //Rastgele Venue Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset[2]/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");
                
                //Rastgele Panaromic Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='serie-crud--form']/div/div/form/fieldset[2]/div/div/div[3]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");
                */

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[6]/div[2]/input");

                //Kaydedilen Venue name'i tutulur
                //_helper.GetTextByPath("//*[@id='venue-crud-417;formtype=read--form']/div/div/form/fieldset[1]/div/div/div[1]/input");   

                System.Threading.Thread.Sleep(3000);

                //VENUE TEMPLATE SEÇİMİ

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[2]/div/quickvenuetemplate-crud/form/fieldset/div[1]/div/div[1]/input");
                string templatename = _helper.GetTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[2]/div/quickvenuetemplate-crud/form/fieldset/div[1]/div/div[1]/input");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[2]/div/quickvenuetemplate-crud/form/fieldset/div[1]/div/div[2]/input", 3);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[2]/div/quickvenuetemplate-crud/form/fieldset/div[2]/input");
                
                //Next butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/div/input");
                                      
                System.Threading.Thread.Sleep(3000);

                //AREA SEÇİMİ

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[3]/div/quickarea-crud/form/fieldset/div[1]/div/div[1]/input");
                string area = _helper.GetTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[3]/div/quickarea-crud/form/fieldset/div[1]/div/div[1]/input");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[3]/div/quickarea-crud/form/fieldset/div[1]/div/div[2]/input", 3);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[3]/div/quickarea-crud/form/fieldset/div[2]/input");

                //tribune butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/ul/li[4]/a");

                System.Threading.Thread.Sleep(3000);

                //TRIBUNE SEÇİMİ

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[4]/div/quicktribune-crud/form/fieldset[1]/div/div/div[1]/input");
                string tribune = _helper.GetTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[4]/div/quicktribune-crud/form/fieldset[1]/div/div/div[1]/input");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[4]/div/quicktribune-crud/form/fieldset[1]/div/div/div[2]/input", 3);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[4]/div/quicktribune-crud/form/fieldset[2]/div[2]/input");

                //turnstile butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/ul/li[5]/a");

                System.Threading.Thread.Sleep(3000);

                //TURNSTILE SEÇİMİ

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[5]/div/quickturnstile-crud/form/fieldset/div[1]/div/div[1]/input");
                string turnstile = _helper.GetTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[5]/div/quickturnstile-crud/form/fieldset/div[1]/div/div[1]/input");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[5]/div/quickturnstile-crud/form/fieldset/div[1]/div/div[2]/input", 3);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[5]/div/quickturnstile-crud/form/fieldset/div[2]/input");
                                      
                //Gate butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/ul/li[6]/a");

                System.Threading.Thread.Sleep(3000);

                //GATE SEÇİMİ

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[6]/div/quickgate-crud/form/fieldset/div[1]/div/div[1]/input");
                string gate = _helper.GetTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[6]/div/quickgate-crud/form/fieldset/div[1]/div/div[1]/input");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[6]/div/quickgate-crud/form/fieldset/div[1]/div/div[2]/input", 3);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[6]/div/quickgate-crud/form/fieldset/div[2]/input");

                //Block butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/ul/li[7]/a");

                System.Threading.Thread.Sleep(3000);

                //BLOCK SEÇİMİ

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[7]/div/quickblock-crud/div/div/div[2]/form/div[1]/div[1]/div/input");
                string block = _helper.GetTextByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[7]/div/quickblock-crud/div/div/div[2]/form/div[1]/div[1]/div/input");

                //Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[7]/div/quickblock-crud/div/div/div[2]/form/div[1]/div[2]/div/input", 3);

                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='quickvenue-crud--form']/div/div/p-tabview/div/div/p-tabpanel[7]/div/quickblock-crud/div/div/div[2]/form/div[2]/input");

                System.Threading.Thread.Sleep(3000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.VenueCreate1) + exception.Message);
                _helper.ErrorLogging(exception);
            }
        }
    }
}


