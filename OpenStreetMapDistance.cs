using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;

/// <summary>
/// Class responsible for calculating the driving distance between two addresses using OpenStreetMap services.
/// </summary>
public class OpenStreetMapDistance
{
    private static readonly HttpClient client = new HttpClient();

    /// <summary>
    /// Initializes the OpenStreetMapDistance object with user-agent information.
    /// </summary>
    /// <param name="appName">The name of the application making the request.</param>
    /// <param name="version">The version of the application.</param>
    /// <param name="contactEmail">The contact email for the application.</param>
    /// <exception cref="ArgumentException">Thrown when any of the provided parameters are null or empty.</exception>
    public OpenStreetMapDistance(string appName, string version, string contactEmail)
    {
        if (string.IsNullOrWhiteSpace(appName) || string.IsNullOrWhiteSpace(version) || string.IsNullOrWhiteSpace(contactEmail))
        {
            throw new ArgumentException("App name, version, and contact email must be provided.");
        }

        string userAgent = $"{appName}/{version} ({contactEmail})";
        client.DefaultRequestHeaders.Remove("User-Agent");
        client.DefaultRequestHeaders.Add("User-Agent", userAgent);
    }

    /// <summary>
    /// Asynchronously retrieves the driving distance between two addresses in kilometers.
    /// </summary>
    /// <param name="address1">The first address.</param>
    /// <param name="address2">The second address.</param>
    /// <returns>The driving distance in kilometers.</returns>
    /// <exception cref="Exception">Thrown if coordinates cannot be retrieved for one or both addresses, or if the distance cannot be determined.</exception>
    public async Task<double> GetDrivingDistanceAsync(string address1, string address2)
    {
        var coord1 = await GetCoordinatesAsync(address1);
        var coord2 = await GetCoordinatesAsync(address2);

        if (coord1 == null || coord2 == null)
        {
            throw new Exception("Could not retrieve coordinates for one or both addresses.");
        }

        string osrmUrl = $"http://router.project-osrm.org/route/v1/driving/{coord1.Longitude},{coord1.Latitude};{coord2.Longitude},{coord2.Latitude}?overview=false";
        await Task.Delay(1000);
        HttpResponseMessage response = await client.GetAsync(osrmUrl);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
        {
            JsonElement root = doc.RootElement;

            if (root.TryGetProperty("routes", out JsonElement routes) && routes.GetArrayLength() > 0)
            {
                double distanceMeters = routes[0].GetProperty("distance").GetDouble();
                return distanceMeters / 1000.0;
            }
        }

        throw new Exception("Failed to retrieve driving distance from OSRM.");
    }

    /// <summary>
    /// Asynchronously retrieves the geographical coordinates (latitude and longitude) of a given address.
    /// </summary>
    /// <param name="address">The address whose coordinates are to be fetched.</param>
    /// <returns>The coordinates of the address if found, or null if not found.</returns>
    private async Task<Coordinates> GetCoordinatesAsync(string address)
    {
        await Task.Delay(1000);
        string encodedAddress = Uri.EscapeDataString(address);
        string nominatimUrl = $"https://nominatim.openstreetmap.org/search?format=json&q={encodedAddress}";

        HttpResponseMessage response = await client.GetAsync(nominatimUrl);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
        {
            JsonElement root = doc.RootElement;

            if (root.GetArrayLength() > 0)
            {
                var location = root[0];
                double lat = double.Parse(location.GetProperty("lat").GetString());
                double lon = double.Parse(location.GetProperty("lon").GetString());

                return new Coordinates(lat, lon);
            }
        }

        return null;
    }
}

/// <summary>
/// Represents a geographical coordinate with latitude and longitude.
/// </summary>
public class Coordinates
{
    public double Latitude { get; }
    public double Longitude { get; }

    /// <summary>
    /// Initializes the coordinates object with latitude and longitude.
    /// </summary>
    /// <param name="latitude">Latitude of the location.</param>
    /// <param name="longitude">Longitude of the location.</param>
    public Coordinates(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
