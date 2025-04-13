using System.Text;
using Hackathon_Backend.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QubHq_Repo.UnitOfWork;
using QubHQ_Services.Dtos;
using QubHQ_Services.ExtensionMethods;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace QubHQ_Services.Services.VerifyService;

public class VeryfiService : IVeryfiService
{
    private readonly HttpClient _httpClient;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOptions<VeryfiSettings> _options;

    public VeryfiService(HttpClient httpClient, IUnitOfWork unitOfWork, IOptions<VeryfiSettings> options)
    {
        _httpClient = httpClient;
        _unitOfWork = unitOfWork;
        _options = options;
    }

    public async Task<bool> ExtractText(ImageDto imageDto)
    {
        if (string.IsNullOrEmpty(imageDto.Base64Image))
            throw new ArgumentException("Base64 string cannot be null or empty.", nameof(imageDto.Base64Image));

        try
        {
            if (string.IsNullOrEmpty(_options.Value.ClientId) || string.IsNullOrEmpty(_options.Value.ApiKey))
            {
                throw new InvalidOperationException("API credentials are not set.");
            }
            
            var body = new
            {
                file_name =  "image.jpg",
                file_data = imageDto.Base64Image,
                categories = new string[] { }
            };
            
            var jsonBody = JsonSerializer.Serialize(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            
            var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, "https://api.veryfi.com/api/v8/partner/documents/")
                {
                    Content = content
                };
            
            requestMessage.Headers.Add("CLIENT-ID", _options.Value.ClientId);
            requestMessage.Headers.Add("AUTHORIZATION", $"apikey {_options.Value.Username}:{_options.Value.ApiKey}");
            
            var response = await _httpClient.SendAsync(requestMessage);
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error calling Veryfi API: {responseString}");

            VeryfiItem items = JsonConvert.DeserializeObject<VeryfiItem>(responseString) ?? throw new
                InvalidOperationException();

            var itemRepo = _unitOfWork.GetRepository<QubHq_Repo.Models.Item>();

            var itemDtoList = items.MapVeryfiItemsToItemDtos(imageDto.TransactionId);

            await itemRepo.AddRangeAsync(itemDtoList);
            var changes = _unitOfWork.Commit();
            
            if (changes > 0)
                return true;
            return false;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error in OCR processing.", ex);
        }
    }
}