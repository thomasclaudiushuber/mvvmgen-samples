// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmGen;
using MvvmGen.Events;
using EmployeeManager.ViewModel.Events;

namespace EmployeeManager.ViewModel
{
    [Inject(typeof(IEmployeeViewModelFactory))]
    [Inject(typeof(NavigationViewModel), PropertyAccessModifier = AccessModifier.Public)]
    [Inject(typeof(IEventAggregator))]
    [ViewModel]
    public partial class MainViewModel : IEventSubscriber<EmployeeNavigationSelectedEvent>
    {
        public async void OnEvent(EmployeeNavigationSelectedEvent eventData)
        {
            var employeeViewModel = EmployeeViewModels.SingleOrDefault(x => x.Id == eventData.EmployeeId);
            if (employeeViewModel is null)
            {
                employeeViewModel = EmployeeViewModelFactory.Create();
                employeeViewModel.Load(eventData.EmployeeId);
                EmployeeViewModels.Add(employeeViewModel);
                await Task.Delay(1); // Little hack for WinUI TabView. If this is not here, WinUI won't select the tab,
                                     // as next statement is setting the SelectedEmployee property
            }

            SelectedEmployee = employeeViewModel;
        }

        public void Load()
        {
            NavigationViewModel.Load();
        }

        public ObservableCollection<EmployeeViewModel> EmployeeViewModels { get; } = new();

        [PropertyPublishEvent(typeof(EmployeeTabSelectedEvent),
            EventConstructorArgs = "_selectedEmployee?.Id")]
        [Property]
        private EmployeeViewModel _selectedEmployee;

        [Command]
        private void TabClose(object parameter)
        {
            if (parameter is EmployeeViewModel employeeViewModel)
            {
                EmployeeViewModels.Remove(employeeViewModel);
            }
        }
    }
}
