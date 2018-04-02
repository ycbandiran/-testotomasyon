﻿using Helpers;
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
    class BlackListManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        //public IWebElement webElement;

        //oluşturulan yeni venue id si tutulmalıdır.
        //  string venue_id;

        public BlackListManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

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
                /*
                // Başlangıç tarihini bitiş tarihini belirlerken kullanmak için değişkene atıyoruz
                DateTime startDate = _helper.SetRandomDateTimeByXPath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[1]/div/div/div[3]/p-calendar/span/input");              
                */
                //Random Letter No girilir
                _helper.SetRandomIntegerByXpath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[2]/div/div/div[1]/input", 1, 10);

                //Last Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("lastName");
                /*
                //Finish Date alanına Start Date tarihinden sonraki bir tarihte rastgele bir tarih gir
                DateTime finishDate = _helper.SetRandomDateTimeAfterThisDateTime(startDate);
                */
                _helper.SetDateTimeByXPath("//*[@id='nationalidprobation-crud--probation-form']/div/div/p-tabview/div/div/p-tabpanel[1]/div/form/fieldset[2]/div/div/div[3]/p-calendar/span/input", finishDate);

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
            }
        }
    }
}

