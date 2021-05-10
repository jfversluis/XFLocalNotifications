using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Xamarin.Forms;

namespace XFLocalNotifications
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NotificationCenter.Current.NotificationReceived += Current_NotificationReceived;

            NotificationCenter.Current.NotificationTapped += Current_NotificationTapped;
        }

        private void Current_NotificationTapped(NotificationTappedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Notification tapped", e.Data, "OK");
            });
        }

        private void Current_NotificationReceived(NotificationReceivedEventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert(e.Title, e.Description, "OK");
                });
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Test Description",
                Title = "Notification!",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                NotifyTime = DateTime.Now.AddSeconds(5)
            };

            NotificationCenter.Current.Show(notification);
        }
    }
}
