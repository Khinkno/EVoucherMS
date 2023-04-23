using System.ComponentModel.DataAnnotations;

namespace CodeTest.DTO
{
    public class PurchaseDTO
    {
        [Key]
        // public int id { get; set; }
        [Required]
        public int EvoucherId { get; set; }
        [Required]
        public int PaymentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string PhNo { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }

        //public decimal DisAmount { get; set; }

        //public decimal Amount { get; set; }

       //public string Promocode { get; set; }

    }
}
