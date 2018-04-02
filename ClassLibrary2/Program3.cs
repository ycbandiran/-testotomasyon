using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Selenium.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using Helpers;
using System.Threading;

namespace Payment
{
    class Program3
    {
        static void Main(string[] args)
        {
            PaymentTests paymentTest = new PaymentTests();

            paymentTest.PaymentGateway();
            paymentTest.BinNumberGroup();
            paymentTest.BinNumber();
            paymentTest.PaymentPlan();

        }
    }
}
