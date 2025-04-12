using System.Text.Json;

namespace QubHQ_Services.Services;

public interface IVeryfiService
{
    Task<JsonDocument> ExtractText(string base64Image);
}