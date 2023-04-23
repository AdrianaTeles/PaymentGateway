using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.DatabaseContext.Mappings
{
    public class CardMap : IEntityTypeConfiguration<CardInformation>
    {
        public void Configure(EntityTypeBuilder<CardInformation> builder)
        {
            builder.HasKey(x => new { x.CardId });
        }
    }
}