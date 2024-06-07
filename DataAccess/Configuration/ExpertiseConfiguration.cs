﻿using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class ExpertiseConfiguration : IEntityTypeConfiguration<Expertise>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Expertise> builder)
        {

            builder.ToTable("Expetrises");

            builder.Property(x => x.Id)
            .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Description)
             .HasMaxLength(1000)
             .IsRequired();
        }
    }
}
