namespace SanalMarket.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public IFormFile? Image { get; set; } 
    }
}
