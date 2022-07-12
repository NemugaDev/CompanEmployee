using CompanEmployee.composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanEmployee
{
    public class CSVReader
    {
        String csv;
        IList<CsvData> employees;
        public CSVReader(String csv)
        {
            this.csv=csv;
            employees = new List<CsvData>();
            
           
        }
       
       public String validateForOneCEO()
        {
            Boolean ceo_found = false;
           foreach(CsvData data in employees)
           {
               if(data.getRank()==Rank.CEO)
               {
                   if(ceo_found)//if was intitalized before
                   {
                       return Constants.ONE_CEO_ERROR;
                   }
                   ceo_found = true;
               }
           }
           return Constants.SUCCESS;
        }

         public String  in_it_csv()
    {
        csv=csv.Replace("\\s", "");
        csv=csv.Replace(",,", ",11,");//to denote ceo
        String[] chunks = csv.Split(',');
        int x=0;
        String employee_id=null,manager_id=null,salary=null;
        int y = 0;
        foreach(String s in chunks)
        {
            y++;
            if(x==0)
            {
               employee_id=s;
             
            }
             if(x==1)
            {
               manager_id=s;
             
            }
              if(x==2)
            {
               salary=s;
              
            }
              x++;
              
              if(salary!=null&&manager_id!=null&&employee_id!=null)
              {
                  double salary_ = 0.0;
                  try
                  {
                      salary_ = double.Parse(salary);
                  }
                  catch(Exception e)
                  {
                      return Constants.INVALID_EMPLOYEE_SALARY;
                  }

                  if(salary_<=0)
                  {
                      return Constants.INVALID_EMPLOYEE_SALARY;
                      
                  }

                  if (manager_id.Equals("11"))//this is ceo after replacement of ,, with 11
                  {
                      var emp = new CsvData("Emp " + employee_id, salary_, int.Parse(employee_id), "Ceo", Rank.CEO);
                      employees.Add(emp);
                  }
                  else
                  {
                      var emp = new CsvData("Emp " + employee_id, salary_, int.Parse(employee_id), "Software Developer", Rank.EMPLOYEE);
                      employees.Add(emp);
                      emp = new CsvData("Emp " + manager_id, salary_, int.Parse(manager_id), "Department " + y, Rank.MANAGER);
                      employees.Add(emp);
                  }
                 
                 

              }
              if(x==3)
              {
                  
                  x=0;
                  salary=null;
                  manager_id=null;
                  employee_id=null;
              }
           
        }
        return Constants.SUCCESS;
    }

        public void setUpData()
        {
            String []str=csv.Split(',');
            foreach(String s in str)
            {

            }
            var csv_ = new CsvData();
        }

        public Boolean validateSalaries()
        {
            return true;
        }
    }
}
