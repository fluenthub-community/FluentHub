﻿using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace FluentHub.Views.UserPages
{
    public sealed partial class ProfilePage : Windows.UI.Xaml.Controls.Page
    {
        private string requestedUsername { get; set; } = "";
        private User user { get; set; } = new User();

        public ProfilePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            requestedUsername = e.Parameter as string;

            base.OnNavigatedTo(e);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            user = await App.Client.User.Get(requestedUsername);

            SetTopLevelUserInfo();
            ViewModel.SetProfileElements(user);
        }

        private void UserNavView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if(args.SelectedItem == null || args.SelectedItemContainer == null)
            {
                return;
            }

            switch (args.SelectedItemContainer.Tag.ToString())
            {
                case "Overview":
                    UserNavViewContent.Navigate(typeof(Activities));
                    break;
                case "Repositories":
                    UserNavViewContent.Navigate(typeof(Repositories));
                    break;
                case "Stars":
                    UserNavViewContent.Navigate(typeof(Stars));
                    break;
            }
        }

        private void SetTopLevelUserInfo()
        {
            // Avator
            BitmapImage avatorImage = new BitmapImage(new Uri(user.AvatarUrl));
            UserAvatorImage.Source = avatorImage;

            // Username
            if (user.Login != "")
            {
                Username.Text = user.Login;
            }

            // Fullname
            if (user.Name != "")
            {
                FullName.Text = user.Name;
            }

            // Bio
            if (user.Bio != "")
            {
                UserBioTextBlock.Text = user.Bio;
                UserBioBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
