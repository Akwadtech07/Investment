using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCage.Geocode;
using System.Net.Http.Headers;

namespace New_folder.Controllers
{
    public class AddressController : Controller
    {

        private readonly string _googleMapsApiKey = "YOUR_GOOGLE_MAPS_API_KEY";

        // ... Existing code ...

        //private async Task<List<GoogleGeocodeResult>> GeocodeAsync(string query)
        //{
        //    var locationService = new GoogleLocationService(_googleMapsApiKey);
        //    var geocodeResults = await locationService.GetLocations(query);

        //    return geocodeResults.Select(result => new GoogleGeocodeResult
        //    {
        //        Country = result.Country,
        //        State = result.State,
        //        City = result.City
        //    }).ToList();
        //}
    }
}
