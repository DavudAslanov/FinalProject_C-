﻿using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class ServicePackageDescriptionConfiguration : IEntityTypeConfiguration<ServicePackageDescription>
    {
        public void Configure(EntityTypeBuilder<ServicePackageDescription> builder)
        {
            builder.ToTable("ServicePackageDescriptions");

            builder.Property(x => x.Id)

            .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Description)
           .HasMaxLength(1000)
           .IsRequired();


            builder.HasOne(x => x.ServicePackage)
             .WithMany(x => x.ServicePackageDescription)
             .HasForeignKey(x => x.ServicePackageId);

        }
    }
}
