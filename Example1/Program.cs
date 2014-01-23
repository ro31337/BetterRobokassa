using RomanPushkin.BetterRobokassa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            string redirectUrl = Robokassa.GetRedirectUrl(1000, 1);
            Console.WriteLine(redirectUrl);
        }
    }
}
