using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BetterRobokassa.Robokassa
{
    public enum RobokassaQueryType
    {
        ResultURL,
        SuccessURL
    }

    public class RobokassaConfirmationRequest
    {
        public string OutSum { get; set; }
        public int InvId { get; set; }
        public string SignatureValue { get; set; }

        // in Robokassa we have two types of back-queries:
        //
        // 1. ResultURL query
        //    Robokassa server tries to get this url
        //    Requires Pass2 (!!!)
        //
        // 2. SuccessUrl query
        //    Robokassa redirects user to this url
        //    Requires Pass1 (!!!)

        public bool IsQueryValid(RobokassaQueryType queryType)
        {
            string currentPassword =
                (queryType == RobokassaQueryType.ResultURL) ?
                RobokassaConfig.Pass2 :
                RobokassaConfig.Pass1;

            string str = string.Format("{0}:{1}:{2}",
                                    OutSum, InvId, currentPassword);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] calculatedSignature = md5.ComputeHash(Encoding.ASCII.GetBytes(str));

            StringBuilder sbSignature = new StringBuilder();

            foreach (byte b in calculatedSignature)
                sbSignature.AppendFormat("{0:x2}", b);

            return string.Equals(
                sbSignature.ToString(),
                SignatureValue,
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
