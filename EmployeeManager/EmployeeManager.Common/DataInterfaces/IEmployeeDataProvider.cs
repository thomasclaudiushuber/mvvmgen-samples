// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using System.Collections.Generic;
using EmployeeManager.Common.Model;

namespace EmployeeManager.Common.DataInterfaces
{
    public interface IEmployeeDataProvider
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int employeeId);
        void Save(Employee model);
    }
}
