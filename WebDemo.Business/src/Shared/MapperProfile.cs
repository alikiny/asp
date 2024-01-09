using AutoMapper;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Shared
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();

            CreateMap<Address, AddressReadDto>();
            CreateMap<AddressUpdateDto, Address>();
            CreateMap<AddressCreateDto, Address>();

            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductCreateDto, Product>();

            CreateMap<ProductLine, ProductLineReadDto>();
            CreateMap<ProductLineUpdateDto, ProductLine>();
            CreateMap<ProductLineCreateDto, ProductLine>();

            CreateMap<ProductSize, ProductSizeReadDto>();
            CreateMap<ProductSizeUpdateDto, ProductSize>();
            CreateMap<ProductSizeCreateDto, ProductSize>();

            CreateMap<ProductColor, ProductColorReadDto>();
            CreateMap<ProductColorUpdateDto, ProductColor>();
            CreateMap<ProductColorCreateDto, ProductColor>();

            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryCreateDto, Category>();

            /*   CreateMap<Avatar, AvatarReadDto>();
              CreateMap<AvatarUpdateDto, Avatar>();
              CreateMap<AvatarCreateDto, Avatar>(); */

            CreateMap<Image, ImageReadDto>();
            CreateMap<ImageUpdateDto, Image>();
            CreateMap<ImageCreateDto, Image>();

            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<OrderCreateDto, Order>();

            CreateMap<OrderDetail, OrderDetailReadDto>();
            CreateMap<OrderDetailUpdateDto, OrderDetail>();
            CreateMap<OrderDetailCreateDto, OrderDetail>();
        }
    }
}