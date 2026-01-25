using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(review2Row))]
public class review2Page : Controller
{
    [Route("com/review2")]
    public ActionResult Index()
    {
        return this.GridPage<review2Row>("@/com/review2/review2Page");
    }
}