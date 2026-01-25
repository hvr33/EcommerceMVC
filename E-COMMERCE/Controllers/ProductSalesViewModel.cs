namespace E_COMMERCE.Controllers
{
    internal class ProductSalesViewModel
    {
        public object ProductId { get; set; }
        public object ProductName { get; set; }
        public object ProductImage { get; set; }
        public object TotalSales { get; set; }
        public object TotalRevenue { get; set; }
        public string? CategoryName { get; internal set; }
    }
}