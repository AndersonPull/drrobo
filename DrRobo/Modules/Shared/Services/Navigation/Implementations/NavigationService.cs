using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrRobo.Modules.Access.ViewModels;
using DrRobo.Modules.Access.Views;
using DrRobo.Modules.Chat.ViewModels;
using DrRobo.Modules.Chat.Views;
using DrRobo.Modules.Home.ViewModels;
using DrRobo.Modules.Home.Views;
using DrRobo.Modules.Shared.ViewModels;
using Xamarin.Forms;

namespace DrRobo.Modules.Shared.Services.Navigation.Implementations
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }

        public Task InitializeAsync()
            => NavigateToAsync<AccessViewModel>();

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
            => InternalNavigateToAsync(typeof(TViewModel), null);

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
            => InternalNavigateToAsync(typeof(TViewModel), parameter);

        public Task NavigateToAsync(Type viewModelType)
            => InternalNavigateToAsync(viewModelType, null);

        public Task NavigateToAsync(Type viewModelType, object parameter)
            => InternalNavigateToAsync(viewModelType, parameter);

        public void NavPage(Page page)
            => Application.Current.MainPage = new NavigationPage(page);

        public void NavAsyncPage(Page page)
            => Device.BeginInvokeOnMainThread(async ()
                => await Application.Current.MainPage.Navigation.PushAsync(page));

        private static NavigationService instance = null;
        private static readonly object padlock = new object();

        public static NavigationService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new NavigationService();

                    return instance;
                }
            }
        }

        public virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is AccessView)
                CurrentApplication.MainPage = new NavigationPage(page);
            else if(page is TabbedPageView)
                CurrentApplication.MainPage = new NavigationPage(page);
            else
            {
                var nav = CurrentApplication.MainPage as NavigationPage;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await nav.PushAsync(page);
                });
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
                throw new KeyNotFoundException($"não existe mapeamento para ${viewModelType} por isso a navegação não está funcionando, mapeie a view model no método CreatePageViewModelMappings");

            return _mappings[viewModelType];
        }

        public Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
                throw new Exception($"A view model {viewModelType} não esta mapeado para uma page");

            Page page = Activator.CreateInstance(pageType) as Page;
            BaseViewModel viewModel = LocatorViewModel.Instance.Resolve(viewModelType) as BaseViewModel;
            page.BindingContext = viewModel;
            return page;
        }

        public void CreatePageViewModelMappings()
        {
            AccessMaps();
            TabbedPageMaps();
            ChatPresentationMaps();
        }

        private void AccessMaps()
        {
            _mappings.Add(typeof(AccessViewModel), typeof(AccessView));
            _mappings.Add(typeof(RegisterViewModel), typeof(RegisterView));
        }

        private void TabbedPageMaps()
        {
            _mappings.Add(typeof(TabbedPageViewModel), typeof(TabbedPageView));
        }

        private void ChatPresentationMaps()
        {
            _mappings.Add(typeof(ChatPresentationViewModel), typeof(ChatPresentationView));
            _mappings.Add(typeof(ChatViewModel), typeof(ChatView));
        }
    }
}