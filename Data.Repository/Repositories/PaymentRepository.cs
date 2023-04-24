namespace Data.Repository.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Application.DTO;
    using Data.Repository.DatabaseContext;
    using Data.Repository.Interfaces;
    using Domain.Model;

    public class PaymentRepository : EfGenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentDbContext dbContext) : base(dbContext)
        {
        }
       
    }
}
