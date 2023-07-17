using Microsoft.AspNetCore.Mvc;
using OpenCage.Geocode;

namespace New_folder.Controllers
{
    public class AddressController : Controller
    {

        private readonly OpenCageGeocoder _geocoder;

        public AddressController()
        {
            // Initialize the OpenCageGeocoder with your API key
            _geocoder = new OpenCageGeocoder("52f7f9ee0f7b446da19d8bec2245a1f4");
        }

        // GET /location/countries
        [HttpGet]
        public async Task<IActionResult> Countries()
        {
            try
            {
                // Use the geocoder to retrieve a list of countries
                var results = await _geocoder.GeocodeAsync("country");

                // Extract the country names from the results
                var countries = results.Select(r => r.Components.Country).Distinct();

                return Json(countries);
            }
            catch
            {
                // Handle error
                return StatusCode(500, "An error occurred while fetching countries.");
            }
        }
    }
}
