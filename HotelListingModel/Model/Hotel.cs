using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListingModel.Model
{
    public class Hotel : BaseEntity
    {

        public double Rating { get; set; }
        public string Address { get; set; }





        [ForeignKey(nameof(Country))]
        
        public int CountryId { get; set; }
        public Country Country { get; set; }


    }
}
