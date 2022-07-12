using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanEmployee.composite
{
    public class Employee : CompanyEmployee
    {
        EmployeeModel employee;
        IList<CompanyEmployee> report_to;
        public Employee(EmployeeModel employee) 
     {
        this.employee = employee;
        report_to = new List<CompanyEmployee>();
     }
        public void printEmployee()
        {
            foreach (CompanyEmployee emp in report_to)
            {
                EmployeeModel employeeModel = emp.getEmployee();
                Console.WriteLine(employeeModel.getId() + " " + employeeModel.getName() + " " + employeeModel.getPosition());
            }
        }

        public double getDepartmentalBudget()
        {
            double sum = 0.0;
            foreach (CompanyEmployee md in report_to)
            {
                EmployeeModel employeeModel = md.getEmployee();

                sum += employeeModel.getSalary() + md.getDepartmentalBudget();
            }
            return sum;
        }

        public String addRepotee(CompanyEmployee emp)
        {
            if(emp.getEmployee().getRank()!=Rank.EMPLOYEE)//normal employee cannot add a manager or ceo
            {
                return Constants.INVALID_OPERATION_MESSAGE;//
            }
            foreach (CompanyEmployee r in report_to)
            {
                if (r.getEmployee().getId() == emp.getEmployee().getId())//no circular reference
                {
                    return Constants.CIRCULAR_OPERATION_MESSAGE;

                }
            }
            report_to.Add(emp);
            return Constants.SUCCESS;
        }

        public EmployeeModel getEmployee()
        {
            return employee;
        }

        public IList<CompanyEmployee> getRepotee()
        {
            return report_to;
        }
    }
}
