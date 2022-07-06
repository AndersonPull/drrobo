using System.Collections.Generic;
using DrRobo.Modules.Home.Models;
using Xamarin.Forms;

namespace DrRobo.Modules.Home.Components.News
{
    public partial class NewsComponent : ContentView
    {
        public static readonly BindableProperty NewsRobotProperty = BindableProperty.Create(nameof(NewsRobot), typeof(List<NewsModel>), typeof(NewsComponent));

        public NewsComponent()
        {
            InitializeComponent();
        }

        public List<NewsModel> NewsRobot
        {
            get => (List<NewsModel>)GetValue(NewsRobotProperty);
            set => SetValue(NewsRobotProperty, value);
        }
    }
}
