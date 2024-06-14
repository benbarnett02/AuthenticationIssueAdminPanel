﻿namespace MinRep.Shared.Dtos.Identity;

[DtoResourceType(typeof(AppStrings))]
public class SendPhoneTokenRequestDto
{
    [Required(ErrorMessage = nameof(AppStrings.RequiredAttribute_ValidationError))]
    [Phone(ErrorMessage = nameof(AppStrings.PhoneAttribute_ValidationError))]
    [Display(Name = nameof(AppStrings.PhoneNumber))]
    public string? PhoneNumber { get; set; }
}