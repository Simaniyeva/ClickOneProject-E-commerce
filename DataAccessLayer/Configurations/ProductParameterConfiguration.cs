namespace DataAccessLayer.Configurations;

public class ProductBundleConfiguration : IEntityTypeConfiguration<ProductParameter>
{
    public void Configure(EntityTypeBuilder<ProductParameter> builder)
    {
        builder.HasKey(b => b.Id);
        //Relations
        builder.HasOne(b => b.Product).WithMany(b => b.ProductParameters).HasForeignKey(b => b.ProductId);
        builder.HasOne(b => b.Parameter).WithMany(b => b.ProductParameters).HasForeignKey(b => b.ParameterId);
    }
}