
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using DrRobo.Droid.Renderers;
using DrRobo.Modules.Shared.Components.Frame;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FrameComponent), typeof(FrameRendererAndroid))]
namespace DrRobo.Droid.Renderers
{
    class FrameRendererAndroid : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        public FrameRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(FrameComponent.CornerRadius) ||
                e.PropertyName == nameof(FrameComponent))
                UpdateCornerRadius();
        }

        private void UpdateCornerRadius()
        {
            if (Control.Background is GradientDrawable backgroundGradient)
            {
                var cornerRadius = (Element as FrameComponent)?.CornerRadius;
                if (!cornerRadius.HasValue)
                    return;

                var topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
                var topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
                var bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
                var bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

                var cornerRadii = new[]
                {
                    topLeftCorner,
                    topLeftCorner,

                    topRightCorner,
                    topRightCorner,

                    bottomRightCorner,
                    bottomRightCorner,

                    bottomLeftCorner,
                    bottomLeftCorner,
                };

                backgroundGradient.SetCornerRadii(cornerRadii);
            }
        }
    }
}