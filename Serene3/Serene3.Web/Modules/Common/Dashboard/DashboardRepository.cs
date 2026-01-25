//using Microsoft.Data.SqlClient;
//using Serene3.com;            // علشان productRow موجود هنا
//using Serene3.Common;        // علشان DashboardPageModel
//using Serenity.Data;
//using System;
//using System.Linq;

//namespace Serene3.Common.Repositories
//{
//    public class DashboardRepository
//    {
//        private readonly ISqlConnections sqlConnections;

//        public DashboardRepository(ISqlConnections sqlConnections)
//        {
//            this.sqlConnections = sqlConnections;
//        }

//        public DashboardPageModel GetDashboardData()
//        {
//            using (var connection = sqlConnections.NewByKey("cetgeroycontrol"))
//            {
//                // عدد المنتجات من جدول productRow
//                var productCount = connection.Count<productRow>();

//                // الافتراض: لو معندكش CustomerRow أو OrderRow هنستخدم استعلامات SQL بسيطة (محايدة)
//                int customerCount = 0;
//                int openOrders = 0;
//                int closedOrders = 0;

//                try
//                {
//                    // حاول تجيب عدد العملاء من جدول Customers (لو موجود)
//                    customerCount = connection.Query<int>("SELECT COUNT(1) FROM  [AspNetUsers]").FirstOrDefault();
//                }
//                catch
//                {
//                    customerCount = 0;
//                }

//                try
//                {
//                    // حاول تجيب الأوامر المفتوحة/المقفولة من جدول Orders (لو موجود وبه عمود Status)
//                    openOrders = connection.Query<int>("SELECT COUNT(1) FROM Orders WHERE Status = @s", new { s = "Open" }).FirstOrDefault();
//                    closedOrders = connection.Query<int>("SELECT COUNT(1) FROM Orders WHERE Status = @s", new { s = "Closed" }).FirstOrDefault();
//                }
//                catch
//                {
//                    openOrders = 0;
//                    closedOrders = 0;
//                }

//                var totalOrders = openOrders + closedOrders;
//                var closedPercent = totalOrders > 0 ? (int)(closedOrders * 100.0 / totalOrders) : 0;

//                return new DashboardPageModel
//                {
//                    ProductCount = productCount,
//                    CustomerCount = customerCount,
//                    OpenOrders = openOrders,
//                    ClosedOrderPercent = closedPercent
//                };
//            }
//        }
//        public JsonResult GetOrdersByDate(DateTime startDate, DateTime endDate)
//        {
//            using (var connection = sqlConnections.NewByKey("cetgeroycontrol"))
//            {
//                // عدد الأوردرات لكل يوم
//                var dailyOrders = connection.Query(@"
//                SELECT 
//                    CAST(Entitydata AS DATE) AS OrderDate, 
//                    COUNT(*) AS CountPerDay
//                FROM orderdetials
//                WHERE entitydata >= @startDate AND Entitydata <= @endDate
//                GROUP BY CAST(entitydata AS DATE)
//                ORDER BY CAST(entitydata AS DATE)
//            ", new { startDate, endDate });

//                var labels = new List<string>();
//                var data = new List<int>();

//                foreach (var row in dailyOrders)
//                {
//                    labels.Add(((DateTime)row.OrderDate).ToString("yyyy-MM-dd"));
//                    data.Add((int)row.CountPerDay);
//                }

//                // أكثر المنتجات مبيعًا
//                var topProducts = connection.Query(@"
//                SELECT TOP 5 p.name, SUM(od.quantity) as SoldQty
//                FROM [orderdetials] od
//                INNER JOIN [product] p ON od.ProductId = p.Id
//                WHERE od.entitydata >= @startDate AND od.entitydata<= @endDate
//                GROUP BY p.name
//                ORDER BY SoldQty DESC
//            ", new { startDate, endDate });

//                var topLabels = new List<string>();
//                var topData = new List<int>();
//                foreach (var row in topProducts)
//                {
//                    topLabels.Add(row.name);
//                    topData.Add((int)row.SoldQty);
//                }

//                return JSON(new { labels, data, topLabels, topData });
//            }
//        }
//        [HttpPost]
//        public JsonResult GetTopProducts()
//        {
//            using (var connection = sqlConnections.NewByKey("cetgeroycontrol");
//            {
//                // نجمع عدد كل منتج مباع
//                var data = sqlConnections.Query(@"
//           SELECT TOP 5 Productid, COUNT(*) AS TotalSold
// FROM orderdetials
// GROUP BY ProductID
// ORDER BY TotalSold DESC
//        ").ToList();

