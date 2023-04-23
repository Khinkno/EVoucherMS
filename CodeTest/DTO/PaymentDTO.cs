using System.ComponentModel.DataAnnotations;

namespace CodeTest.DTO
{
    public class PaymentDTO
    {
        [Key]
        public int PaymentId { get; set; }

        public string PaymentType { get; set; }

        public int DisPercent { get; set; }
    }
}
