using QubHq_Repo.Models;
using QubHQ_Services.Dtos;

namespace QubHQ_Services.ExtensionMethods;

public static class UserExtensionMethods
{
    public static User ToModel(this UserDto userDto)
    {
        var user = new User()
        {
            Name = userDto.Name,
            Amount = userDto.Amount,
            DidPay = userDto.DidPay,
            IsPayee = userDto.IsPayee,
        };

        if (userDto.Email is not null)
            user.Email = userDto.Email;

        if (userDto.PhoneNo is not null)
            user.PhoneNo = userDto.PhoneNo;

        return user;
    }

    public static UserDto ToDto(this User user)
    {
        var userDto = new UserDto()
        {
            Id = user.Id,
            Name = user.Name,
            Amount = user.Amount,
            DidPay = user.DidPay,
            IsPayee = user.IsPayee
        };

        if (user.Email is not null)
            userDto.Email = user.Email;

        if (user.PhoneNo is not null)
            userDto.PhoneNo = user.PhoneNo;

        return userDto;
    }

    public static User UpdateModel(this User user, UserDto userDto)
    {
        user.Id = (Guid)userDto.Id!;
        user.Name = userDto.Name;
        user.Amount = userDto.Amount;
        user.DidPay = userDto.DidPay;
        user.Email = userDto.Email;
        user.PhoneNo = userDto.PhoneNo;
        user.Email = userDto.Email;
        user.IsPayee = userDto.IsPayee;
        return user;
    }  

    public static List<UserDto> ToDtoList(this IEnumerable<User> users)
    {
        var userDtos = new List<UserDto>();
        foreach (var user in users)
        {
            userDtos.Add(user.ToDto());
        }

        return userDtos;
    }

    public static List<User> ToModelList(this IEnumerable<UserDto> userDtos)
    {
        var user = new List<User>();
        foreach (var userDto in userDtos)
        {
            user.Add(userDto.ToModel());
        }

        return user;
    }
}