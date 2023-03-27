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
    [Inject(typeof(INavigationViewModel), PropertyAccessModifier = AccessModifier.Public)]
    [Inject(typeof(IEventAggregator))]
    [ViewModel]
    public partial class MainViewModel : IEventSubscriber<EmployeeNavigationSelectedEvent>
    {
        public void OnEvent(EmployeeNavigationSelectedEvent eventData)
        {
            var employeeViewModel = EmployeeViewModels.SingleOrDefault(x => x.Id == eventData.EmployeeId);
            if (employeeViewModel is null)
            {
                employeeViewModel = EmployeeViewModelFactory.Create();
                employeeViewModel.Load(eventData.EmployeeId);
                EmployeeViewModels.Add(employeeViewModel);
            }

            SelectedEmployee = employeeViewModel;
        }

        public void Load()
        {
            NavigationViewModel.Load();
        }

        public ObservableCollection<IEmployeeViewModel> EmployeeViewModels { get; } = new();

        [PropertyPublishEvent(typeof(EmployeeTabSelectedEvent),
            EventConstructorArgs = "_selectedEmployee?.Id")]
        [Property]
        private IEmployeeViewModel _selectedEmployee;

        [Command]
        private void TabClose(object parameter)
        {
            if (parameter is IEmployeeViewModel employeeViewModel)
            {
                EmployeeViewModels.Remove(employeeViewModel);
            }
        }
    }
}
