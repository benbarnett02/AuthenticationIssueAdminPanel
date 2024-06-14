namespace MinRep.Client.Core.Services.Contracts;

public interface IExternalNavigationService
{
    Task NavigateToAsync(string url);
}
