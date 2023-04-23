using System.ComponentModel.DataAnnotations;

namespace CodeTest.Model
{
    public class Items
    {
        [ConcurrencyCheck]
        [Key]
        public int Id { get; set; }

        public int PurchaseId { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }

        public decimal Amount { get; set; }
    }
}
