// src/YurttaYe.Application/Common/MappingProfile.cs
using AutoMapper;
using YurttaYe.Application.DTOs;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<MenuItemCreateDto, MenuItem>()
                .ForMember(dest => dest.Gramaj, opt => opt.MapFrom(src => new Domain.ValueObjects.Gramaj(src.GramajValue, src.GramajUnit)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceValue.HasValue ? new Domain.ValueObjects.Price(src.PriceValue.Value, src.PriceCurrency) : null))
                .ForMember(dest => dest.Calorie, opt => opt.MapFrom(src => src.CalorieValue.HasValue ? new Domain.ValueObjects.Calorie(src.CalorieValue.Value) : null));
        }
    }
}