namespace DataAccessLayer.Configurations;

public class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
{
    public void Configure(EntityTypeBuilder<Parameter> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.isDeleted).IsRequired().HasDefaultValue(false);
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        builder.HasMany(b => b.ProductParameters).WithOne(b => b.Parameter).HasForeignKey(b => b.ParameterId);
    }
}
