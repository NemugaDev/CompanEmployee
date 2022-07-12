using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CompanEmployee.composite
{
    public class CsvData
    {
        String employee_name;
        double salary;
        int employee_id;
      
        String level;
        Rank rank;

        public CsvData() { }

        public CsvData(String employee_name, double salary, int employee_id,  String level, Rank rank)
        {
        this.employee_name = employee_name;
        this.salary = salary;
        this.employee_id = employee_id;
      
        this.level = level;
        this.rank = rank;
    }

    public String getEmployee_name() {
        return employee_name;
    }

    public double getSalary() {
        return salary;
    }

    public int getEmployee_id() {
        return employee_id;
    }

   

    public String getLevel() {
        return level;
    }
    public Rank getRank()
    {
        return rank;
    }
    }
}
