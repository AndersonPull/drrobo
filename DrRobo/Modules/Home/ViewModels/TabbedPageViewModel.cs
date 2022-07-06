using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using DrRobo.Modules.Access.ViewModels;
using DrRobo.Modules.Chat.ViewModels;
using DrRobo.Modules.Home.Components.Content;
using DrRobo.Modules.Home.Enums;
using DrRobo.Modules.Home.Models;
using DrRobo.Modules.Home.Views;
using DrRobo.Modules.Shared.Services.Navigation;
using DrRobo.Modules.Shared.ViewModels;
using Xamarin.Forms;

namespace DrRobo.Modules.Home.ViewModels
{
    public class TabbedPageViewModel : BaseViewModel
    {
        INavigationService _serviceNavigation;

        public ICommand ChatPresentationViewCommand => new Command(async () => await ChatPresentationViewAsync());
        public ICommand SetContentTypeCommand => new Command(async (value) => await SetContentTypeAsync((HomePageType)value));
        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());        

        private Dictionary<HomePageType, Lazy<ContentView>> ContentType =
            new Dictionary<HomePageType, Lazy<ContentView>>
            {
                { HomePageType.Home, new Lazy<ContentView>(()=> new HomeContent())},
                { HomePageType.Dash, new Lazy<ContentView>(()=> new DashContent())},
                { HomePageType.AboutUs, new Lazy<ContentView>(()=> new AboutUsContent())},
                { HomePageType.Profile, new Lazy<ContentView>(()=> new ProfileContent())}
            };

        public HomePageType CurrentContent { get; set; } = HomePageType.Home;

        public TabbedPageViewModel(INavigationService serviceNavigation)
        {
            _serviceNavigation = serviceNavigation;

        }

        public override Task InitializeAsync(object navigationData)
        {
            GetNews().GetAwaiter().GetResult();
            return base.InitializeAsync(navigationData);
        }

        private async Task SetContentTypeAsync(HomePageType item)
        {
            IsBussy = true;
            var currentView = Application.Current.MainPage;
            if (currentView.Navigation != null)
                currentView = currentView.Navigation.NavigationStack.Last();

            var MyView = currentView as TabbedPageView;

            if (CurrentContent == item)
                return;

            CurrentContent = item;

            await MyView.SetContent(ContentType[CurrentContent].Value);
            IsBussy = false;
        }

        private async Task GetNews()
        {
            List<NewsModel> news = new List<NewsModel>();

            NewsModel newOne = new NewsModel()
            {
                MainImage = "https://www.contabeis.com.br/assets/img/news/a_6443_f337d999d9ad116a7b4f3d409fcc6480.jpg",
                Tags = new List<Tags>
                {
                   new Tags{ Text = "tecnologia" },
                },
                Title = "Tecnologia na saude",
                Date = DateTime.Now
            };

            NewsModel newTwo = new NewsModel()
            {
                MainImage = "https://www.contabeis.com.br/assets/img/news/a_6443_f337d999d9ad116a7b4f3d409fcc6480.jpg",
                Tags = new List<Tags>
                {
                   new Tags{ Text = "tecnologia" },
                   new Tags{ Text = "Saúde" },
                },
                Title = "Vitrine para o mundo",
                Date = DateTime.Now
            };

            news.Add(newOne);
            news.Add(newTwo);
            NewsRobot = news;
        }

        private async Task ChatPresentationViewAsync()
            => await _serviceNavigation.NavigateToAsync<ChatPresentationViewModel>();

        private async Task LogoutAsync()
            => await _serviceNavigation.NavigateToAsync<AccessViewModel>();

        private bool isBussy;
        public bool IsBussy { get { return isBussy; } set { Set("IsBussy", ref isBussy, value); } }

        private List<NewsModel> newsRobot;
        public List<NewsModel> NewsRobot { get { return newsRobot; } set { Set("NewsRobot", ref newsRobot, value); } }
    }
}