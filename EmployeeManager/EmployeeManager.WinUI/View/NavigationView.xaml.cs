// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using Microsoft.UI.Xaml.Controls;
using EmployeeManager.ViewModel;

namespace EmployeeManager.WinUI.View
{
    public partial class NavigationView : UserControl
    {
        public NavigationView()
        {
            InitializeComponent();
        }

        public INavigationViewModel? ViewModel { get; set; }
    }
}
