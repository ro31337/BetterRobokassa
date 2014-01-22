using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPushkin.BetterRobokassa
{
    public static class RobokassaConfig
    {
        public static string Login
        {
            get
            {
                return ConfigurationManager.AppSettings["RobokassaLogin"];
            }
        }

        public static string Pass1
        {
            get
            {
                return ConfigurationManager.AppSettings["RobokassaPass1"];
            }
        }

        public static string Pass2
        {
            get
            {
                return ConfigurationManager.AppSettings["RobokassaPass2"];
            }
        }

        public static RobokassaMode Mode
        {
            get
            {
                string mode = ConfigurationManager.AppSettings["RobokassaMode"];
                switch(mode.ToLower())
                {
                    case "test":
                        return RobokassaMode.Test;
                    case "production":
                        return RobokassaMode.Production;
                    default:
                        throw new NotSupportedException("Mode is not supported, available modes: test or production");
                }
            }
        }

        public static void AssertConfigurationIsValid()
        {
            if (String.IsNullOrWhiteSpace(Login))
                throw new Exception("Robokassa configuration: login is required");

            if (String.IsNullOrWhiteSpace(Pass1))
                throw new Exception("Robokassa configuration: first password is required");

            if (String.IsNullOrWhiteSpace(Pass2))
                throw new Exception("Robokassa configuration: second password is required");

            var mode = Mode;
        }
    }
}
