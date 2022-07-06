using DrRobo.Modules.Shared.Services.Navigation;
using DrRobo.Modules.Shared.ViewModels;

namespace DrRobo.Modules.Chat.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        INavigationService _serviceNavigation;

        public ChatViewModel(INavigationService serviceNavigation)
        {
            _serviceNavigation = serviceNavigation;
        }
    }
}
