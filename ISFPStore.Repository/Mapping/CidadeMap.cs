using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStore.Repository.Mapping
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Estado).IsRequired().HasMaxLength(2);
            builder.Property(prop => prop.Nome).IsRequired().HasMaxLength(50);
        }
    }
}