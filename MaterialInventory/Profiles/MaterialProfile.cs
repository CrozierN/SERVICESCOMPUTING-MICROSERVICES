using System;
using AutoMapper;
using MaterialInventory.DTOs;
using MaterialInventory.Models;

namespace MaterialInventory.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, ReadMaterialDTO>();
            CreateMap<CreateMaterialDTO, Material>();
            CreateMap<UpdateMaterialDTO, Material>();
            CreateMap<Material, UpdateMaterialDTO>();
        }
    }
}
