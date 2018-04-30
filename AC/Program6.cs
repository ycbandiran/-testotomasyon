using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC
{
    class Program6
    {
        static void Main(string[] args)
        {
            ACManagement aCManagement = new ACManagement();

            aCManagement.ACSetting();
            aCManagement.TelegramQueueManagement();
            aCManagement.TelegramManagement();            
        }
    }
}
