namespace api.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = "";

        public Guid Id { get; set; }

        public int Price { get; set; } = 0;
    }
}
