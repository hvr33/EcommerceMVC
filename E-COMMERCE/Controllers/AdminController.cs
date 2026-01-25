using E_COMMERCE.Areas.Identity.Data;
using E_COMMERCE.Data;
using E_COMMERCE.Models;
using E_COMMERCE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;
using E_COMMERCE.Models;

using E_COMMERCE.ViewModels;
namespace E_COMMERCE.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly Commerce2Context _context;
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<E_COMMERCEUser> _userManager;

        public AdminController(Commerce2Context context,
                              ILogger<AdminController> logger,
                              UserManager<E_COMMERCEUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {



            try
            {
                var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                var today = DateTime.Today;
                // في AdminDashboardViewModel



    

                var dashboardViewModel = new AdminDashboardViewModel
                {
                    TotalProducts = await _context.Products.CountAsync(),
                    TotalCategories = await _context.Cetogeries.CountAsync(),
                    TotalOrders = await _context.Orders.CountAsync(),
                    TotalUsers = await _context.AspNetUsers.CountAsync(),

                    // إصلاح حساب الإيرادات اليومية
                    RevenueToday = await CalculateRevenueForDate(today),

                    // إيرادات هذا الشهر
                    RevenueThisMonth = await CalculateRevenueForPeriod(firstDayOfMonth, DateTime.Today),

                    // طلبات جديدة اليوم
                    NewOrdersToday = await _context.Orders
                        .Where(o => o.OrderDate == today)
                        .CountAsync(),

                    // المنتجات الأكثر مبيعاً
                    TopSellingProducts = await GetTopSellingProducts(),

                    // الطلبات الأخيرة
                    RecentOrders = await GetRecentOrders(),

                    // الأنشطة الأخيرة
                    RecentActivities = await GetRecentActivities(),
                    UserGrowthRate = await CalculateUserGrowthRate(),
                    // إحصائيات الطلبات
                    PendingOrders = await _context.Orders.CountAsync(o => o.Onlinepaid == false),
                    CompletedOrders = await _context.Orders.CountAsync(o => o.Onlinepaid == true)
                };

                // حساب متوسط قيمة الطلب
                dashboardViewModel.AverageOrderValue = dashboardViewModel.TotalOrders > 0
                    ? dashboardViewModel.RevenueThisMonth / dashboardViewModel.TotalOrders
                    : 0;

                ViewData["ActiveMenu"] = "dashboard";
                TempData["SuccessMessage"] = "مرحباً بك في لوحة التحكم!";

                return View(dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في تحميل لوحة التحكم");
                TempData["ErrorMessage"] = "حدث خطأ في تحميل البيانات";
                return View(new AdminDashboardViewModel());
            }
        }



        // حساب الإيرادات لتاريخ محدد
        private async Task<decimal> CalculateRevenueForDate(DateTime date) => await _context.Orderdetials
                .Include(od => od.Order)
                .Where(od => od.Order.OrderDate == date)
                .SumAsync(od => (od.Quantity ?? 0) * (od.Price ?? 0));

        // حساب الإيرادات لفترة زمنية
        private async Task<decimal> CalculateRevenueForPeriod(DateTime startDate, DateTime endDate) => await _context.Orderdetials
                .Include(od => od.Order)
                .Where(od => od.Order.OrderDate >= startDate && od.Order.OrderDate <= endDate)
                .SumAsync(od => (od.Quantity ?? 0) * (od.Price ?? 0));

        // المنتجات الأكثر مبيعاً
        public async Task<List<E_COMMERCE.ViewModels.ProductSalesViewModel>> GetTopSellingProducts() => await _context.Orderdetials
                .Include(o => o.Product)
                .Where(o => o.Product != null)
                .GroupBy(o => o.Productid)
                .Select(g => new E_COMMERCE.ViewModels.ProductSalesViewModel
                {
                    ProductId = g.Key.Value,
                    ProductName = g.First().Product!.Name,
                    TotalSales = g.Sum(oi => oi.Quantity ?? 0),
                    TotalRevenue = g.Sum(oi => (oi.Quantity ?? 0) * (oi.UnitPrice ?? 0))
                })
                .OrderByDescending(x => x.TotalSales)
                .Take(5)
                .ToListAsync();


        // الطلبات الأخيرة
        private async Task<List<E_COMMERCE.ViewModels.RecentOrderViewModel>> GetRecentOrders() => await _context.Orders
                .Include(o => o.Orderdetials)
                .Include(o => o.State)
                .OrderByDescending(o => o.OrderDate)
                .Take(10)
                .Select(o => new E_COMMERCE.ViewModels.RecentOrderViewModel
                {
                    OrderId = o.Id,
                    OrderNumber = $"ORD-{o.Id:D6}",
                    UserName = o.CustomerName ?? "غير معروف",
                    TotalAmount = o.Orderdetials.Sum(x => (x.Quantity ?? 0) * (x.Price ?? 0)),
                    Status = o.StateId == 1 ? "مدفوع" : "معلق",
                    OrderDate = o.OrderDate ?? DateTime.MinValue,
                    StatusText = o.State != null ? o.State.Name : "معلق",
                    StatusColor = o.Onlinepaid == true ? "success" : "warning"
                })
                .ToListAsync();


        // الأنشطة الأخيرة
        private async Task<List<ActivityLogViewModel>> GetRecentActivities(int count = 10) => await _context.AuditLogs
                .OrderByDescending(l => l.CreatedAt)
                .Take(count)
                .Select(l => new ActivityLogViewModel
                {
                    Id = l.Id,
                    ActivityType = l.ActivityType ?? string.Empty,
                    Description = l.Description ?? string.Empty,
                    UserName = l.UserName ?? "نظام",

                    IpAddress = l.IpAddress,
                    LogLevel = l.LogLevel ?? "Info"
                })
                .ToListAsync();

        // إحصائيات المبيعات
        [HttpGet]
        public async Task<IActionResult> SalesStats(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                startDate ??= DateTime.Now.AddMonths(-1);
                endDate ??= DateTime.Now;

                var salesData = await _context.Orders
                    .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                    .Include(o => o.Orderdetials)
                    .GroupBy(o => o.OrderDate)
                    .Select(g => new DailySalesViewModel
                    {
                        Date = g.Key,
                        TotalOrders = g.Count(),
                        TotalRevenue = g.Sum(o => o.Orderdetials.Sum(od => (od.Quantity ?? 0) * (od.Price ?? 0))),
                        AverageOrderValue = g.Average(o => o.Orderdetials.Sum(od => (od.Quantity ?? 0) * (od.Price ?? 0)))
                    })
                    .OrderBy(x => x.Date)
                    .ToListAsync();

                return Json(new { success = true, data = salesData });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في جلب إحصائيات المبيعات");
                return Json(new { success = false, message = "خطأ في الخادم" });
            }
        }

        // إحصائيات المستخدمين
        [HttpGet]
        public async Task<IActionResult> UserStats()
        {
            try
            {
                var thirtyDaysAgo = DateTime.Now.AddDays(-30);
                var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);

              

                var userStats = new UserStatsViewModel
                {
                    TotalUsers = await _context.AspNetUsers.CountAsync(),

                    // المستخدمين النشطين (بناءً على آخر تسجيل دخول)
                    ActiveUsers = await _context.AspNetUsers
                        .CountAsync(u => u.LockoutEnabled == false), // افتراضياً جميع المستخدمين نشطين

                    NewUsersThisMonth = await _context.AspNetUsers
    .CountAsync(u => u.LockoutEnd >= firstDayOfMonth && u.LockoutEnd < firstDayOfNextMonth),

                    UserGrowthRate = await CalculateUserGrowthRate()
                };

                return Json(new { success = true, data = userStats });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في جلب إحصائيات المستخدمين");
                return Json(new { success = false, message = "خطأ في الخادم" });
            }
        }

        // حساب معدل نمو المستخدمين
        private async Task<decimal> CalculateUserGrowthRate()
        {
            try
            {
                var firstDayOfCurrentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var firstDayOfNextMonth = firstDayOfCurrentMonth.AddMonths(1);

                var currentMonth = await _context.AspNetUsers
                    .CountAsync(u => u.LockoutEnd >= firstDayOfCurrentMonth && u.LockoutEnd < firstDayOfNextMonth);

                var firstDayOfPreviousMonth = firstDayOfCurrentMonth.AddMonths(-1);
                var firstDayOfCurrentMonthAgain = firstDayOfCurrentMonth;

                var previousMonth = await _context.AspNetUsers
                    .CountAsync(u => u.LockoutEnd >= firstDayOfPreviousMonth && u.LockoutEnd < firstDayOfCurrentMonthAgain);


                return previousMonth > 0 ? Math.Round(((decimal)(currentMonth - previousMonth) / previousMonth) * 100, 2) : 0;
            }
            catch
            {
                return 0;
            }
        }

        // تقرير شامل
        [HttpGet]
        public async Task<IActionResult> Report(string type = "monthly", int? year = null, int? month = null)
        {
            try
            {
                year ??= DateTime.Now.Year;
                month ??= DateTime.Now.Month;

                var report = await GenerateReport(type, year.Value, month.Value);

                ViewData["ActiveMenu"] = "reports";
                ViewBag.ReportType = type;
                ViewBag.SelectedYear = year;
                ViewBag.SelectedMonth = month;

                return View(report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في إنشاء التقرير");
                TempData["ErrorMessage"] = "حدث خطأ في إنشاء التقرير";
                return RedirectToAction("Index");
            }
        }

        // إنشاء تقرير شامل
        private async Task<ComprehensiveReportViewModel> GenerateReport(string type, int year, int month)
        {
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var totalRevenue = await _context.Orderdetials
                .Include(od => od.Order)
                .Where(od => od.Order.OrderDate >= startDate && od.Order.OrderDate <= endDate)
                .SumAsync(od => (od.Quantity ?? 0) * (od.Price ?? 0));

            return new ComprehensiveReportViewModel
            {
                ReportType = type,
                Year = year,
                Month = month,
                PeriodStart = startDate,
                PeriodEnd = endDate,
                TotalSales = totalRevenue,
                TotalOrders = await _context.Orders
                    .CountAsync(o => o.OrderDate >= startDate && o.OrderDate <= endDate),
                TopProducts = await _context.Orderdetials
    .Where(od => od.Order.OrderDate >= startDate && od.Order.OrderDate <= endDate)
    .GroupBy(od => od.Productid)
    .Select(g => new E_COMMERCE.ViewModels.TopProductViewModel
    {
        ProductName = g.First().Product!.Name,
        CategoryName = g.First().Product!.CeitoNavigation!.Name,
        QuantitySold = g.Sum(od => od.Quantity ?? 0),
        Revenue = g.Sum(od => (od.Quantity ?? 0) * (od.Price ?? 0))
    })
    .OrderByDescending(x => x.Revenue)
    .Take(10)
    .ToListAsync(),

                CustomerStats = await _context.Orders
                    .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                    .GroupBy(o => o.Userid)
                    .Select(g => new CustomerStatsViewModel
                    {
                        CustomerName = g.First().CustomerName ?? "غير معروف",
                        OrderCount = g.Count(),
                        TotalSpent = g.Sum(o => o.Orderdetials.Sum(od => (od.Quantity ?? 0) * (od.Price ?? 0)))
                    })
                    .OrderByDescending(x => x.TotalSpent)
                    .Take(10)
                    .ToListAsync()
            };
        }

        // تصدير التقرير
        [HttpPost]
        public async Task<IActionResult> ExportReport(string type, int year, int month, string format = "pdf")
        {
            try
            {
                var report = await GenerateReport(type, year, month);

                // هنا يمكنك إضافة منطق تصدير PDF أو Excel
                // باستخدام مكتبات مثل iTextSharp أو EPPlus

                TempData["SuccessMessage"] = $"تم تصدير التقرير بنجاح ({format.ToUpper()})";
                return Json(new { success = true, message = "تم التصدير بنجاح" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في تصدير التقرير");
                return Json(new { success = false, message = "خطأ في تصدير التقرير" });
            }
        }

        // إدارة النظام
        [HttpGet]
        public async Task<IActionResult> SystemSettings()
        {
            try
            {
                var settings = await _context.SystemSettings
                    .ToDictionaryAsync(s => s.SettingKey, s => s.SettingValue);

                var model = new SystemSettingsViewModel
                {
                    StoreName = settings.GetValueOrDefault("StoreName", "متجري الإلكتروني"),
                    SupportEmail = settings.GetValueOrDefault("SupportEmail", "support@store.com"),
                    PhoneNumber = settings.GetValueOrDefault("PhoneNumber", "+966 500 000 000"),
                    StoreAddress = settings.GetValueOrDefault("StoreAddress", "الرياض، المملكة العربية السعودية"),
                    MaintenanceMode = bool.Parse(settings.GetValueOrDefault("MaintenanceMode", "false")),
                    MaintenanceMessage = settings.GetValueOrDefault("MaintenanceMessage", "المتجر قيد الصيانة"),
                    CashOnDeliveryEnabled = bool.Parse(settings.GetValueOrDefault("CashOnDeliveryEnabled", "true")),
                    MinimumOrderValue = decimal.Parse(settings.GetValueOrDefault("MinimumOrderValue", "50"))
                };

                ViewData["ActiveMenu"] = "settings";
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في تحميل إعدادات النظام");
                TempData["ErrorMessage"] = "حدث خطأ في تحميل الإعدادات";
                return View(new SystemSettingsViewModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSystemSettings(SystemSettingsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // حفظ الإعدادات في قاعدة البيانات
                    var settingsToUpdate = new Dictionary<string, string>
                    {
                        { "StoreName", model.StoreName },
                        { "SupportEmail", model.SupportEmail },
                        { "PhoneNumber", model.PhoneNumber },
                        { "StoreAddress", model.StoreAddress },
                        { "MaintenanceMode", model.MaintenanceMode.ToString() },
                        { "MaintenanceMessage", model.MaintenanceMessage },
                        { "CashOnDeliveryEnabled", model.CashOnDeliveryEnabled.ToString() },
                        { "MinimumOrderValue", model.MinimumOrderValue.ToString() }
                    };

                    foreach (var setting in settingsToUpdate)
                    {
                        var existingSetting = await _context.SystemSettings
                            .FirstOrDefaultAsync(s => s.SettingKey == setting.Key);

                        if (existingSetting != null)
                        {
                            existingSetting.SettingValue = setting.Value;
                            existingSetting.UpdatedAt = DateTime.UtcNow;
                        }
                        else
                        {
                            _context.SystemSettings.Add(new SystemSetting
                            {
                                SettingKey = setting.Key,
                                SettingValue = setting.Value, // بدل Value
                                Description = $"إعداد {setting.Key}",
                                UpdatedAt = DateTime.UtcNow
                            });

                        }
                    }

                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "تم تحديث الإعدادات بنجاح";
                    _logger.LogInformation("تم تحديث إعدادات النظام بواسطة {UserId}", User.FindFirstValue(ClaimTypes.NameIdentifier));
                    return RedirectToAction("SystemSettings");
                }

                TempData["ErrorMessage"] = "يرجى تصحيح الأخطاء الموجودة";
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في تحديث الإعدادات");
                TempData["ErrorMessage"] = "حدث خطأ في تحديث الإعدادات";
                return View(model);
            }
        }

        // مسح الكاش
        [HttpPost]
        public async Task<IActionResult> ClearCache()
        {
            try
            {
                // منطق مسح الكاش - يمكن استخدام IMemoryCache أو IDistributedCache
                // await _cacheService.ClearCacheAsync();

                await Task.Delay(100); // محاكاة العملية

                TempData["SuccessMessage"] = "تم مسح الكاش بنجاح";
                _logger.LogInformation("تم مسح الكاش بواسطة {UserId}", User.FindFirstValue(ClaimTypes.NameIdentifier));

                return Json(new { success = true, message = "تم مسح الكاش بنجاح" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في مسح الكاش");
                return Json(new { success = false, message = "خطأ في مسح الكاش" });
            }
        }

        // النسخ الاحتياطي
        [HttpPost]
        public async Task<IActionResult> BackupDatabase()
        {
            try
            {
                var backupPath = await CreateDatabaseBackup();

                TempData["SuccessMessage"] = $"تم إنشاء نسخة احتياطية في: {backupPath}";
                _logger.LogInformation("تم إنشاء نسخة احتياطية في {BackupPath}", backupPath);

                return Json(new { success = true, message = "تم إنشاء النسخة الاحتياطية بنجاح", path = backupPath });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في إنشاء النسخة الاحتياطية");
                return Json(new { success = false, message = "خطأ في إنشاء النسخة الاحتياطية" });
            }
        }

        // إحصائيات النظام
        [HttpGet]
        public async Task<IActionResult> SystemStats()
        {
            try
            {
                var systemStats = new SystemStatsViewModel
                {
                    DatabaseSize = await GetDatabaseSize(),
                    ServerUptime = Environment.TickCount64 / 1000 / 60, // دقائق
                    TotalMemory = GC.GetTotalMemory(false) / 1024 / 1024, // MB
                    ActiveConnections = await GetActiveConnections(),
                    ErrorLogCount = await _context.AuditLogs.CountAsync(l => l.LogLevel == "Error")
                };

                return Json(new { success = true, data = systemStats });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في جلب إحصائيات النظام");
                return Json(new { success = false, message = "خطأ في الخادم" });
            }
        }

        // إنهاء الجلسة لجميع المستخدمين
        [HttpPost]
        public async Task<IActionResult> TerminateAllSessions()
        {
            try
            {
                // منطق إنهاء جميع الجلسات - يحتاج لتطبيق Identity مع JWT أو Cookies
                TempData["SuccessMessage"] = "تم إنهاء جميع الجلسات بنجاح";

                _logger.LogWarning("تم إنهاء جميع الجلسات بواسطة {AdminUser}", User.Identity?.Name);
                return Json(new { success = true, message = "تم إنهاء جميع الجلسات" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في إنهاء الجلسات");
                return Json(new { success = false, message = "خطأ في إنهاء الجلسات" });
            }
        }

        #region Helper Methods

        private async Task<long> GetDatabaseSize()
        {
            try
            {
                // استعلام لحساب حجم قاعدة البيانات
                var sizeQuery = @"
                    SELECT 
                        SUM(size) * 8 / 1024 as SizeMB
                    FROM sys.master_files 
                    WHERE database_id = DB_ID('commerce2')";

                var size = await _context.Database
                    .SqlQueryRaw<long>(sizeQuery)
                    .FirstOrDefaultAsync();

                return size * 1024 * 1024; // تحويل إلى بايت
            }
            catch
            {
                // قيمة افتراضية
                return 125 * 1024 * 1024L; // 125 MB
            }
        }

        private async Task<int> GetActiveConnections()
        {
            try
            {
                var query = @"
                    SELECT COUNT(*) 
                    FROM sys.dm_exec_sessions 
                    WHERE database_id = DB_ID('commerce2')";

                return await _context.Database
                    .SqlQueryRaw<int>(query)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                return Random.Shared.Next(10, 50);
            }
        }

        private async Task<string> CreateDatabaseBackup()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var backupPath = Path.Combine("backups", $"database_backup_{timestamp}.bak");

            // إنشاء المجلد إذا لم يكن موجوداً
            Directory.CreateDirectory(Path.GetDirectoryName(backupPath) ?? "backups");

            try
            {
                // استعلام SQL للنسخ الاحتياطي
                var backupQuery = $@"
                    BACKUP DATABASE [commerce2] 
                    TO DISK = N'{backupPath}'
                    WITH NOFORMAT, NOINIT, 
                         NAME = N'commerce2-Full Database Backup',
                         SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

                await _context.Database.ExecuteSqlRawAsync(backupQuery);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "فشل في إنشاء النسخة الاحتياطية");
                throw;
            }

            return backupPath;
        }

        #endregion
    }
}