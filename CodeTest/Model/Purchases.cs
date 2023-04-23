using System.ComponentModel.DataAnnotations;

namespace CodeTest.Model
{
    public class Purchases
    {
        [ConcurrencyCheck]
        [Key]
        public int Id { get; set; }
        public int EvoucherId { get; set; }

        public int PaymentId { get; set; }
        public string Name { get; set; }

        public string PhNo { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal DisAmount { get; set; }

        public decimal Amount { get; set; }

        public string Promocode { get; set; }
    }
}
