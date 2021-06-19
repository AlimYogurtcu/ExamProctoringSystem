using System.Data.Entity;

namespace ExamProctoring.Models
{
    public class AccountContext : DbContext // context to set bridge between dataserver and model
    {
        public DbSet<Account> Accounts { get; set; }
    }
}