﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace FerdeApka
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#FFDD33"));
            Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#FFDD33"));

            base.OnCreate(savedInstanceState);
        }
    }
}
