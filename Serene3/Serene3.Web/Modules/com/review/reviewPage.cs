using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(reviewRow))]
public class reviewPage : Controller
{
    [Route("com/review")]
    public ActionResult Index()
    {
        return this.GridPage<reviewRow>("@/com/review/reviewPage");
    }
}