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
using RaysHotDogs.Core;
using RaysHotDogs.Adapters;
using Microsoft.WindowsAzure.MobileServices;

namespace RaysHotDogs
{
    [Activity(Label = "Welcome to Ray's Hot Dogs", Icon = "@drawable/smallicon")]
    public class CartActivity: Activity
    {
        private CartDataService cartDataService;
        private List<CartItem> cartItems;
        private ListView cartListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CartView);

            cartDataService = new CartDataService();

            cartListView = FindViewById<ListView>(Resource.Id.cartListView);

            var orderButton = FindViewById<Button>(Resource.Id.placeOrderButton);
            orderButton.Click += OrderButton_Click;

            cartItems = cartDataService.GetCart().CartItems;
            cartListView.Adapter = new CartAdapter(this, cartItems);
        }

        private async void OrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Tables
                
            }
            catch (Exception ex)
            {
            }
        }
    }

    public class User
    {
        [Newtonsoft.Json.JsonProperty("ExternalId")]
        public string ExternalID { get; set; }
        [Newtonsoft.Json.JsonProperty("Name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Order
    {
        [Newtonsoft.Json.JsonProperty("UserID")]
        public string UserID { get; set; }
        [Newtonsoft.Json.JsonProperty("OrderSummary")]
        public string OrderSummary { get; set; }
        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }
    }
}