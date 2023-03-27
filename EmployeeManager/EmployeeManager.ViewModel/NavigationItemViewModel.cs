// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using MvvmGen;

namespace EmployeeManager.ViewModel
{
    [ViewModel]
    public partial class NavigationItemViewModel
    {
        [Property] int _id;
        [Property] string? _firstName;
    }
}
