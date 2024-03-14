using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntitiesValidation
{
    internal class JokeConfig : IEntityTypeConfiguration<Joke>
    {
        public void Configure(EntityTypeBuilder<Joke> builder)
        {
            builder.ToTable("Jokes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.JokeName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.JokeDescription).HasMaxLength(500).IsRequired();
            builder.Property(p => p.JokeOwner).HasMaxLength(20).IsRequired();
        }
    }
}
