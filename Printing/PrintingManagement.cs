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




namespace Printing
{
    class PrintingManagement
    {
        public IWebDriver _driver { get; set; }
        IWait<IWebDriver> _task;
        Random _random;
        Helper _helper;
        //public IWebElement webElement;

        //oluşturulan yeni venue id si tutulmalıdır.
        //  string venue_id;

        public PrintingManagement()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _task = new WebDriverWait(_driver, TimeSpan.FromSeconds(130));
            _random = new Random();
            _helper = new Helper(_driver, _task, "superadmin", "Netas2017*-");
            _helper.GiveInfo("Venue modül testi başladı.");

        }

        public void TicketTemplateManagement()
        {
            try
            {
                //Ticket Template Management butonuna tıklanır 
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/tickettemplate/list");

                //Add new butonuna tıklanır
                _helper.ClickByXPath("//*[@id='tickettemplate-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına rastgele bir değer girilir
                _helper.SetRandomTextByName("name");
                string venueName = _helper.GetTextByName("name");

                //Rastgele Backround Image seçilir
                _helper.SetRandomFileByXpath("//*[@id='tickettemplate-crud--form']/div/div/form/fieldset/div[1]/div/div[2]/file-upload/div/input", @"D:\Users\yigitb\Desktop\Images\");


                

                //TİCKET TEMPLATE DESIGN YAPILACAK!!!!!!!




                //Save butonu tıklanır
                _helper.ClickByXPath("//*[@id='tickettemplate-crud--form']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[1]/a");

                //Gelen modal da OK tıklanır
                _helper.ClickById("confirmok");

                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception exception)
            {
                _helper.GiveError("In : " + nameof(this.TicketTemplateManagement) + exception.Message);
            }
        }


        public void VariantConfigurationManagement()
        {
            try
            {
                // Variant Configuration Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/variantconfiguration/list");

                //Variant Configuration Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='variantconfiguration-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                // Name alanına rastgele bir değer girilir.
                _helper.SetRandomTextByName("name");

                //Add New butonuna tıklar
                _helper.ClickByXPath("//*[@id='variantconfiguration-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                //Variant seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='variantconfiguration-crud--form']/div/div/p-dialog/div/div[2]/div/div/div[1]/div/lookup-button/div/div/div/button");
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
            }
        }
        public void SeatClassConfigurationManagement()
        {
            try
            {
                // Seat Class Conf. Management Url git
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/seatclassconfiguration/list");

                //Seat Class Conf. Management sayfasında add new butonu tıklanır
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-list--default-widget']/div/div/toolbar/p-menubar/div/p-menubarsub/ul/li[2]/a");

                //Name alanına random değer girilir
                _helper.SetRandomTextByName("name");

                //Add New butonuna tıklar
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-crud--form']/div/div/fieldset/tabset/div/tab/div/div[1]/button");

                //Seat Class seçimi yapılı(GEÇİCİ)
                _helper.ClickByXPath("//*[@id='seatclassconfiguration-crud--form']/div/div/p-dialog/div/div[2]/div/div/div[1]/div/lookup-button/div/div/div/button");
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
            }
        }

        public void PrinterManagement()
        {
            try
            {
                // Printer Management butonuna tıkla
                _helper.GoToUrl("http://testbackoffice.netasticketing.com/printer/list");

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
            }
        }

    }    
}