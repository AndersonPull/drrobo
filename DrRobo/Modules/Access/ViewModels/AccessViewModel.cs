using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using DrRobo.Modules.Access.Components;
using DrRobo.Modules.Access.Models;
using DrRobo.Modules.Access.Services.Request;
using DrRobo.Modules.Home.ViewModels;
using DrRobo.Modules.Shared.Components.Popup;
using DrRobo.Modules.Shared.Services.Navigation;
using DrRobo.Modules.Shared.ViewModels;
using DrRobo.Utils.Constants;
using DrRobo.Utils.Mapper;
using Refit;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace DrRobo.Modules.Access.ViewModels
{
    public class AccessViewModel : BaseViewModel
    {
        private INavigationService _serviceNavigation;
        private readonly IMapper _mapper = AccessMapper.CreateMapper();

        public ICommand PopupLoginCommand => new Command(async () => await PopupLoginAsync());
        public ICommand GoRegisterCommand => new Command(async () => await RegisterAsync());

        public AccessViewModel(INavigationService serviceNavigation)
        {
            _serviceNavigation = serviceNavigation;

            MessagingCenter.Subscribe<AccessModel>(this, "Login", async (value)
                => await LoginAsync(value));
        }

        private async Task PopupLoginAsync()
            => await PopupNavigation.Instance.PushAsync(new LoginPopup());

        private async Task RegisterAsync()
            => await _serviceNavigation.NavigateToAsync<RegisterViewModel>();

        private async Task LoginAsync(AccessModel access)
        {
            IsBusy = true;
            try
            {
                var response = await Constant.BaseAutAPI.PostLogin(_mapper.Map<AccessRequestDto>(access));
                if (response.Authenticated)
                    await _serviceNavigation.NavigateToAsync<TabbedPageViewModel>();
            }
            catch (ApiException apiException)
            {
                await PopupNavigation.Instance.PushAsync(new PopupErrorComponent() { Message = apiException.Message });
            }
            catch (Exception exception)
            {
                await PopupNavigation.Instance.PushAsync(new PopupErrorComponent() { Message = exception.Message });
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}