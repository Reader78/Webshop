namespace Services.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Product> products { get; set; } = new ();
        public Customer? customer { get; set; }


    }
}
