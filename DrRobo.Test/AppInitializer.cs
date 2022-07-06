using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DrRobo.Test
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile ("../../../DrRobo.Android/bin/Debug/com.sm4ug.DrRobo.apk")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .AppBundle ("../../../DrRobo.iOS/bin/iPhoneSimulator/Debug/DrRobo.app")
                .StartApp();
        }
    }
}
