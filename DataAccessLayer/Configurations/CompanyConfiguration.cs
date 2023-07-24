namespace DataAccessLayer.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
        builder.Property(c => c.ImagePath).IsRequired();
        builder.Property(c => c.isDeleted).HasDefaultValue(false);
        builder.Property(c => c.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(c => c.FacebookUrl).HasMaxLength(255).HasDefaultValue(null);
        builder.Property(c => c.LinkedinUrl).HasMaxLength(255).HasDefaultValue(null);
        builder.Property(c => c.TwitterUrl).HasMaxLength(255).HasDefaultValue(null);
        builder.Property(c => c.InstagramUrl).HasMaxLength(255).HasDefaultValue(null);
        builder.Property(c => c.Description).HasMaxLength(2000);
        builder.HasMany(c => c.Products).WithOne(c => c.Company).HasForeignKey(c => c.CompanyId);
    }
}


