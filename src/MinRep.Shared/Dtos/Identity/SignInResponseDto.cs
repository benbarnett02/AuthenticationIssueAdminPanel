﻿
namespace MinRep.Shared.Dtos.Identity;

public class SignInResponseDto : TokenResponseDto
{
    public bool RequiresTwoFactor { get; set; }
}