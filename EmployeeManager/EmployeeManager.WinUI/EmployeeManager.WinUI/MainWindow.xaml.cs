// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using EmployeeManager.ViewModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace EmployeeManager.WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
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
