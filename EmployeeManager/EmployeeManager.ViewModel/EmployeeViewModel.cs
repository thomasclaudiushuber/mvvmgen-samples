// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using MvvmGen;
using MvvmGen.Events;
using EmployeeManager.Common.DataInterfaces;
using EmployeeManager.Common.Model;
using EmployeeManager.ViewModel.Events;

namespace EmployeeManager.ViewModel
{
    [Inject(typeof(IEmployeeDataProvider))]
    [Inject(typeof(IEventAggregator))]
    [ViewModelGenerateInterface]
    [ViewModelGenerateFactory]
    [ViewModel(typeof(Employee))]
    public partial class EmployeeViewModel
    {
        [Property]
        private string? _updateComment;

        [Command(CanExecuteMethod = nameof(CanSave))]
        public void Save()
        {
            EmployeeDataProvider.Save(Model);
            EventAggregator.Publish(new EmployeeSavedEvent(Model.Id, Model.FirstName!));
        }

        [CommandInvalidate(nameof(FirstName))]
        public bool CanSave()
        {
            return !string.IsNullOrEmpty(FirstName);
        }

        public void Load(int employeeId)
        {
            Model = EmployeeDataProvider.GetById(employeeId);
        }
    }
}
