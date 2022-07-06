using System.Threading.Tasks;
using Xamarin.Forms;

namespace DrRobo.Modules.Home.Views
{
    public partial class TabbedPageView : ContentPage
    {
        public TabbedPageView()
        {
            InitializeComponent();
        }

        public ContentView GetContent() => this.ContentBody.Content as ContentView;

        public async Task SetContent(ContentView content)
        {
            await Task.Delay(1);
            ContentBody.Content = content;
        }
    }
}