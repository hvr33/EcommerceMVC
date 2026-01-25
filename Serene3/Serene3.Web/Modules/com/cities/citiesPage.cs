using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(citiesRow))]
public class citiesPage : Controller
{
    [Route("com/cities")]
    public ActionResult Index()
    {
        return this.GridPage<citiesRow>("@/com/cities/citiesPage");
    }
}