using System;
using System.Threading.Tasks;
using DrRobo.Modules.Shared.ViewModels;

namespace DrRobo.Modules.Shared.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateToAsync(Type viewModelType);
    }
}