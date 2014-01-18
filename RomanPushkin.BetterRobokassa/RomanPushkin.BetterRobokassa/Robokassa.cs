using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RomanPushkin.BetterRobokassa
{
    public static class Robokassa
    {
        public static string GetRedirectUrl(int priceRub, int orderId, string email = "")
        {
            // ugly code, legacy from Robokassa website

            // your registration data
            string sMrchLogin = RobokassaConfig.Login;
            string sMrchPass1 = RobokassaConfig.Pass1;
            // order properties
            decimal nOutSum = priceRub;
            int nInvId = orderId;
            string sDesc = "desc";

            string sOutSum = nOutSum.ToString("0.00", CultureInfo.InvariantCulture);
            string sCrcBase = string.Format("{0}:{1}:{2}:{3}",
                                             sMrchLogin, sOutSum, nInvId, sMrchPass1);

            // build CRC value
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bSignature = md5.ComputeHash(Encoding.ASCII.GetBytes(sCrcBase));

            StringBuilder sbSignature = new StringBuilder();
            foreach (byte b in bSignature)
                sbSignature.AppendFormat("{0:x2}", b);

            string sCrc = sbSignature.ToString();

            //return "https://auth.robokassa.ru/Merchant/Index.aspx?" +
            return "http://test.robokassa.ru/Index.aspx?" +
                                                "MrchLogin=" + sMrchLogin +
                                                "&OutSum=" + sOutSum +
                                                "&InvId=" + nInvId +
                                                "&Desc=" + sDesc +
                                                "&SignatureValue=" + sCrc +
                                                (String.IsNullOrEmpty(email) ? "" : "&Email=" + email);
        }
    }
}
