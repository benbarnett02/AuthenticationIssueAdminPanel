using MinRep.Server.Models.Identity;
using MinRep.Shared.Dtos.Identity;
using Riok.Mapperly.Abstractions;

namespace MinRep.Server.Mappers;

/// <summary>
/// More info at Server/Mappers/README.md
/// </summary>
[Mapper(UseDeepCloning = true)]
public static partial class IdentityMapper
{
    public static partial UserDto Map(this User source);
    public static partial void Patch(this EditUserDto source, User destination);
}
