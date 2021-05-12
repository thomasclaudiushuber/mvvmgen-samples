// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using MvvmGen.Events;
using EmployeeManager.Common.DataInterfaces;
using EmployeeManager.Data;
using EmployeeManager.ViewModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace EmployeeManager.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IEventAggregator, EventAggregator>();
            serviceCollection.AddTransient<MainWindow>();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<IEmployeeDataProvider, EmployeeFileDataProvider>();
            serviceCollection.AddTransient<NavigationViewModel>();
            serviceCollection.AddTransient<IEmployeeViewModelFactory, EmployeeViewModelFactory>();

            ServiceProvider = serviceCollection.BuildServiceProvider(true);

            m_window = ServiceProvider.GetService<MainWindow>();
            m_window?.Activate();
        }

        public static ServiceProvider? ServiceProvider { get; private set; }

        private Window m_window;
    }
}
