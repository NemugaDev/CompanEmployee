using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanEmployee.composite
{
    public class EmployeeModel
    {
        private int id;
        private String name;
        private double salary;
        private String position;
        private Rank rank;

        public EmployeeModel(int id, String name, double salary, String position,Rank rank)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.rank = rank;
        }
     

        public int getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }

        public double getSalary()
        {
            return salary;
        }

        public String getPosition()
        {
            return position;
        }

        public Rank getRank()
        {
            return rank;
        }
    }
}
