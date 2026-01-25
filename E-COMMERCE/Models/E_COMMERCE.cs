// ViewModels/AdminViewModels.cs
using E_COMMERCE.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace E_COMMERCE.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalCategories { get; set; }
        public int TotalOrders { get; set; }
        public int TotalUsers { get; set; }
     
        // إصلاح اسم الخاصية
        public decimal RevenueToday { get; set; }
        public decimal RevenueThisMonth { get; set; }
        public int NewOrdersToday { get; set; }
        public decimal UserGrowthRate { get; set; }
        public decimal ProductGrowthRate { get; set; }
        public List<ProductSalesViewModel> TopSellingProducts { get; set; } = new();
        public List<RecentOrderViewModel> RecentOrders { get; set; } = new();
        public List<ActivityLogViewModel> RecentActivities { get; set; } = new();

        // إحصائيات إضافية
        public int PendingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public decimal AverageOrderValue { get; set; }
    }

    public class ProductSalesViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductImage { get; set; }
        public int TotalSales { get; set; }
        public decimal AveragePrice => TotalSales > 0 ? TotalRevenue / TotalSales : 0;
        public decimal TotalRevenue { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class RecentOrderViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string StatusText { get; set; } = string.Empty;
        public string StatusColor { get; set; } = string.Empty;
    }

    public class ActivityLogViewModel
    {
        public int Id { get; set; }
        public string ActivityType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? IpAddress { get; set; }
        public string LogLevel { get; set; } = string.Empty;
    }

    // باقي ViewModels...
    public class ProductCategoryStats
    {
        public string CategoryName { get; set; } = string.Empty;
        public int ProductCount { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class DailySalesViewModel
    {
        public DateTime Date { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageOrderValue { get; set; }
    }

    public class UserStatsViewModel
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int NewUsersThisMonth { get; set; }
        public decimal UserGrowthRate { get; set; }
    }

    public class SystemStatsViewModel
    {
        public long DatabaseSize { get; set; }
        public long ServerUptime { get; set; }
        public long TotalMemory { get; set; }
        public int ActiveConnections { get; set; }
        public int ErrorLogCount { get; set; }
    }

    public class SystemSettingsViewModel
    {
        [Display(Name = "اسم المتجر")]
        public string StoreName { get; set; } = "متجري الإلكتروني";

        [Display(Name = "بريد الدعم")]
        [EmailAddress]
        public string SupportEmail { get; set; } = "support@store.com";

        [Display(Name = "رقم الهاتف")]
        [Phone]
        public string PhoneNumber { get; set; } = "+966 500 000 000";

        [Display(Name = "عنوان المتجر")]
        public string StoreAddress { get; set; } = "الرياض، المملكة العربية السعودية";

        [Display(Name = "حالة الصيانة")]
        public bool MaintenanceMode { get; set; } = false;

        [Display(Name = "رسالة الصيانة")]
        public string MaintenanceMessage { get; set; } = "المتجر قيد الصيانة، نعتذر عن الإزعاج";

        [Display(Name = "تفعيل الدفع عند الاستلام")]
        public bool CashOnDeliveryEnabled { get; set; } = true;

        [Display(Name = "قيمة الحد الأدنى للطلب")]
        [Range(0, 10000)]
        public decimal MinimumOrderValue { get; set; } = 50;
    }

    public class ComprehensiveReportViewModel
    {
        public string ReportType { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public List<TopProductViewModel> TopProducts { get; set; } = new();
        public List<CustomerStatsViewModel> CustomerStats { get; set; } = new();
    }

    public class TopProductViewModel
    {
        public string ProductName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public decimal Revenue { get; set; }
    }

    public class CustomerStatsViewModel
    {
        public string CustomerName { get; set; } = string.Empty;
        public int OrderCount { get; set; }
        public decimal TotalSpent { get; set; }
    }
}