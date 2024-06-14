﻿using MinRep.Shared.Dtos.Identity;
using MinRep.Client.Core.Controllers.Identity;

namespace MinRep.Client.Core.Components.Pages.Identity.Profile;

public partial class TwoFactorSection
{
    private string? qrCode;
    private bool isWaiting;
    private string? sharedKey;
    private int recoveryCodesLeft;
    private bool isKeyCopiedShown;
    private bool isCodesCopiedShown;
    private string[]? recoveryCodes;
    private string? authenticatorUri;
    private string? verificationCode;
    private bool isTwoFactorAuthEnabled;

    private string? message;
    private ElementReference messageRef = default!;


    [AutoInject] private Clipboard clipboard = default!;
    [AutoInject] private IUserController userController = default!;


    protected override async Task OnInitAsync()
    {
        await SendTwoFactorAuthRequest(new());

        await base.OnInitAsync();
    }

    private async Task EnableTwoFactorAuth()
    {
        if (string.IsNullOrWhiteSpace(verificationCode)) return;

        // Strip spaces and hyphens
        var twoFactorCode = verificationCode.Replace(" ", string.Empty).Replace("-", string.Empty);

        var request = new TwoFactorAuthRequestDto { Enable = true, TwoFactorCode = twoFactorCode };
        var response = await SendTwoFactorAuthRequest(request);

        recoveryCodes = response?.RecoveryCodes;

        await messageRef.ScrollIntoView();
    }

    private async Task DisableTwoFactorAuth()
    {
        var request = new TwoFactorAuthRequestDto { Enable = false };
        await SendTwoFactorAuthRequest(request);
    }

    private async Task GenerateRecoveryCode()
    {
        var request = new TwoFactorAuthRequestDto { ResetRecoveryCodes = true };
        var response = await SendTwoFactorAuthRequest(request);

        recoveryCodes = response?.RecoveryCodes;
    }

    private async Task ResetAuthenticatorKey()
    {
        var request = new TwoFactorAuthRequestDto { ResetSharedKey = true };
        await SendTwoFactorAuthRequest(request);
    }

    //private async Task ForgetMachine()
    //{
    //    var request = new TwoFactorAuthRequestDto { ForgetMachine = true };
    //    await SendTwoFactorAuthRequest(request);
    //}

    private async Task<TwoFactorAuthResponseDto?> SendTwoFactorAuthRequest(TwoFactorAuthRequestDto request)
    {
        if (isWaiting) return null;

        message = null;
        isWaiting = true;

        try
        {
            var response = await userController.TwoFactorAuth(request);

            qrCode = response.QrCode;
            sharedKey = response.SharedKey;
            authenticatorUri = response.AuthenticatorUri;
            recoveryCodesLeft = response.RecoveryCodesLeft;
            isTwoFactorAuthEnabled = response.IsTwoFactorEnabled;

            return response;
        }
        catch (KnownException e)
        {
            message = e.Message;

            await messageRef.ScrollIntoView();

            return null;
        }
        finally
        {
            isWaiting = false;
        }
    }

    private async Task CopySharedKeyToClipboard()
    {
        if (isKeyCopiedShown) return;

        await clipboard.WriteText(sharedKey!);

        isKeyCopiedShown = true;
        StateHasChanged();

        await Task.Delay(1000);

        isKeyCopiedShown = false;
        StateHasChanged();
    }

    private async Task CopyRecoveryCodesToClipboard()
    {
        if (isCodesCopiedShown) return;

        await clipboard.WriteText(string.Join(Environment.NewLine, recoveryCodes ?? []));

        isCodesCopiedShown = true;
        StateHasChanged();

        await Task.Delay(1000);

        isCodesCopiedShown = false;
        StateHasChanged();
    }
}