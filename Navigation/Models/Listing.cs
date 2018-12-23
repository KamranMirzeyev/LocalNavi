using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Navigation.Models
{
    public class Listing
    {
        public int  Id { get; set; }
        public bool Status { get; set; }


        public string Title { get; set; }
        public string Keyword { get; set; }
        public int  CategoryId { get; set; }

        public string Website { get; set; }

        public Category Category { get; set; }




        public string Address { get; set; }
        public string TemporaryAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string CountryId { get; set; }
        public string ZipCode { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public Country Country { get; set; }
        



        

        public string OwnerName { get; set; }
        
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebsiteCompany { get; set; }
        public string OwnerDesignation { get; set; }
        public string Company { get; set; }
        public  string Facebook { get; set; }
        public  string Twitter { get; set; }
        public  string GooglePlus { get; set; }
        public string Linkedin { get; set; }
        public  string Description { get; set; }





        public  bool Internet { get; set; }
        public bool BikeParking { get; set; }
        public  bool Smoking { get; set; }
        public  bool StreetParking { get; set; }
        public bool CreditCart { get; set; }
        public  bool AlarmSistem { get; set; }
        public bool DepanneurBuild { get; set; }
        public  bool Janitor { get; set; }
        public bool SecurityCamera { get; set; }
        public  bool DoorAttendant { get; set; }
        public bool LaundryRoom { get; set; }
        public  bool AttachedgGarage { get; set; }
        public  bool Elevator { get; set; }
        public  bool WheelchairAccessible { get; set; }
        public  bool HeatingAndHotWater { get; set; }
        




        public DateTime WdOpenTime { get; set; }
        public DateTime WdCloseTime { get; set; }
        public  DateTime WeOpenTime { get; set; }
        public  DateTime WeCloseTime { get; set; }

    }
}