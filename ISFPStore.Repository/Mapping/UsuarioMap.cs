using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace IFSPStore.Repository.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.DataLogin).IsRequired();
            builder.Property(x => x.Ativo);
        }


    }
}
