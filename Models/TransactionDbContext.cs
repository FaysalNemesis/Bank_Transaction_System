using Microsoft.EntityFrameworkCore;

namespace BankTransaction_App.Models
{
    public class TransactionDbContext: DbContext
    {
        public TransactionDbContext(DbContextOptions <TransactionDbContext> options): base(options) 
        {
            
        }


        public DbSet <BankTransaction> Transactions { get; set; } 
    }
}
