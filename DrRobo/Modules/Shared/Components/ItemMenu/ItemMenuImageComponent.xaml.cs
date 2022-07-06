using System;
using System.Collections.Generic;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace DrRobo.Modules.Shared.Components.ItemMenu
{
    public partial class ItemMenuImageComponent : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ItemMenuImageComponent), string.Empty);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ItemMenuImageComponent), string.Empty);
        public static readonly BindableProperty SourceImageProperty = BindableProperty.Create(nameof(SourceImage), typeof(string), typeof(ItemMenuImageComponent), null);
        public static readonly BindableProperty CommandEventProperty = BindableProperty.Create(nameof(CommandEvent), typeof(Command), typeof(ItemMenuImageComponent), null);

        public ItemMenuImageComponent()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string SourceImage
        {
            get => (string)GetValue(SourceImageProperty);
            set => SetValue(SourceImageProperty, value);
        }

        public Command CommandEvent
        {
            get => (Command)GetValue(CommandEventProperty);
            set => SetValue(CommandEventProperty, value);
        }
    }
}
