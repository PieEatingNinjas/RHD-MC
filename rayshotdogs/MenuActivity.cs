using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile;

namespace RaysHotDogs
{
    [Activity(Label = "Ray's Hot Dogs", MainLauncher = true, Icon = "@drawable/smallicon")]
    public class MenuActivity : Activity
    {
        private Button orderButton;
        private Button cartButton;
        private Button aboutButton;
        private Button mapButton;
        private Button takePictureButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);

            FindViews();
            HandleEvents();

            //1. Analytics and Crashes
            //MobileCenter.Start("fd8917f2-d8d8-4074-b9f1-9c9ff3441a36",
            //        typeof(Analytics), typeof(Crashes));

            //2. Track Event
            //Analytics.TrackEvent("Application opened");

            Crashes.ShouldProcessErrorReport = (report) =>
            {
                return true; // return true if the crash report should be processed, otherwise false.
            };

            Crashes.ShouldAwaitUserConfirmation = () =>
            {
                return true; // Return true if the SDK should await user confirmation, otherwise false.
            };


            if (Crashes.HasCrashedInLastSession)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Sorry...");
                alert.SetMessage("It seems the app has crashed previously. We are sorry about this...");

                Dialog dialog = alert.Create();
                dialog.Show();
            }
        }

        private void FindViews()
        {
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
            cartButton = FindViewById<Button>(Resource.Id.cartButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            mapButton = FindViewById<Button>(Resource.Id.mapButton);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cartButton.Click += CartButton_Click;
            aboutButton.Click += AboutButton_Click;
            mapButton.Click += MapButton_Click;
            takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RayMapActivity));
            StartActivity(intent);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CartActivity));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(HotDogMenuActivity));
            StartActivity(intent);
        }
    }
}