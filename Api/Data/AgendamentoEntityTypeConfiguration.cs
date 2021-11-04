using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class AgendamentoEntityTypeConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            // Entity Configure
            builder.ToTable("tbl_agendamento");
            builder.HasKey(ag => ag.Id);

            // Properties Configure
            builder.Property(ag => ag.Id).HasColumnName("id").IsRequired();
            builder.Property(ag => ag.Data).HasColumnName("data").IsRequired();
            builder.Property(ag => ag.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(ag => ag.Especie).HasColumnName("especie").HasMaxLength(50).IsRequired();
            builder.Property(ag => ag.Servico).HasColumnName("servico").HasMaxLength(100).IsRequired();
        }
    }
}