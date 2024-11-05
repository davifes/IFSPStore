﻿using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFPStore.Repository.Mapping
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda>builder)
        {
            builder.ToTable("Venda");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Data)
                .IsRequired();
            builder.Property(prop => prop.ValorTotal)
                .IsRequired();
            builder.HasOne(prop => prop.Cliente);
            builder.HasMany(prop => prop.Itens)
                .WithOne(prop => prop.Venda)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class VendaItemMap : IEntityTypeConfiguration<VendaItem>
    {
        public void Configure(EntityTypeBuilder<VendaItem>builder)
        {
            builder.ToTable("VendaItem");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Quantidade)
                .IsRequired();
            builder.Property(prop => prop.ValorUnitario)
                .IsRequired();
            builder.Property(prop => prop.ValorTotal)
                .IsRequired();
            builder.Property(prop => prop.Produto)
                .IsRequired();
            builder.HasOne(prop => prop.Venda)
                .WithMany(prop => prop.Itens)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
