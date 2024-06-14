using MinRep.Shared.Dtos.Categories;
using MinRep.Shared.Dtos.Dashboard;
using MinRep.Shared.Dtos.Products;
using MinRep.Shared.Dtos.Identity;

namespace MinRep.Shared.Dtos;

/// <summary>
/// https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
/// </summary>
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Dictionary<string, object>))]
[JsonSerializable(typeof(UserDto))]
[JsonSerializable(typeof(List<ProductsCountPerCategoryResponseDto>))]
[JsonSerializable(typeof(OverallAnalyticsStatsDataResponseDto))]
[JsonSerializable(typeof(List<ProductSaleStatResponseDto>))]
[JsonSerializable(typeof(List<ProductPercentagePerCategoryResponseDto>))]
[JsonSerializable(typeof(ProductDto))]
[JsonSerializable(typeof(PagedResult<ProductDto>))]
[JsonSerializable(typeof(List<ProductDto>))]
[JsonSerializable(typeof(CategoryDto))]
[JsonSerializable(typeof(PagedResult<CategoryDto>))]
[JsonSerializable(typeof(List<CategoryDto>))]
[JsonSerializable(typeof(IdentityRequestDto))]
[JsonSerializable(typeof(SignInRequestDto))]
[JsonSerializable(typeof(SignInResponseDto))]
[JsonSerializable(typeof(TokenResponseDto))]
[JsonSerializable(typeof(RefreshRequestDto))]
[JsonSerializable(typeof(SignUpRequestDto))]
[JsonSerializable(typeof(EditUserDto))]
[JsonSerializable(typeof(RestErrorInfo))]
[JsonSerializable(typeof(SendEmailTokenRequestDto))]
[JsonSerializable(typeof(SendPhoneTokenRequestDto))]
[JsonSerializable(typeof(ConfirmEmailRequestDto))]
[JsonSerializable(typeof(ChangeEmailRequestDto))]
[JsonSerializable(typeof(ConfirmPhoneRequestDto))]
[JsonSerializable(typeof(ChangePhoneNumberRequestDto))]
[JsonSerializable(typeof(SendResetPasswordTokenRequestDto))]
[JsonSerializable(typeof(ResetPasswordRequestDto))]
[JsonSerializable(typeof(TwoFactorAuthRequestDto))]
[JsonSerializable(typeof(TwoFactorAuthResponseDto))]
public partial class AppJsonContext : JsonSerializerContext
{
}
