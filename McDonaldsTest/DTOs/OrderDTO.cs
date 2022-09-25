using McDonaldsTest.Models;

namespace McDonaldsTest.DTOs
{
    public class OrderDTO
    {
        public string? OrderDetails { get; set; }
        public string? ClientIdentifier { get; set; }
        public Enums.KitchenArea KitchenArea { get; set; }
    }
}
