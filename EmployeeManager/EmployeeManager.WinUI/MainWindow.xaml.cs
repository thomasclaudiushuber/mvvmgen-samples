// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using EmployeeManager.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace EmployeeManager.WinUI
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            this.InitializeComponent();
            ViewModel = viewModel;
            _root.DataContext = ViewModel;
            _root.Loaded += Grid_Loaded;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Load();
        }

        public MainViewModel ViewModel { get; }

        private void TabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            ViewModel.TabCloseCommand.Execute(args.Item);
        }
    }
}
