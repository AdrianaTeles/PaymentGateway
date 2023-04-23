using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository.DatabaseContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.DatabaseContext
{
    public class CardDbContext : DbContext
    {

        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardMap());
        }
    }
}