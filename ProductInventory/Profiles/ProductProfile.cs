using System;
using AutoMapper;
using InventoryStorage.DTOs;
using InventoryStorage.Models;

namespace InventoryStorage.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ReadProductDTO>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<Product, UpdateProductDTO>();
        }
    }
}
