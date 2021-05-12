// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using EmployeeManager.Common.DataInterfaces;
using EmployeeManager.Common.Model;

namespace EmployeeManager.Data
{
    public class EmployeeFileDataProvider : IEmployeeDataProvider
    {
        private readonly string _file = "Employee.json";

        public IEnumerable<Employee> GetAll()
        {
            return ReadFromFile().ToList();
        }

        public Employee GetById(int employeeId)
        {
            var employees = ReadFromFile();
            return employees.Single(x => x.Id == employeeId);
        }

        public void Save(Employee employee)
        {
            var employees = ReadFromFile();
            var existing = employees.Single(f => f.Id == employee.Id);
            var indexOfExisting = employees.IndexOf(existing);
            employees.Insert(indexOfExisting, employee);
            employees.Remove(existing);
            SaveToFile(employees);
        }

        private void SaveToFile(List<Employee> employees)
        {
            var json = JsonSerializer.Serialize(employees);
            File.WriteAllText(_file, json);
        }

        private List<Employee> ReadFromFile()
        {
            if (!File.Exists(_file))
            {
                return new List<Employee>
                  {
                    new Employee{Id= 1, FirstName="Julia",LastName="Developer"},
                    new Employee{Id= 2, FirstName="Anna",LastName="Programmer"},
                    new Employee{Id= 3, FirstName="Thomas Claudius",LastName="Huber"},
                    new Employee{Id= 4, FirstName="Miguel",LastName="Ramos"},
                    new Employee{Id= 5, FirstName="Amanda",LastName="Silver"},
                  };
            }

            var json = File.ReadAllText(_file);
            var list = JsonSerializer.Deserialize<List<Employee>>(json);

            return list ?? new List<Employee>();
        }
    }
}
