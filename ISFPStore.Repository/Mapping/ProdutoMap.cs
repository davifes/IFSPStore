using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStore.Repository.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Nome).HasMaxLength(255).IsRequired();
            builder.Property(prop => prop.Preco);
            builder.Property(prop => prop.Quantidade);
            builder.Property(prop => prop.DataCompra);
            builder.Property(prop => prop.UnidadeVenda).HasMaxLength(10);
            builder.HasOne(prop => prop.Grupo);

        }
    }
}