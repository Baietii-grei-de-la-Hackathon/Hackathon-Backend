using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace QubHQ_Services.Services;

public class VeryfiService : IVeryfiService
{
    private readonly HttpClient _httpClient;

    public VeryfiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<JsonDocument> ExtractText(string base64Image)
    {
        if (string.IsNullOrEmpty(base64Image))
            throw new ArgumentException("Base64 string cannot be null or empty.", nameof(base64Image));

        try
        {
            //TODO: extract in appSettings
            var clientId = "vrfWGONseM2ynjypBpA7XLll7GimWsUxviDl5kB";
            var apiKey = "0297e4eaa915c92fc7fa08dd4004c7bc";
            var username = "andrei_raul04";

            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("API credentials are not set.");
            }

            string fileName = "image.jpg";

            var body = new
            {
                file_name = fileName,
                file_data = base64Image,
                categories = new string[] { }
            };

            var jsonBody = JsonSerializer.Serialize(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, "https://api.veryfi.com/api/v8/partner/documents/")
                {
                    Content = content
                };

            requestMessage.Headers.Add("CLIENT-ID", clientId);
            requestMessage.Headers.Add("AUTHORIZATION", $"apikey {username}:{apiKey}");

            var response = await _httpClient.SendAsync(requestMessage);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error calling Veryfi API: {responseString}");

            return JsonDocument.Parse(responseString);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error in OCR processing.", ex);
        }
    }
}