using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoveisRental.Domain.Entities;


namespace MoviesRental.Infrastructure.Config
{
    internal class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(Director.Max_Length);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(Director.Max_Length);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.HasMany(x => x.Dvds)
                .WithOne(d => d.Director);
        }
    }
}
