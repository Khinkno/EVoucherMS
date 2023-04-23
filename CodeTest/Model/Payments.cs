using System.ComponentModel.DataAnnotations;

namespace CodeTest.Model
{
    public class Payments
    {
        [ConcurrencyCheck]
        [Key]
        public int PaymentId { get; set; }

        public string PaymentType { get; set; }

        public int DisPercent  { get; set; }
    }
}
