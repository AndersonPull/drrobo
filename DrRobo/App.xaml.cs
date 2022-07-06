using System.Threading.Tasks;
using AutoMapper;
using DrRobo.Modules.Shared.Services.Navigation;
using DrRobo.Modules.Shared.Services.Navigation.Implementations;
using DrRobo.Modules.Shared.ViewModels;
using Xamarin.Forms;

namespace DrRobo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitNavigation();
        }

        public Task InitNavigation()
        {
            var navigationService = LocatorViewModel.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}