using System;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace RestaurantTCProject;

public class Restaurant
{
    public string RestaurantName { get; set; }
    public int ZipCode { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string State { get; set; }

}