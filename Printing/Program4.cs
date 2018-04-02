using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printing
{
    class Program4
    {
        static void Main(string[] args)
        {
            PrintingManagement printing = new PrintingManagement();
         
            printing.PrinterManagement();                     
            printing.TicketTemplateManagement();
            printing.VariantConfigurationManagement();
            printing.SeatClassConfigurationManagement();
            printing.PrinterManagement();
            
        }
    }
}
