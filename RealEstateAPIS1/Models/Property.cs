using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateAPIS1.Models
{
    public class Property
    {
        public string PropetyId { get; set; }
        public string OwnerId { get; set; }
        public string CityId { get; set; }
        public string TypeId { get; set; }
        public int n_Rooms { get; set; }
        public int n_Baths { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Area_sqft { get; set; }
        public string Rent { get; set; }
        public int Price { get; set; }
    }
}
