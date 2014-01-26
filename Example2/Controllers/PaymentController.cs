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

    }
}
