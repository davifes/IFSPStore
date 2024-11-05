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
    public class GrupoMap : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            //define o nome da tebela
            builder.ToTable("Abobrinha");
            //define a chave primaria
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                   .HasColumnName("melancia")
                   .IsRequired()
                   .HasMaxLength(50);
                   //.HasColumnType("varchar(50)");
        }
    }
}
