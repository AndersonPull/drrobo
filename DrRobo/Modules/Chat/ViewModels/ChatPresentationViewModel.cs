using System.Threading.Tasks;
using System.Windows.Input;
using DrRobo.Modules.Shared.Services.Navigation;
using DrRobo.Modules.Shared.ViewModels;
using Xamarin.Forms;

namespace DrRobo.Modules.Chat.ViewModels
{
    public class ChatPresentationViewModel : BaseViewModel
    {
        public ICommand ChatViewCommand => new Command(async () => await ChatViewAsync());

        INavigationService _serviceNavigation;

        public ChatPresentationViewModel(INavigationService serviceNavigation)
        {
            _serviceNavigation = serviceNavigation;
        }

        private async Task ChatViewAsync()
            => await _serviceNavigation.NavigateToAsync<ChatViewModel>();
    }
}