using McDonaldsTest.Models;
using System.ComponentModel.DataAnnotations;

namespace McDonaldsTest.DTOs
{
    public class OrderDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string? OrderDetails { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string? ClientIdentifier { get; set; }
        [Required]
        public Enums.KitchenArea KitchenArea { get; set; }
    }
}
