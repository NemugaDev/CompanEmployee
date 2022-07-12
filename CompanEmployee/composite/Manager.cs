using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanEmployee.composite
{
    public class Manager : CompanyEmployee
    {
         EmployeeModel manager;
         IList<CompanyEmployee> report_to;
         public Manager(EmployeeModel manager) {
         this.manager = manager;
        report_to = new List<CompanyEmployee>();
         }
        public void printEmployee()
        {
      foreach(CompanyEmployee md in report_to)
        {
             EmployeeModel employeeModel=md.getEmployee();
             Console.WriteLine(employeeModel.getId() + " " + employeeModel.getName() + " " + employeeModel.getPosition());
            IList<CompanyEmployee> reportee=md.getRepotee();
            if(reportee.Count()>0)
            {
                Console.WriteLine("---------Employee Repotee--------------"); 
            }
            foreach(CompanyEmployee emp in reportee)
            {
                employeeModel=emp.getEmployee();
                Console.WriteLine("          " + employeeModel.getId() + " " + employeeModel.getName() + " " + employeeModel.getPosition()); 
            }
        }
        }
       public double getDepartmentalBudget()
        {
           double sum=0.0;
        foreach(CompanyEmployee md in report_to)
        {
            EmployeeModel employeeModel=md.getEmployee();
         
            sum+=employeeModel.getSalary()+md.getDepartmentalBudget();
        }
        return sum;
        }
      public  String addRepotee(CompanyEmployee emp)
       {
           if (emp.getEmployee().getRank() != Rank.EMPLOYEE)//normal employee cannot add a manager or ceo
           {
               return Constants.INVALID_OPERATION_MESSAGE;
           }
           foreach(CompanyEmployee r in report_to)
          {
              if(r.getEmployee().getId()==emp.getEmployee().getId())//no circular reference
              {
                  return Constants.CIRCULAR_OPERATION_MESSAGE;
       
              }
          }
           report_to.Add(emp);
           return Constants.SUCCESS;
       }
        public EmployeeModel getEmployee()
      {
          return manager;
      }
        public IList<CompanyEmployee> getRepotee()
        {
            return report_to;
        }
    }
}
