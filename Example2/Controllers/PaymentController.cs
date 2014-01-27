using RomanPushkin.BetterRobokassa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example2.Controllers
{
    public class PaymentController : Controller
    {
        public ActionResult Index()
        {
            int priceRub = 1000;
            int orderId = 1;

            // note: use GetRedirectUrl overloading to specify customer email

            string redirectUrl = Robokassa.GetRedirectUrl(priceRub, orderId);

            return Redirect(redirectUrl);
        }

        // So called "Result Url" in terms of Robokassa documentation.
        // This url is called by Robokassa robot.

        public ActionResult Confirm(RobokassaConfirmationRequest confirmationRequest)
        {
            try
            {
                if (confirmationRequest.IsQueryValid(RobokassaQueryType.ResultURL))
                {
                    // TODO:
                    // 1. verify your order Id and price here
                    // 2. mark your order as paid

                    return Content("OK");
                }
            }
            catch (Exception) { }
            return Content("ERR");
        }
    }
}
