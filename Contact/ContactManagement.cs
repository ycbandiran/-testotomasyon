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




namespace Contact
{
    public class ContactManagement
    { 
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;

        public ContactManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");         
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Contact modül testi başladı.");

        }

        public void Contacts()
        {
            _helper.GivePassInfo("Contacts modül testi başladı.");

            try
            {
                //Contact Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/contact/list");
                System.Threading.Thread.Sleep(3000);

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='contact-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                System.Threading.Thread.Sleep(2000);

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
    }
}


