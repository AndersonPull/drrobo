using System;
using System.Linq;
using System.Threading.Tasks;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace DrRobo.Modules.Home.Components
{
    public partial class TabbedComponent : ContentView
    {
        public TabbedComponent()
        {
            InitializeComponent();
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs args)
        {
            var stackLayout = (StackLayout)sender;
            var button = stackLayout.Children.Where(x => x is SvgCachedImage).FirstOrDefault();

            if (button.Equals(SvgHome))
                await Animation(SvgHome, SvgHomeFull, args);
            else if (button.Equals(SvgDash))
                await Animation(SvgDash, SvgDashFull, args);
            else if (button.Equals(SvgAboutUs))
                await Animation(SvgAboutUs, SvgAboutUsFull, args);
            else if (button.Equals(SvgProfile))
                await Animation(SvgProfile, SvgProfileFull, args);
        }

        async Task Animation(SvgCachedImage button, SvgCachedImage buttonFull, EventArgs args)
        {
            SvgHome.IsVisible = true;
            SvgHomeFull.IsVisible = false;
            await SvgHome.TranslateTo(0, 0, 0, Easing.SinInOut);
            await SvgHome.FadeTo(1, 0, Easing.SinInOut);

            SvgDash.IsVisible = true;
            SvgDashFull.IsVisible = false;
            await SvgDash.TranslateTo(0, 0, 0, Easing.SinInOut);
            await SvgDash.FadeTo(1, 0, Easing.SinInOut);

            SvgAboutUs.IsVisible = true;
            SvgAboutUsFull.IsVisible = false;
            await SvgAboutUs.TranslateTo(0, 0, 0, Easing.SinInOut);
            await SvgAboutUs.FadeTo(1, 0, Easing.SinInOut);

            SvgProfile.IsVisible = true;
            SvgProfileFull.IsVisible = false;
            await SvgProfile.TranslateTo(0, 0, 0, Easing.SinInOut);
            await SvgProfile.FadeTo(1, 0, Easing.SinInOut);

            await button.TranslateTo(0, -50, 200, Easing.SinInOut);
            await button.FadeTo(0, 200, Easing.SinInOut);
            button.IsVisible = false;
            buttonFull.IsVisible = true;
        }
    }
}