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




namespace BlackList
{
    public class BlackListManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;

        //oluşturulan yeni National id name i tutulmalıdır.
        string NationalIDName;

        public BlackListManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Blacklist modül testi başladı.");

        }

        public void NationalIDManagement()
        {
            _helper.GivePassInfo("National Id modül testi başladı.");

            try
            {
                //NationalID Url gidilir 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/nationalidprobation/list");
                System.Threading.Thread.Sleep(2000);

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='nationalidprobation-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");
                                      
                //National ID alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("nationalId");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                 NationalIDName = _helper.GetTextByName("name");
                
                //Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                 DateTime StartDate = _helper.SetRandomDateTimeByName("startDate");
                _helper.WaitUntilPageLoad();

                //Random Letter No girilir
                _helper.SetRandomIntegerByName("officalLetterNo", 1, 10);

                //Last Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("lastName");
                
                //Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                 DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(StartDate);               
                _helper.SetDateTimeByName("endDate", finishDate);
                _helper.WaitUntilPageLoad();

                //Country Code alanına rastgele 3 karakter girilir
                _helper.SetLimitedRandomStringByName("countryCode", 3);

                //Rastgele checkbox seçimi yapar
                _helper.SelectRandomCheckboxesByName("status");

                //Probation Image seçilir
                _helper.SetRandomFileByXpath("probationImageName", @"D:\Users\yigitb\Desktop\Images\");

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
    }
}


