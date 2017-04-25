using Android.App;
using Android.OS;
using Microsoft.Azure.Mobile.Crashes;
using System;

namespace RaysHotDogs
{
    [Activity(Label = "Visit Ray's store", Icon = "@drawable/smallicon")]
    public class RayMapActivity: Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Crash
            //Crashes.GenerateTestCrash();
        }
    }
}