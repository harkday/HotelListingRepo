using AutoMapper;
using HotelListing.DTO;
using HotelListingModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configuration
{
    public class MapperInitializer:Profile
    {

        public MapperInitializer()
        {
            CreateMap<Country, CountryDto>().ReverseMap();

            CreateMap<Country, CreateCountryDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();

            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        }
    }
}
