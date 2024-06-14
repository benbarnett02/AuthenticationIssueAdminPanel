using MinRep.Shared.Dtos.Identity;
using MinRep.Client.Core.Controllers.Identity;

namespace MinRep.Client.Core.Components.Pages.Identity.Profile;

[Authorize]
public partial class ProfilePage
{
    private UserDto? user;
    private bool isLoading;


    [AutoInject] private IUserController userController = default!;


    protected override async Task OnInitAsync()
    {
        isLoading = true;

        try
        {
            user = await userController.GetCurrentUser(CurrentCancellationToken);
        }
        finally
        {
            isLoading = false;
        }

        await base.OnInitAsync();
    }
}
