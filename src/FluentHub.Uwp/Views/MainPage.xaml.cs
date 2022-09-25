using FluentHub.Uwp.Dialogs;
using FluentHub.Uwp.Helpers;
using FluentHub.Uwp.Models;
using FluentHub.Uwp.Services;
using FluentHub.Uwp.Services.Navigation;
using FluentHub.Uwp.ViewModels;
using FluentHub.Uwp.Utils;
using Microsoft.Extensions.DependencyInjection;
using Windows.ApplicationModel.Core;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using muxc = Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace FluentHub.Uwp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            var provider = App.Current.Services;
            ViewModel = provider.GetRequiredService<MainPageViewModel>();
            navService = provider.GetRequiredService<INavigationService>();
            Logger = provider.GetService<ILogger>();
        }

        #region Fields and Properties
        public MainPageViewModel ViewModel { get; }
        private INavigationService navService { get; }
        public ILogger Logger { get; }
        #endregion

        #region Methods
        private void SubscribeEvents()
        {
            var titleBar = CoreApplication.GetCurrentView().TitleBar;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnAppBackRequested;
            Window.Current.CoreWindow.PointerPressed += OnWindowPointerPressed;
        }

        private void UnsubscribeEvents()
        {
            var titleBar = CoreApplication.GetCurrentView().TitleBar;
            SystemNavigationManager.GetForCurrentView().BackRequested -= OnAppBackRequested;
            Window.Current.CoreWindow.PointerPressed -= OnWindowPointerPressed;
        }

        private muxc.InfoBarSeverity UserNotificationToInfoBarSeverity(UserNotificationType type)
        {
            return type switch
            {
                UserNotificationType.Info => muxc.InfoBarSeverity.Informational,
                UserNotificationType.Success => muxc.InfoBarSeverity.Success,
                UserNotificationType.Warning => muxc.InfoBarSeverity.Warning,
                UserNotificationType.Error => muxc.InfoBarSeverity.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
            };
        }
        #endregion

        #region Event handlers
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            SubscribeEvents();
            TabView.NewTabPage = typeof(Home.UserHomePage);
            navService.Configure(TabView);
            navService.Navigate<Home.UserHomePage>();

            var command = ViewModel.LoadSignedInUserCommand;
            if (command.CanExecute(null))
                command.Execute(null);

            // Configure Jumplist
            await JumpListHelper.ConfigureDefaultJumpListAsync();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            UnsubscribeEvents();
            navService.Disconnect();
        }

        private void OnSearchGitHubButtonButtonClick(object sender, RoutedEventArgs e)
        {
            SearchGitHubAutoSuggestBox.Visibility = Visibility.Visible;
            SearchGitHubAutoSuggestBox.Focus(FocusState.Pointer);
            SearchGitHubButton.Visibility = Visibility.Collapsed;
        }

        //private void OpenSearchAccelerator(KeyboardAcceleratorInvokedEventArgs e)
        //{
        //    SearchGitHubAutoSuggestBox.Visibility = Visibility.Visible;
        //    SearchGitHubAutoSuggestBox.Focus(FocusState.Keyboard);
        //    SearchGitHubButton.Visibility = Visibility.Collapsed;
        //}

        private void OnSearchGitHubAutoSuggestBoxLostFocus(object sender, RoutedEventArgs e)
        {
            SearchGitHubAutoSuggestBox.Visibility = Visibility.Collapsed;
            SearchGitHubButton.Visibility = Visibility.Visible;
        }

        private void OnSearchGitHubAutoSuggestBoxQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var parameter = args.QueryText;
            navService.Navigate<Searches.RepositoriesPage>(new Models.FrameNavigationArgs() { Parameters = new() { parameter } });
        }

        private void OnSearchGitHubAutoSuggestBoxSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = sender.Text;
        }

        private void OnSearchGitHubAutoSuggestBoxTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suitableItems = new List<string>();

                bool isInRepositories = false;
                bool isInOrganizations = false;
                bool isInUsers = false;

                Type currentPage = navService.CurrentPage;
                var currentPageNamespace = currentPage.ToString();

                if (sender.Text != "")
                {
                    suitableItems.Add(sender.Text + " in all of Github");
                }

                if (currentPageNamespace.Contains("Views.Organizations"))
                {
                    suitableItems.Add(sender.Text + " in this organization");
                }
                else if (currentPageNamespace.Contains("Views.Repositories"))
                {
                    suitableItems.Add(sender.Text + " in this repository");

                    // If that repository is in organization, it should be also added 'is this organization'
                }
                else if (currentPageNamespace.Contains("Views.Users"))
                {
                    suitableItems.Add(sender.Text + " in this user");
                }

                sender.ItemsSource = suitableItems;
            }
        }

        private void OnAppBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (navService.CanGoBack())
            {
                navService.GoBack();
                e.Handled = true;
            }

            Logger?.Debug("SystemNavigationManager.GetForCurrentView().BackRequested fired, [handled: {0}]", e.Handled);
        }

        private void OnWindowPointerPressed(CoreWindow sender, PointerEventArgs e)
        {
            // Mouse back button pressed
            if (e.CurrentPoint.Properties.IsXButton1Pressed)
            {
                bool canGoBack = navService.CanGoBack();
                if (canGoBack)
                {
                    navService.GoBack();
                    e.Handled = true;
                }
                Logger?.Debug("CoreWindow.PointerPressed [button: {0}, canGoBack: {1}]",
                    e.CurrentPoint.Properties.PointerUpdateKind,
                    canGoBack);
            }
            // Mouse forward button pressed
            else if (e.CurrentPoint.Properties.IsXButton2Pressed)
            {
                bool canGoForward = navService.CanGoForward();
                if (canGoForward)
                {
                    navService.GoForward();
                    e.Handled = true;
                }
                Logger?.Debug("CoreWindow.PointerPressed [button: {0}, CanGoForward: {1}]",
                    e.CurrentPoint.Properties.PointerUpdateKind,
                    canGoForward);
            }
        }

        private void OnDragAreaLoaded(object sender, RoutedEventArgs e)
            => Window.Current.SetTitleBar(DragArea);

        private void OnTabViewSelectionChanged(object sender, TabViewSelectionChangedEventArgs e)
            => RootFrameBorder.Child = e.NewSelectedItem?.Frame;

        private void OnMenuFlyoutItemClick(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuFlyoutItem;

            switch (item?.Tag)
            {
                case "NewRepo":
                    break;
                case "NewOrganization":
                    break;
                case "Profile":
                    navService.Navigate<Users.OverviewPage>(
                        new FrameNavigationArgs()
                        {
                            Login = App.Settings.SignedInUserName,
                        });
                    break;
                case "Repositories":
                    navService.Navigate<Users.RepositoriesPage>(
                        new FrameNavigationArgs()
                        {
                            Login = App.Settings.SignedInUserName,
                            Parameters = new() { "AsViewer" },
                        });
                    break;
                case "Discussions":
                    navService.Navigate<Users.DiscussionsPage>(
                    new Models.FrameNavigationArgs()
                    {
                        Login = App.Settings.SignedInUserName,
                        Parameters = new() { "AsViewer" },
                    });
                    break;
                case "Issues":
                    navService.Navigate<Users.IssuesPage>(
                    new Models.FrameNavigationArgs()
                    {
                        Login = App.Settings.SignedInUserName,
                        Parameters = new() { "AsViewer" },
                    });
                    break;
                case "PullRequests":
                    navService.Navigate<Users.PullRequestsPage>(
                    new Models.FrameNavigationArgs()
                    {
                        Login = App.Settings.SignedInUserName,
                        Parameters = new() { "AsViewer" },
                    });
                    break;
                case "Organizations":
                    navService.Navigate<Users.OrganizationsPage>(
                    new Models.FrameNavigationArgs()
                    {
                        Login = App.Settings.SignedInUserName,
                        Parameters = new() { "AsViewer" },
                    });
                    break;
                case "Stars":
                    navService.Navigate<Users.StarredReposPage>(
                    new Models.FrameNavigationArgs()
                    {
                        Login = App.Settings.SignedInUserName,
                        Parameters = new() { "AsViewer" },
                    });
                    break;
                //case "AccountSettings":
                //    navService.Navigate<AppSettings.MainSettingsPage>("fluenthub://settings/account");
                //    break;
                case "Settings":
                    navService.Navigate<AppSettings.AppearancePage>();
                    break;
                case "SignOut":
                    Frame rootFrame = (Frame)Window.Current.Content;
                    rootFrame.Navigate(typeof(SignIn.IntroPage));
                    break;
            }
        }

        private void OnMainNavViewItemInvoked(muxc.NavigationView sender, muxc.NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer == null)
            {
                return;
            }

            int selectedIndex = 0;

            switch (args.InvokedItemContainer.Tag?.ToString().ToLower())
            {
                case "home":
                    selectedIndex = 0;
                    navService.Navigate<Home.UserHomePage>();
                    break;
                case "notifications":
                    selectedIndex = 1;
                    navService.Navigate<Home.NotificationsPage>();
                    break;
                case "activity":
                    selectedIndex = 2;
                    navService.Navigate<Users.ContributionsPage>();
                    break;
                //case "marketplace":
                //    selectedIndex = 3;
                //    break;
                //case "explore":
                //    selectedIndex = 4;
                //    break;
                case "profile":
                    selectedIndex = 3;
                    navService.Navigate<Users.OverviewPage>(
                    new FrameNavigationArgs()
                    {
                        Login = App.Settings.SignedInUserName,
                    });
                    break;
            }

            for (int index = 0; index <= 3; index++)
            {
                if (index == selectedIndex)
                    continue;

                if (index <= 2)
                    ViewModel.NavViewItems[index].IsSelected = false;

                if (selectedIndex != 3)
                    ViewModel.NavViewFooterItems[0].IsSelected = false;
            }
        }
        #endregion
    }
}
