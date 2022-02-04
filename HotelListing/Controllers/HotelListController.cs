using AutoMapper;
using HotelListing.DTO;
using HotelListingDataAccess.Repository.Implementation;
using HotelListingDataAccess.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    public class HotelListController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelListController> _logger;
        private readonly IMapper _mapper;
        public HotelListController(IUnitOfWork unitOfWork, ILogger<HotelListController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();
                var results = _mapper.Map<IList<HotelDto>>(hotels);
                return Ok(results);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"something went wrong in the {nameof(GetAllHotels)}");
                return StatusCode(500, "internal server error, please try again");
            }
        }


        [HttpGet("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200Ok)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult>GetHotel(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id, new List<string> { "Country" });
                var result = _mapper.Map<HotelDto>(hotel);
                return Ok(result);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"something went wront i the {nameof(GetHotel)}");
                return StatusCode(500, "internal server error,  please try again");
            }
        }


    }  
}
