using CoreGraphics;
using DrRobo.iOS.Renderers;
using DrRobo.Modules.Shared.Components.Entry;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryComponent), typeof(EntryRendererIOS))]
namespace DrRobo.iOS.Renderers
{
    public class EntryRendererIOS : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.LeftView = new UIView(new CGRect(0, 0, 8, this.Control.Frame.Height));
                Control.RightView = new UIView(new CGRect(0, 0, 8, this.Control.Frame.Height));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.BorderStyle = UITextBorderStyle.None;
                Element.HeightRequest = 30;
            }
        }
    }
}
