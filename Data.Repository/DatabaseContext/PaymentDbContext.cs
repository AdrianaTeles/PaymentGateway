using Data.Repository.DatabaseContext.Mappings;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.DatabaseContext
{
    public class PaymentDbContext : DbContext
    {

        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentMap());
        }
    }
}
