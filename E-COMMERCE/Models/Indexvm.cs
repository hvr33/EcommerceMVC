namespace E_COMMERCE.Models
{
    public class Indexvm
    {
        public Indexvm()
        {

            Cetogeries = new List<Cetogery>();
            Products= new List<Product>();
            Reviews= new List<Review>();
            lastproduct = new List<Product>();
            Reviews2 = new List<Review2>();
            carts = new List<Cart>();
        }
        
        public List<Cetogery> Cetogeries { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> lastproduct { get; set; }
        public List<Review> Reviews { get; set; }
         public List<Review2> Reviews2 { get; set; }  
        public List<Cart> carts { get; set; }
        
    }
}
