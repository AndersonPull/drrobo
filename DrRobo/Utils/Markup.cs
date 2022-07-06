using System;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrRobo.Utils
{
    [ContentProperty("Source")]
    public class Markup : IMarkupExtension
    {
        public string Source { get; set; } = "";

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Source))
                return null;

            return SvgImageSource.FromResource($"DrRobo.Resources.SVG.{Source}",typeof(App).Assembly);
        }
    }
}
