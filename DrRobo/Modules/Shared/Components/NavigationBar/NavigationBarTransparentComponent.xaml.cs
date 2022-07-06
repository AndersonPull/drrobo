using System;
using System.Collections.Generic;
using DrRobo.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DrRobo.Modules.Shared.Components.NavigationBar
{
    public partial class NavigationBarTransparentComponent : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(NavigationBarComponent), string.Empty);
        public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(NavigationBarComponent), Util.GetResource<Style>("TitleWhite"));
        public static readonly BindableProperty BackButtonProperty = BindableProperty.Create(nameof(BackButton), typeof(bool), typeof(NavigationBarComponent), true);
        public static readonly BindableProperty BackButtonBlackProperty = BindableProperty.Create(nameof(BackButtonBlack), typeof(bool), typeof(NavigationBarComponent), false);
        public static readonly BindableProperty ImageProfileProperty = BindableProperty.Create(nameof(ImageProfile), typeof(bool), typeof(NavigationBarComponent), false);

        public NavigationBarTransparentComponent()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public Style TitleStyle
        {
            get => (Style)GetValue(TitleStyleProperty);
            set => SetValue(TitleStyleProperty, value);
        }

        public bool BackButton
        {
            get => (bool)GetValue(BackButtonProperty);
            set => SetValue(BackButtonProperty, value);
        }

        public bool BackButtonBlack
        {
            get => (bool)GetValue(BackButtonBlackProperty);
            set => SetValue(BackButtonBlackProperty, value);
        }

        public bool ImageProfile
        {
            get => (bool)GetValue(ImageProfileProperty);
            set => SetValue(ImageProfileProperty, value);
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
