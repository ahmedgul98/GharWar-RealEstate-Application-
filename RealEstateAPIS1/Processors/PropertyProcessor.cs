using RealEstateAPIS1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstateAPIS1.Repositories;
namespace RealEstateAPIS1.Processors
{
    public class PropertyProcessor
    {
        public static bool ProcessProperty(Property prop)
        {
            return PropertyRepository.AddPropertyToDB(prop);
        }
        public static List<Property> ProcessGetProperty()
        {
            //return PropertyRepository
            return PropertyRepository.AllProperties();
        }
        public static List<Property> ProcessGetPropertyByRooms(int rooms)
        {
            return PropertyRepository.PropertiesByRoom(rooms);
        }
        public static List<Property> ProcessGetPropertyByRent(string rent)
        {
            return PropertyRepository.PropertiesByRent(rent);
        }
        public static List<Property> ProcessGetPropertyByArea(string area)
        {
            return PropertyRepository.PropertiesByArea(area);
        }
        public static List<Property> ProcessGetPropertyByFilter(int rooms, string area, string type)
        {
            return PropertyRepository.PropertiesByFiltering(rooms, area, type);
        }

        //public static Property ProcessGetProperty(string id)
        //{
        //    //return PropertyRepository
        //    return PropertyRepository.GetProperty(id);
        //}
        public static void AddToFav(string pid, string oid)
        {
            //return PropertyRepository

            PropertyRepository.AddToFav(pid, oid);
        }
    }
}