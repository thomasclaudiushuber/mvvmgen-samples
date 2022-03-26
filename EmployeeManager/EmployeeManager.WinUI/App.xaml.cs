using EmployeeManager.Common.DataInterfaces;
using EmployeeManager.Data;
using EmployeeManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using MvvmGen.Events;

namespace EmployeeManager.WinUI
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

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
