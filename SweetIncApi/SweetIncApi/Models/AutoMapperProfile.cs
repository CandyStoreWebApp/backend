using AutoMapper;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Box;
using SweetIncApi.Models.DTO.BoxPattern;
using SweetIncApi.Models.DTO.BoxProduct;
using SweetIncApi.Models.DTO.Brand;
using SweetIncApi.Models.DTO.Category;
using SweetIncApi.Models.DTO.Order;
using SweetIncApi.Models.DTO.OrderDetail;
using SweetIncApi.Models.DTO.Origin;
using SweetIncApi.Models.DTO.PaymentDetail;
using SweetIncApi.Models.DTO.Product;
using SweetIncApi.Models.DTO.Role;
using SweetIncApi.Models.DTO.User;

namespace SweetIncApi.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateBoxMap();
            CreateBoxPatternMap();
            CreateBoxProductMap();
            CreateBrandMap();
            CreateCategoryMap();
            CreateOrderMap();
            CreateOrderDetailMap();
            CreateOriginMap();
            CreatePaymentDetailMap();
            CreateProductMap();
            CreateRoleMap();
            CreateUserMap();
        }

        private void CreateBoxMap()
        {
            CreateMap<BoxVM, Box>().ReverseMap();
            CreateMap<BoxUpdateVM, Box>().ReverseMap();
        }
        private void CreateBoxPatternMap()
        {
            CreateMap<BoxPatternVM, BoxPattern>().ReverseMap();
            CreateMap<BoxPatternUpdateVM, BoxPattern>().ReverseMap();
        }
        private void CreateBoxProductMap()
        {
            CreateMap<BoxProductVM, BoxProduct>().ReverseMap();
        }
        private void CreateBrandMap()
        {
            CreateMap<BrandVM, Brand>().ReverseMap();
            CreateMap<BrandUpdateVM, Brand>().ReverseMap();
        }
        private void CreateCategoryMap()
        {
            CreateMap<CategoryVM, Category>().ReverseMap();
            CreateMap<CategoryUpdateVM, Category>().ReverseMap();
        }
        private void CreateOrderMap()
        {
            CreateMap<OrderVM, Order>().ReverseMap();
            CreateMap<OrderUpdateVM, Order>().ReverseMap();
        }
        private void CreateOrderDetailMap()
        {
            CreateMap<OrderDetailVM, OrderDetail>().ReverseMap();
        }
        private void CreateOriginMap()
        {
            CreateMap<OriginVM, Origin>().ReverseMap();
            CreateMap<OriginUpdateVM, Origin>().ReverseMap();
        }
        private void CreatePaymentDetailMap()
        {
            CreateMap<PaymentDetailVM, PaymentDetail>().ReverseMap();
            CreateMap<PaymentDetailUpdateVM, PaymentDetail>().ReverseMap();
        }
        private void CreateProductMap()
        {
            CreateMap<ProductVM, PaymentDetail>().ReverseMap();
            CreateMap<ProductUpdateVM, PaymentDetail>().ReverseMap();
        }
        private void CreateRoleMap()
        {
            CreateMap<RoleVM, Role>().ReverseMap();
            CreateMap<RoleUpdateVM, Role>().ReverseMap();
        }
        private void CreateUserMap()
        {
            CreateMap<UserVM, User>().ReverseMap();
            CreateMap<UserUpdateVM, User>().ReverseMap();
            CreateMap<UserForLogin, User>().ReverseMap();
        } 
    }
}
