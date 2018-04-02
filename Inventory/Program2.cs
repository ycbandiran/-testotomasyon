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

namespace Inventory
{
    class Program2
    {
        static void Main(string[] args)
        {
            InventoryTests inventoryTests = new InventoryTests();
            
            inventoryTests.CategoryManagement();
            inventoryTests.ChannelManagement();              
            inventoryTests.ChannelGroupManagement();
            inventoryTests.VariantManagement();
            inventoryTests.PriorityManagement();
            inventoryTests.ProductManagement();            
            inventoryTests.SalesPlanManagement();
        }        
    }
}
