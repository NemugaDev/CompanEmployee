using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanEmployee.composite
{
    public class Ceo : CompanyEmployee
    {
        IList<CompanyEmployee> all_managers;
        int manager_id;
        EmployeeModel ceo;

        public Ceo( EmployeeModel ceo)
        {
            all_managers = new List<CompanyEmployee>();
         
            this.ceo = ceo;
        }
        public Ceo(int manager_id, EmployeeModel ceo)
    {
        all_managers = new List<CompanyEmployee>();
        this.manager_id=manager_id;
        this.ceo=ceo;
    }
        public void printEmployee()
        {
            throw new NotImplementedException();
        }

        public double getDepartmentalBudget()
        {
                   double budget=0.0;
        foreach(CompanyEmployee m in all_managers)
        {
         
            if(m.getEmployee().getId()==manager_id)
            {
                m.printEmployee();
               budget=m.getDepartmentalBudget()+m.getEmployee().getSalary(); 
            }
   
        }
        return budget;
        }

        public String addRepotee(CompanyEmployee emp)
        {
          
           all_managers.Add(emp);
           return Constants.SUCCESS;
        }

        public EmployeeModel getEmployee()
        {
            return ceo;
        }

        /**
         * prevent employee from existing in more than one
         * department
         * */
        public String isEmployeeAlreadyInAnotherDepartment(CompanyEmployee emp)
        {
            foreach (CompanyEmployee m in all_managers)
            {
                IList<CompanyEmployee> reportee = m.getRepotee();//all employee under manager
                foreach (CompanyEmployee m1 in reportee)
                {
                    if (m1.getEmployee().getId() == emp.getEmployee().getId())
                    {
                        return "exist";
                    }
                }

                

            }
            return "ok";
        }

        public IList<CompanyEmployee> getRepotee()
        {
            return all_managers;
        }
    }
}
