using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestaurantTCProject;

namespace RestaurantTCProject;
class Program
{
    static void Main(string[] args)
    {
        string key = File.ReadAllText("appsettings.json");
        string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();

        Console.WriteLine("Enter a zip code");
        var zipCode = Console.ReadLine();

        var client = new RestClient($"https://restaurants-near-me-usa.p.rapidapi.com/restaurants/location/zipcode/{zipCode}/1");
        var request = new RestRequest();
        request.AddHeader("content-type", "application/octet-stream");
        request.AddHeader("X-RapidAPI-Key", $"{APIKey}");
        request.AddHeader("X-RapidAPI-Host", "restaurants-near-me-usa.p.rapidapi.com");
        var response = client.Execute(request);

        var restaurant = new Restaurant();
        restaurant.RestaurantName = JObject.Parse(response.Content)["restaurants"][0]["restaurantName"].ToString();
        restaurant.ZipCode = int.Parse(JObject.Parse(response.Content)["restaurants"][0]["zipCode"].ToString());
        restaurant.PhoneNumber = JObject.Parse(response.Content)["restaurants"][0]["phone"].ToString();
        restaurant.City = JObject.Parse(response.Content)["restaurants"][0]["cityName"].ToString();
        restaurant.State = JObject.Parse(response.Content)["restaurants"][0]["stateName"].ToString();


        Console.WriteLine(restaurant.RestaurantName);
        Console.WriteLine(restaurant.ZipCode);
        Console.WriteLine(restaurant.PhoneNumber);
        Console.WriteLine(restaurant.City);
        Console.WriteLine(restaurant.State);

    }
}