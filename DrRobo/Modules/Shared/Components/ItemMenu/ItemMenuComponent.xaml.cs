using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DrRobo.Modules.Shared.Components.ItemMenu
{
    public partial class ItemMenuComponent : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ItemMenuComponent), string.Empty);
        public static readonly BindableProperty CommandEventProperty = BindableProperty.Create(nameof(CommandEvent), typeof(Command), typeof(ItemMenuComponent), null);

        public ItemMenuComponent()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Command CommandEvent
        {
            get => (Command)GetValue(CommandEventProperty);
            set => SetValue(CommandEventProperty, value);
        }
    }
}
