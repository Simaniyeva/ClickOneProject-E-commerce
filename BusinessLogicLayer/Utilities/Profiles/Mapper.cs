

namespace BusinessLogicLayer.Utilities.Profiles;

public class Mapper : Profile
{
    public Mapper()
    {
        //Category
        CreateMap<Category,CategoryGetDto>();
        CreateMap<CategoryPostDto, Category>();
        CreateMap<CategoryUpdateDto, Category>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<CategoryGetDto, CategoryUpdateDto>();

        //SubCategory
        CreateMap<SubCategory, SubCategoryGetDto>();
        CreateMap<SubCategoryPostDto, SubCategory>();
        CreateMap<SubCategoryUpdateDto, SubCategory>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<SubCategoryGetDto, SubCategoryUpdateDto>();

        //Color
        CreateMap<Color, ColorGetDto>();
        CreateMap<ColorPostDto, Color>();
        CreateMap<ColorUpdateDto, Color>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ColorGetDto, ColorUpdateDto>();

        //Color
        CreateMap<Company, CompanyGetDto>();
        CreateMap<CompanyPostDto, Company>();
        CreateMap<CompanyUpdateDto, Company>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<CompanyGetDto, CompanyUpdateDto>();

        //Favourite
        CreateMap<Favourite, FavouriteGetDto>();
        CreateMap<FavouritePostDto, Favourite>();
        CreateMap<FavouriteUpdateDto, Favourite>();
        CreateMap<FavouriteGetDto, FavouriteUpdateDto>();

        //Product
        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductPostDto, Product>();
        CreateMap<ProductUpdateDto, Product>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ProductGetDto, ProductUpdateDto>();

        //Parameter
        CreateMap<Parameter, ParameterGetDto>();
        CreateMap<ParameterPostDto, Parameter>();
        CreateMap<ParameterUpdateDto, Parameter>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ParameterGetDto, ParameterUpdateDto>();

        //ProductCollection
        CreateMap<ProductCollection, ProductCollectionGetDto>();
        CreateMap<ProductCollectionPostDto, ProductCollection>();
        CreateMap<ProductCollectionUpdateDto, ProductCollection>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ProductCollectionGetDto, ProductCollectionUpdateDto>();

        //Review
        CreateMap<Review, ReviewGetDto>();
        CreateMap<ReviewPostDto, Review>();
        CreateMap<ReviewUpdateDto, Review>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ReviewGetDto, ReviewUpdateDto>();

        //Role
        CreateMap<IdentityRole, RoleGetDto>();
        CreateMap<RolePostDto, IdentityRole>();
        CreateMap<RoleUpdateDto, IdentityRole>();
        CreateMap<RoleGetDto, RoleUpdateDto>();

        //Auth
        CreateMap<RegisterDto, AppUser>();
        CreateMap<AppUser, UserGetDto>().ReverseMap();
    }

}
