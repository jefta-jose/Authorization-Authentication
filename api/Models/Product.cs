namespace api.Models
{
    public class Product
    {
        public string Name { get; set; } = "";

        public Guid Id { get; set; }

        public int Price { get; set; } = 0;
    }
}
