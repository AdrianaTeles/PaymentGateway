namespace Data.Repository.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Data.Repository.DatabaseContext;
    using Data.Repository.Interfaces;
    using Domain.Model;

    public class CardRepository : EfGenericRepository<CardInformation>, ICardRepository
    {
        public CardRepository(CardDbContext dbContext) : base(dbContext)
        {
        }
    }
}