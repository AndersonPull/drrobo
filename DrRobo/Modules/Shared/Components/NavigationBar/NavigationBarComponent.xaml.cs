using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DrRobo.Modules.Shared.Components.NavigationBar
{
    public partial class NavigationBarComponent : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(NavigationBarComponent), string.Empty);

        public NavigationBarComponent()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
