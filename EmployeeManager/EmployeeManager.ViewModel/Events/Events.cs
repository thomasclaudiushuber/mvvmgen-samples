// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

namespace EmployeeManager.ViewModel.Events
{
    public record EmployeeSavedEvent(int EmployeeId, string FirstName);
    public record EmployeeNavigationSelectedEvent(int EmployeeId);
    public record EmployeeTabSelectedEvent(int? EmployeeId);
}
