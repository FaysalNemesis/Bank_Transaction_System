using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransaction_App.Models
{
    public class BankTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string BenificiaryName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string BankName { get; set; }

        [Column(TypeName = "varchar(11)")]
        public string SWIFTCode { get; set; }

        public int? Amount { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
