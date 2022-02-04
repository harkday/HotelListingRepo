using AutoMapper;
using HotelListing.DTO;
using HotelListingDataAccess.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    public class CountryController : BaseController
    {
      
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _Logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> iLogger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _Logger = iLogger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryDto>>(countries);
                return Ok(results);

            }
            catch (Exception ex)
            {

                _Logger.LogError(ex, $"something went wrong in the {nameof(GetCountries)}");
                return StatusCode(500, "internal server error . please try again later");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(p => p.Id == id, new List<string> { "Hotels"});
                var result = _mapper.Map<CountryDto>(country);
                return Ok(result);

            }
            catch (Exception ex)
            {

                _Logger.LogError(ex, $"something went wrong in the {nameof(GetCountry)}");
                return StatusCode(500, "internal server error . please try again later");
            }
        }
    }
}
