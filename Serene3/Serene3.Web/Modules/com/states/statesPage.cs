using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(statesRow))]
public class statesPage : Controller
{
    [Route("com/states")]
    public ActionResult Index()
    {
        return this.GridPage<statesRow>("@/com/states/statesPage");
    }
}