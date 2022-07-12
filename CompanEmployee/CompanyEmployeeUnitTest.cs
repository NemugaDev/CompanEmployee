using CompanEmployee.composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanEmployee
{
    [TestClass]
    public class CompanyEmployeeUnitTest
    {
        [TestMethod]
         public void CanEmployeeAddASeniorLevelPerson()
        {
            Employee emp4 = new Employee(new EmployeeModel(4, "Emp 4", 500, "Software Developer",Rank.EMPLOYEE));
            Manager manager = new Manager(new EmployeeModel(2, "Emp 2", 800, "Receptionist", Rank.MANAGER));
            Employee emp2 = new Employee(new EmployeeModel(2, "Emp 2", 800, "Receptionist", Rank.EMPLOYEE));
            String response = manager.addRepotee(emp2);
            Assert.AreEqual(response,Constants.SUCCESS);
         }

        [TestMethod]
        public void CanManagerAddCeo()
        {
            Manager manager = new Manager(new EmployeeModel(2, "Emp 2", 800, "Receptionist", Rank.MANAGER));
           
            Ceo ceo = new Ceo(new EmployeeModel(2, "Emp 2", 800, "Receptionist", Rank.CEO));

            String response = ceo.addRepotee(manager);
            Assert.AreEqual(response, Constants.SUCCESS);


        }

        [TestMethod]
        public void DoesDeparmentalBudgetEqualsAllManagerEmployeeHireachy()
        {
            int manager_id = 1;
            Employee emp4 = new Employee(new EmployeeModel(4, "Emp 4", 500, "Software Developer", Rank.EMPLOYEE));
            Employee emp6 = new Employee(new EmployeeModel(6, "Emp 6", 500, "Quality Assurance", Rank.EMPLOYEE));

            Employee emp2 = new Employee(new EmployeeModel(2, "Emp 2", 800, "Receptionist", Rank.EMPLOYEE));

            //other employee can report to another employee
            Employee emp3 = new Employee(new EmployeeModel(3, "Emp 3", 500, "Data Analyst", Rank.EMPLOYEE));
            emp3.addRepotee(emp2);
            emp3.addRepotee(emp4);

            Employee emp5 = new Employee(new EmployeeModel(5, "Emp 5", 500, "Call Center", Rank.EMPLOYEE));
            
            //a manager is an employee
            Manager manager1 = new Manager(new EmployeeModel(manager_id, "John Doe", 1000, "Developer Department", Rank.MANAGER));
            manager1.addRepotee(emp5);

            /**
             * employee 2 and employee 4 belong to same department so their
             * salary should be inclusive that of department
             * */
            manager1.addRepotee(emp3);
            manager1.addRepotee(emp6);
            double expected_departmental_budget = 3800;

            Ceo ceo = new Ceo(1, new EmployeeModel(manager_id, "Ceo Name", 1000, "CEO", Rank.CEO));
            //manager report to ceo
            ceo.addRepotee(manager1);
            double departmental_budget = ceo.getDepartmentalBudget();

            Assert.AreEqual(expected_departmental_budget, departmental_budget);


        }

        [TestMethod]
        public void checkIfEmployeeExistInAnotherDepartment()
        {
            int manager_id = 1;
          

            Employee emp5 = new Employee(new EmployeeModel(5, "Emp 5", 500, "Call Center", Rank.EMPLOYEE));

            //a manager is an employee
            Manager manager1 = new Manager(new EmployeeModel(manager_id, "John Doe", 1000, "Developer Department", Rank.MANAGER));
            manager1.addRepotee(emp5);

           
          

            Manager manager2 = new Manager(new EmployeeModel(manager_id, "John Doe", 1000, "Developer Department", Rank.MANAGER));
            manager2.addRepotee(emp5);
          

            Ceo ceo = new Ceo(1, new EmployeeModel(manager_id, "Ceo Name", 1000, "CEO", Rank.CEO));
            //manager report to ceo
            ceo.addRepotee(manager1);
            ceo.addRepotee(manager2);
            String exist = ceo.isEmployeeAlreadyInAnotherDepartment(emp5);

            Assert.AreEqual(exist, "exist");


        }

        [TestMethod]
        public void checkIfCompanyHasOneCEO()
        {
            String csv = "4,2,500,5,3,1800,6,,3500,8,9,1400,21,,4580";//this would fail because of double entry of ,,
            CSVReader csvreader = new CSVReader(csv);
            csvreader.in_it_csv();
            String is_one_ceo = csvreader.validateForOneCEO();
            Assert.AreEqual(is_one_ceo, Constants.SUCCESS);
        }

        [TestMethod]
        public void validateSalary()
        {
            String csv = "4,2,500,5,3,1800,6,,3500,8,9,-1400,21,,4580";//this would fail because of -1400 
            CSVReader csvreader = new CSVReader(csv);
            String is_salary_valid=csvreader.in_it_csv();

            Assert.AreEqual(is_salary_valid, Constants.SUCCESS);
        }
    }
}
