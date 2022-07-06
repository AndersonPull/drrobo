using NUnit.Framework;
using Xamarin.UITest;

namespace DrRobo.Test.Tests.Access
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class AccessTest
    {
        IApp app;
        Platform platform;

        public AccessTest(Platform latform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void Swipe_Move()
        {
            app.SwipeRightToLeft(c => c.XPath("SwipeView_login"));
        }
    }
}
