using System;
using AutoMapper;
using DrRobo.Modules.Access.ViewModels;
using DrRobo.Modules.Chat.ViewModels;
using DrRobo.Modules.Home.ViewModels;
using DrRobo.Modules.Shared.Services.Navigation;
using DrRobo.Modules.Shared.Services.Navigation.Implementations;
using Unity;

namespace DrRobo.Modules.Shared.ViewModels
{
    public class LocatorViewModel
    {
        private readonly IUnityContainer _container;

        private static readonly LocatorViewModel _instance = new LocatorViewModel();

        public static LocatorViewModel Instance
        {
            get { return _instance; }
        }

        public LocatorViewModel()
        {
            _container = new UnityContainer();

            _container.RegisterType<INavigationService, NavigationService>();

            _container.RegisterType<AccessViewModel>();
            _container.RegisterType<RegisterViewModel>();
            _container.RegisterType<TabbedPageViewModel>();
            _container.RegisterType<ChatViewModel>();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}