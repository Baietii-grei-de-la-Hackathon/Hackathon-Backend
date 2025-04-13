using QubHQ_Services.Dtos;

namespace QubHQ_Services.Services.VerifyService;

public interface IVeryfiService
{
    Task<bool> ExtractText(ImageDto imageDto);
}