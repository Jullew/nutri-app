using System.Linq;
using NutriApp.Models.Users;
using NutriApp.Models.Children;
using NutriApp.DTOs.Children;
using NutriApp.DTOs.Users;

public static class DtoMapper
{
    public static UserDTO ToDTO(this User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username,
            Role = user.Role.ToString(),
            PremiumLevel = user.PremiumLevel,
            CreatedDate = user.CreatedDate,
            LastLogin = user.LastLogin,
            Language = user.Language,
            Country = user.Country,
            DeviceType = user.DeviceType,
            Os = user.Os,
            AppVersion = user.AppVersion,
            Children = user.Children?.Select(c => c.ToDTO()).ToList()
        };
    }

    public static ChildDTO ToDTO(this Child child)
    {
        return new ChildDTO
        {
            Id = child.Id,
            Name = child.Name,
            BirthDate = child.BirthDate,
            UserId = child.UserId,
            Allergies = child.Allergies?.Select(a => a.Name).ToList(),
            Intolerances = child.Intolerances?.Select(i => i.Name).ToList(),
            Diets = child.Diets?.Select(d => d.Name).ToList(),
            TriedFoods = child.TriedFoods?.Select(tf => tf.FoodItem.Name).ToList()
        };
    }
}
