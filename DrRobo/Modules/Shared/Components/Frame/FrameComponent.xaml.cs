using Xamarin.Forms;

namespace DrRobo.Modules.Shared.Components.Frame
{
    public partial class FrameComponent : Xamarin.Forms.Frame
    {
        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(FrameComponent), typeof(CornerRadius), typeof(FrameComponent));

        public FrameComponent()
        {
            InitializeComponent();
        }

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
