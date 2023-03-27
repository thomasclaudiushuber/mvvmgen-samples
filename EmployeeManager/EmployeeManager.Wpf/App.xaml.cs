// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MvvmGen.Events;
using EmployeeManager.Common.DataInterfaces;
using EmployeeManager.Data;
using EmployeeManager.ViewModel;

namespace EmployeeManager.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider? ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IEventAggregator, EventAggregator>();
            serviceCollection.AddTransient<MainWindow>();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<IEmployeeDataProvider, EmployeeFileDataProvider>();
            serviceCollection.AddTransient<INavigationViewModel, NavigationViewModel>();
            serviceCollection.AddTransient<IEmployeeViewModelFactory, EmployeeViewModelFactory>();

            ServiceProvider = serviceCollection.BuildServiceProvider(true);

            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