//                // نحضر labels و data للشارت
//                var labels = data.Select(x => x.ProductID.ToString()).ToArray();
//                var values = data.Select(x => (int)x.TotalSold).ToArray();

//                return Json(new { topLabels = labels, topData = values });
//            }
//        }
//    }
//}
using Microsoft.Data.SqlClient;
using Serene3.com;            // علشان productRow موجود هنا
using Serene3.Common;         // علشان DashboardPageModel
using Serenity.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Serene3.Common.Repositories
{
    public class DashboardRepository
    {
        private readonly ISqlConnections sqlConnections;

        public DashboardRepository(ISqlConnections sqlConnections)
        {
            this.sqlConnections = sqlConnections;
        }

        public DashboardPageModel GetDashboardData()
        {
            using (var connection = sqlConnections.NewByKey("cetgeroycontrol"))
            {
                // عدد المنتجات
                var productCount = connection.Count<productRow>();

                int customerCount = 0;
                int openOrders = 0;
                int closedOrders = 0;

                try
                {
                    // عدد العملاء
                    customerCount = connection.Query<int>(
                        "SELECT COUNT(1) FROM AspNetUsers"
                    ).FirstOrDefault();
                }
                catch
                {
                    customerCount = 0;
                }

                try
                {
                    // الأوامر المفتوحة والمقفولة
                    openOrders = connection.Query<int>(
                        "SELECT COUNT(1) FROM Orders WHERE Status = @s",
                        new { s = "Open" }).FirstOrDefault();

                    closedOrders = connection.Query<int>(
                        "SELECT COUNT(1) FROM Orders WHERE Status = @s",
                        new { s = "Closed" }).FirstOrDefault();
                }
                catch
                {
                    openOrders = 0;
                    closedOrders = 0;
                }

                var totalOrders = openOrders + closedOrders;
                var closedPercent = totalOrders > 0
                    ? (int)(closedOrders * 100.0 / totalOrders)
                    : 0;

                return new DashboardPageModel
                {
                    ProductCount = productCount,
                    CustomerCount = customerCount,
                    OpenOrders = openOrders,
                    ClosedOrderPercent = closedPercent
                };
            }
        }

        // 🟢 دي هترجع object عادي، الكنترولر هو اللي يحوله Json
        public object GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            using (var connection = sqlConnections.NewByKey("cetgeroycontrol"))
            {
                var dailyOrders = connection.Query(@"
                    SELECT 
                        CAST(Entitydata AS DATE) AS OrderDate, 
                        COUNT(*) AS CountPerDay
                    FROM orderdetials
                    WHERE entitydata >= @startDate AND Entitydata <= @endDate
                    GROUP BY CAST(entitydata AS DATE)
                    ORDER BY CAST(entitydata AS DATE)",
                    new { startDate, endDate });

                var labels = new List<string>();
                var data = new List<int>();

                foreach (var row in dailyOrders)
                {
                    labels.Add(((DateTime)row.OrderDate).ToString("yyyy-MM-dd"));
                    data.Add((int)row.CountPerDay);
                }

                var topProducts = connection.Query(@"
                    SELECT TOP 5 p.name, SUM(od.quantity) as SoldQty
                    FROM orderdetials od
                    INNER JOIN product p ON od.ProductId = p.Id
                    WHERE od.entitydata >= @startDate AND od.entitydata <= @endDate
                    GROUP BY p.name
                    ORDER BY SoldQty DESC",
                    new { startDate, endDate });

                var topLabels = new List<string>();
                var topData = new List<int>();

                foreach (var row in topProducts)
                {
                    topLabels.Add((string)row.name);
                    topData.Add((int)row.SoldQty);
                }

                return new { labels, data, topLabels, topData };
            }
        }

        // 🟢 top products
        public object GetTopProducts()
        {
            using (var connection = sqlConnections.NewByKey("cetgeroycontrol"))
            {
                var data = connection.Query(@"
                    SELECT TOP 5 ProductId, COUNT(*) AS TotalSold
                    FROM orderdetials
                    GROUP BY ProductId
                    ORDER BY TotalSold DESC
                ").ToList();

                var labels = data.Select(x => x.ProductId.ToString()).ToArray();
                var values = data.Select(x => (int)x.TotalSold).ToArray();

                return new { topLabels = labels, topData = values };
            }
        }
    }
}
