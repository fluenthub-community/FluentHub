﻿using FluentHub.Services.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using muxc = Microsoft.UI.Xaml.Controls;

namespace FluentHub.UserControls.TabViewControl
{
    public sealed partial class CustomTabView : UserControl, ITabView
    {
        #region constructor
        public CustomTabView()
        {
            InitializeComponent();
            _items = new ObservableCollection<ITabItemView>();
            Items = new ReadOnlyObservableCollection<ITabItemView>(_items);
        }
        #endregion

        #region fields
        private readonly ObservableCollection<ITabItemView> _items;
        #endregion

        #region properties
        public ITabItemView SelectedItem
        {
            get => MainTabView.SelectedItem as ITabItemView;
            set => MainTabView.SelectedItem = value;
        }

        public ReadOnlyObservableCollection<ITabItemView> Items { get; }
        #endregion

        #region public methods
        public ITabItemView OpenTab(Type page, object parameter = null, bool setAsSelected = true)
        {
            var item = new TabItem
            {
                Guid = Guid.NewGuid(),
                CurrentPage = page,
                Parameter = parameter,
                IconSource = new muxc.FontIconSource
                {
                    Glyph = "\uE737"
                }
            };
            _items.Add(item);
            if (setAsSelected)
            {
                MainTabView.SelectedItem = item;
            }
            return item;
        }

        public bool CloseTab(ITabItemView tabItem) => tabItem is not null && CloseTab(_items.IndexOf(tabItem));

        public bool CloseTab(Guid guid) => CloseTab(_items.FirstOrDefault(x => x.Guid == guid));

        public bool CloseTab(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                int newSelectedItemIndex = -1;

                if (index == MainTabView.SelectedIndex) // Removing the current tab
                {
                    if (index == _items.Count - 1) // Select the previous tab if the current item is the last tab
                    {
                        newSelectedItemIndex = index - 1;
                    }
                    else // Select the next tab
                    {
                        newSelectedItemIndex = index;
                    }
                }

                _items.RemoveAt(index);

                if (_items.Count == 0)
                {
                    App.CloseApp();
                }

                if (newSelectedItemIndex >= 0)
                {
                    MainTabView.SelectedIndex = newSelectedItemIndex;
                }
                return true;
            }
            return false;
        }
        #endregion

        #region event handlers        
        private void OnMainTabViewSelectionChanged(object sender, SelectionChangedEventArgs e) => SelectionChanged?.Invoke(this, e);

        private void OnMainTabViewTabCloseRequested(muxc.TabView sender, muxc.TabViewTabCloseRequestedEventArgs args) => CloseTab(args.Item as ITabItemView);

        private void OnMainTabViewLoaded(object sender, RoutedEventArgs e)
        {
            /*
            MainPageViewModel.AddNewTabByPath($"/{App.SignedInUserName}");
            App.MainViewModel.MainFrame.Navigate(typeof(UserHomePage));
            var iconSource = new muxc.FontIconSource();
            iconSource.Glyph = "\uE737";
            App.MainViewModel.MainTabItems[App.MainViewModel.SelectedTabIndex].IconSource = iconSource;
            App.MainViewModel.MainTabItems[App.MainViewModel.SelectedTabIndex].Header = "FluentHub";*/
        }



        private void AddNewTabButton_Click(object sender, RoutedEventArgs e)
        {
            OpenTab(null, null, true);
            //TabItemAdding = true;
            /*
            MainPageViewModel.AddNewTabByPath($"/{App.SignedInUserName}");
            App.MainViewModel.MainFrame.Navigate(typeof(UserHomePage));
            App.MainViewModel.SelectedTabIndex = MainTabView.SelectedIndex = App.MainViewModel.MainTabItems.Count() - 1;*/
        }
        #endregion

        #region events       
        public event SelectionChangedEventHandler SelectionChanged;
        #endregion
    }
}
