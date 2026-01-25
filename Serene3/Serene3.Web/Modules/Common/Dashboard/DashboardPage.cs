//using Serene3.Common.Repositories;

//namespace Serene3.Common.Pages
//{
//    [Route("Dashboard/[action]")]
//    public class DashboardPage : Controller
//    {
//        private readonly DashboardRepository dashboardRepository;

//        // أو: لو تفضل حقن ISqlConnections بدل Repository مباشرة (انظر الأسفل)
//        public DashboardPage(DashboardRepository dashboardRepository)
//        {
//            this.dashboardRepository = dashboardRepository;
//        }

//        [PageAuthorize, HttpGet, Route("~/")]
//        public ActionResult Index()
//        {
//            var model = dashboardRepository.GetDashboardData();
//            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using Serenity.Web;
using Serene3.Common.Repositories;

namespace Serene3.Common.Pages
{
    [Route("Dashboard/[action]")]
    public class DashboardPage : Controller
    {
        private readonly DashboardRepository _repo;

        public DashboardPage(DashboardRepository repo)
        {
            _repo = repo;
        }

        [PageAuthorize, HttpGet, Route("~/")]
        public ActionResult Index()
        {
            var model = _repo.GetDashboardData();
            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }

        // 🟢 API للـ Orders By Date
        [HttpGet]
        public JsonResult OrdersByDate(DateTime startDate, DateTime endDate)
        {
            var result = _repo.GetOrdersByDate(startDate, endDate);
            return Json(result);
        }

        // 🟢 API للـ Top Products
        [HttpGet]
        public JsonResult TopProducts()
        {
            var result = _repo.GetTopProducts();
            return Json(result);
        }

    }
}
