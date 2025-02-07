using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransaction_App.Models
{
    public class BankTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "Please enter account number")]
        [Column(TypeName = "varchar(12)")]
        [DisplayName("Account Number")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only.")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Please enter benificiaery name")]
        [DisplayName("Benificary Name")]
        public string BenificiaryName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("SWIFT Number")]
        [Required(ErrorMessage = "Please enter SWIFT number")]
        [Column(TypeName = "varchar(11)")]
        [MaxLength(11, ErrorMessage ="Maximum 11 characters only")]
        public string SWIFTCode { get; set; }

        public int? Amount { get; set; }
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0: dd-MMM-yy}")]
        public DateTime TransactionDate { get; set; }

    }
}
