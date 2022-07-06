using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DrRobo.Modules.Shared.Components.Chat
{
    public partial class DialogBalloonUser : ContentView
    {
        public DialogBalloonUser()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(DialogBalloonUser), string.Empty);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue((TextProperty), value);
        }
    }
}
