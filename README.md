BetterRobokassa
===============

Better support for [Robokassa.ru][1] for .Net

Why BetterRobokassa?
--------------------

Native Robokassa documentation and code for Microsoft .Net is bit confusing. The goal of this library is to provide easy to use code with plenty of working samples.

How to use
----------

Make sure you have correct keys set in your .config file (appSettings section):

    <add key="RobokassaLogin" value="your_merchant" />
    <add key="RobokassaPass1" value="password1" />
    <add key="RobokassaPass2" value="password2" />

Choose the mode you want to play with: test mode or production. To enable production mode make sure the line 40 in Robokassa/Robokassa.cs is uncommented and line 41 is commented out:

    return "https://auth.robokassa.ru/Merchant/Index.aspx?" +
    //return "http://test.robokassa.ru/Index.aspx?" +

To enable test mode, make sure that line 40 is commented, and line 41 is uncommented:

    //return "https://auth.robokassa.ru/Merchant/Index.aspx?" +
    return "http://test.robokassa.ru/Index.aspx?" +

Run sample application to generate redirect url:

    C:\Projects4\BetterRobokassa\BetterRobokassa\bin\Debug>BetterRobokassa.exe

Output (in case of test mode):

    http://test.robokassa.ru/Index.aspx?MrchLogin=your_merchant&OutSum=1000.00&InvId=1&Desc=desc&SignatureValue=00a09f4eab03374b536539a5ee57ea2a

Output is result url you may want to use in your application to redirect your customer. Sample code for ASP.NET MVC controller:

    public class PaymentController : Controller
    {
        public ActionResult Index()
        {
            // ...
            // note: customerEmail is optional
            string redirectUrl = Robokassa.GetRedirectUrl(priceRub, orderId, customerEmail);
            return Redirect(redirectUrl);
        }
    }

Things you need to know
-----------------------

Keep in mind that there are two passwords for Robokassa:

 - First password is used in so called *result url* (personally, I call it confirmation url)
 - Second password is used in so called *success url*

What's the main difference between those two?

First one (*result* or *confirmation url*) is used by Robokassa's robot. The robot uses the first password (`RobokassaPass1` in config file).

Second (*success url*) is used to redirect the customer back to your website. Confirmation hashcode is generated using the second password in this case (`RobokassaPass2` in config file).

Don't miss this point, and use correct `RobokassaQueryType` when verifying incoming requests. **Most of your bugs are probably happen if you're not using these types properly**.

How to use BetterRobokassa with ASP.NET MVC
-------------------------------------------

Coming soon.

  [1]: http://robokassa.ru
