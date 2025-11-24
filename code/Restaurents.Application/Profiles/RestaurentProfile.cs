using System;
using AutoMapper;
using Restaurents.Application.Commands;
using Restaurents.Application.Commands.UpdateRestaurent;
using Restaurents.Application.DTOs;
using Restaurents.Domain.Entities;

namespace Restaurents.Application.Profiles;

public class RestaurentProfile : Profile
{
    public RestaurentProfile()
    {
        CreateMap<Restaurent, RestaurentDto>()
        .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address.City == null ? null : src.Address.City))
        .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode == null ? null : src.Address.PostalCode))
        .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address.Street == null ? null : src.Address.Street))
        .ForMember(d => d.dishes, opt => opt.MapFrom(src => src.Dishes)).ReverseMap();

        CreateMap<UpdateRestaurentCommand, Restaurent>()
        .ReverseMap();

        CreateMap<CreateRestaurentCommand, Restaurent>()
        .ForMember(d => d.Address, opt => opt.MapFrom(src => new Address
        {
            City = src.City,
            PostalCode = src.PostalCode,
            Street = src.Street
        }));


    }
}
