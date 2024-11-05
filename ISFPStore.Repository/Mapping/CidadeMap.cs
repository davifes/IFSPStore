using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFPStore.Repository.Mapping
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(prop =>  prop.Id);
            builder.Property(prop => prop.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)"); 

            builder.Property(prop => prop.Estado)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }
    }
}
