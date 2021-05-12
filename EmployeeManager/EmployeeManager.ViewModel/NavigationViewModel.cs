// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using System.Collections.ObjectModel;
using System.Linq;
using MvvmGen;
using MvvmGen.Events;
using EmployeeManager.Common.DataInterfaces;
using EmployeeManager.ViewModel.Events;

namespace EmployeeManager.ViewModel
{
    [Inject(typeof(IEmployeeDataProvider))]
    [Inject(typeof(IEventAggregator))]
    [ViewModel]
    public partial class NavigationViewModel : IEventSubscriber<EmployeeSavedEvent, EmployeeTabSelectedEvent>
    {
        [PropertyPublishEvent(typeof(EmployeeNavigationSelectedEvent),
            EventConstructorArgs = "value.Id",
            PublishCondition = "value is not null")]
        [Property]
        private NavigationItemViewModel? _selectedItem;

        public void Load()
        {

            Items.Clear();
            foreach (var employee in EmployeeDataProvider.GetAll())
            {
                Items.Add(new NavigationItemViewModel { Id = employee.Id, FirstName = employee.FirstName });
            }
        }

        public void OnEvent(EmployeeSavedEvent eventData)
        {
            var item = Items.SingleOrDefault(x => x.Id == eventData.EmployeeId);
            if (item == null)
            {
                Items.Add(new NavigationItemViewModel { Id = eventData.EmployeeId, FirstName = eventData.FirstName });
            }
            else
            {
                item.FirstName = eventData.FirstName;
            }
        }

        public void OnEvent(EmployeeTabSelectedEvent eventData)
        {
            SelectedItem = Items.SingleOrDefault(x => x.Id == eventData.EmployeeId);
        }

        public ObservableCollection<NavigationItemViewModel> Items { get; } = new();
    }
}
