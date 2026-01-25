namespace E_COMMERCE.Controllers
{
    internal class RecentOrderViewModel
    {
        public object OrderId { get; set; }
        public object OrderNumber { get; set; }
        public object UserName { get; set; }
        public object TotalAmount { get; set; }
        public object Status { get; set; }
        public object OrderDate { get; set; }
        public object StatusText { get; set; }
        public string StatusColor { get; internal set; }
    }
}