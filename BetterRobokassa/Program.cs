using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterRobokassa
{
    class Program
    {
        static void Main(string[] args)
        {
            string redirectUrl = Robokassa.Robokassa.GetRedirectUrl(1000, 1);
            Console.WriteLine(redirectUrl);
        }
    }
}
