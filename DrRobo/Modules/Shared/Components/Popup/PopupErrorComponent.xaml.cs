using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace DrRobo.Modules.Shared.Components.Popup
{
    public partial class PopupErrorComponent : PopupPage
    {
        public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(PopupErrorComponent), string.Empty);

        public PopupErrorComponent()
        {
            InitializeComponent();
        }

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }
    }
}