using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListingModel.Model
{
   public class Country:BaseEntity
    {
        public string Shortname { get; set; }

        public virtual IList<Hotel> Hotels { get; set; }
        
    }

   
}
