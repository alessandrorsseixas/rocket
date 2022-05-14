
using ClienteApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClienteApi.Respotirory.Mappings.General
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {

            entity.HasKey(e => e.Id);

            entity.ToTable("ClientePetrobras");

            entity.Property(e => e.Nome)
               .HasMaxLength(100)
               .IsUnicode(false);

            entity.Property(e => e.Nome)
            .HasMaxLength(100)
            .IsUnicode(false);

         }
    }
}
