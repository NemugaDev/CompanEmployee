using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanEmployee.composite
{
    /**
     * Composite Design Pattern
     * 
     * To be implmented by each employee in the Company
     * */
    public interface CompanyEmployee
    {
        void printEmployee();
        double getDepartmentalBudget();
        String  addRepotee(CompanyEmployee emp);
        EmployeeModel getEmployee();
        IList<CompanyEmployee> getRepotee();
    }
}
