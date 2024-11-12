using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace IFSPStore.Repository.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Endereco).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Documento).IsRequired().HasMaxLength(50);
            builder.HasOne(c => c.Cidade);
        }
    }
}