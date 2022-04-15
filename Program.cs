using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
   internal class Program
    {
        static void Main(string[] args)
        {
            string pathToIcoFile = AppDomain.CurrentDomain.BaseDirectory + ("companies_data.csv");

            var csvData = File.ReadAllLines(pathToIcoFile);

            var employeesFileCSV = GetEmployeesFileCSV(csvData);

            var companyEmployees = employeesFileCSV.GroupBy(e => e.CompanyName).ToList();

            foreach (var companyEmpl in companyEmployees)
            {
                var sortedCompanyEmpl = companyEmpl.OrderBy(e => e.Idref).ToList();
                for(int x = 0; x < sortedCompanyEmpl.Count; x++)
                {
                    PrintRelatedEmployees(sortedCompanyEmpl, sortedCompanyEmpl[x]);
                }
                Console.WriteLine();
            }
            List<Employee> GetEmployeesFileCSV(string[] csvLines)
            {
                var employees = new List<Employee>();
                foreach (var csvLine in csvLines)
                {
                    var dataEmployee = csvLine.Split(',');
                    Employee emp = CreateEmployee(dataEmployee);
                    employees.Add(emp);
                }
                return employees;
            }
              Employee CreateEmployee(string[] dataEmployee)
            {
                return new Employee()
                {
                    Id = int.Parse(dataEmployee[0]),
                    Idref = int.Parse(dataEmployee[1]),
                    Name = dataEmployee[2],
                    Lastname = dataEmployee[3],
                    CompanyName = dataEmployee[4],
                    Position = dataEmployee[6],

                };
            }
            void PrintRelatedEmployees(List<Employee> sortedCompanyEmpl, Employee employee, int iteraction = 0)
            {
               if(iteraction > 0)
                {
                    for(int i= 0; i < iteraction; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("->");
                }
                Console.Write($"{employee.Id}, {employee.Idref}, {employee.FullName}, {employee.CompanyName}, {employee.Position}\n");
                var relatedEmplyees = sortedCompanyEmpl.Where(e => e.Idref == employee.Id).ToList();
                sortedCompanyEmpl.Remove(employee);
                if(relatedEmplyees.Count > 0)
                {
                    iteraction++;
                    foreach (var relatedEmployees in relatedEmplyees)
                    {
                        PrintRelatedEmployees(sortedCompanyEmpl, relatedEmployees, iteraction);
                    }
                }
            }
        }
    }
}
