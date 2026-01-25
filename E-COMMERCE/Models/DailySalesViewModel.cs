namespace E_COMMERCE.Models
{
    internal class DailySalesViewModel
    {
        public object Date { get; set; }
        public int TotalOrders { get; set; }
        public object TotalRevenue { get; set; }
        public object AverageOrderValue { get; set; }
    }
}