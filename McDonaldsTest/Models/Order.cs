using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace McDonaldsTest.Models
{
    public class Order
    {
        public int Id { get; set; }
        [NotNull]
        public string GUID { get; set; }
        [NotNull]
        public DateTime Received { get; set; }
        public DateTime? Finished { get; set; }
        public Enums.KitechenArea KitechenArea { get; set; }
        [NotNull]
        public string ClientIdentifier { get; set; }
    }
}
