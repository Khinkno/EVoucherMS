using System.ComponentModel.DataAnnotations;

namespace CodeTest.DTO
{
    public class EvoucherDTO
    {
        [Key]
        public int Id { get; set; }

       // public Guid PromoCode { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime ExpDate { get; set; }

        public String? Image { get; set; }

        public decimal Amount { get; set; }

        public int Qty { get; set; }


        public bool IsActive { get; set; }

        public int PaymentId { get; set; }
        [Required]
        public string Name { get; set; }

        public string PhNo { get; set; }

        public int MaxVouLimit { get; set; }
    }
}
