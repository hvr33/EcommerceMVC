using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(paymentsRow))]
public class paymentsPage : Controller
{
    [Route("com/payments")]
    public ActionResult Index()
    {
        return this.GridPage<paymentsRow>("@/com/payments/paymentsPage");
    }
}