using Lab_2_Inheritance.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_2_Inheritance
{
    internal class Program
    {
        static void Main()
        {
            List<Employee> Employees = new List<Employee>();

            string Source = "employees.txt";

            string[] Lines = File.ReadAllLines(@Source);

            foreach (string Line in Lines)
            {
                string[] Cell = Line.Split(':');

                string ID = Cell[0], Name = Cell[1], Address = Cell[2];

                string F_Digit = ID.Substring(0, 1);

                int INT_F_Digit = int.Parse(F_Digit);

                if (INT_F_Digit >= 0 && INT_F_Digit <= 4)

                {

                    string Salary = Cell[7];
                    double DOUBLE_Salary = double.Parse(Salary);

                    Salaried salaried = new Salaried(ID, Name, Address, DOUBLE_Salary);
                    Employees.Add(salaried);
                }

                else if (INT_F_Digit >= 5 && INT_F_Digit <= 7)

                {

                    string Rate = Cell[7], Hours = Cell[8];

                    double DOUBLE_Rate = double.Parse(Rate), DOUBLE_Hours = double.Parse(Hours);

                    Wages Wage = new Wages(ID, Name, Address, DOUBLE_Rate, DOUBLE_Hours);

                    Employees.Add(Wage);
                }

                else if (INT_F_Digit >= 8 && INT_F_Digit <= 9)

                {

                    string Rate = Cell[7], Hours = Cell[8];

                    double DOUBLE_Rate = double.Parse(Rate), DOUBLE_Hours = double.Parse(Hours);

                    PartTime PT = new PartTime(ID, Name, Address, DOUBLE_Rate, DOUBLE_Hours);

                    Employees.Add(PT);

                }

            }

            double WeeklyPaySum = 0;

            foreach (Employee EMP in Employees)

            {

                double weeklypay = EMP.CalcWeeklyPay();

                WeeklyPaySum += weeklypay;

            }

            double AverWeeklyPay = WeeklyPaySum / Employees.Count;

            Console.WriteLine($"Average Weekly Pay: ${AverWeeklyPay.ToString("n2")} \n"); 

            Wages HighestPaidWage = null;

            foreach (Employee EMP in Employees)

            {

                if (EMP is Wages Wage)

                {

                    if (HighestPaidWage == null || Wage.CalcWeeklyPay() > HighestPaidWage.CalcWeeklyPay())
                    
                    {

                        HighestPaidWage = Wage;

                    }
                }
            }

            Console.WriteLine($"Highest Waged Employee: {HighestPaidWage.Name} \nHighest Waged Pay: ${HighestPaidWage.CalcWeeklyPay():n2} \n ");

            Salaried LowestPaidWage = null;

            foreach (Employee EMP in Employees)
            {
                if (EMP is Salaried salaried)
                {
                    if (LowestPaidWage == null || salaried.CalcWeeklyPay() < LowestPaidWage.CalcWeeklyPay())
                    {
                        LowestPaidWage = salaried;
                    }

                }

            }
            
            Console.WriteLine($"Lowest Salaried Employee: {LowestPaidWage.Name} \nLowest Waged Pay: ${LowestPaidWage.CalcWeeklyPay():n2} \n ");

            double PerSalary = 0, EMP_Sal_Count = 0;

            foreach (Employee EMP in Employees)

            {

                if (EMP is Salaried)

                {

                    EMP_Sal_Count += 1;

                }

                PerSalary = (EMP_Sal_Count / Employees.Count) * 100;

            }

            Console.WriteLine($"Salaried: {EMP_Sal_Count}/{Employees.Count} ({Math.Round(PerSalary, 2)}%)");


            double PerWages = 0, EMP_Wage_Count = 0;

            foreach (Employee EMP in Employees)

            {

                if (EMP is Wages)

                {

                    EMP_Wage_Count += 1;

                }

                PerWages = (EMP_Wage_Count / Employees.Count) * 100;

            }

            Console.WriteLine($"Waged: {EMP_Wage_Count}/{Employees.Count} ({Math.Round(PerWages, 2)}%)");

            double Per_PT = 0, PT_EMP_Count = 0;

            foreach (Employee EMP in Employees)

            {

                if (EMP is PartTime)

                {

                    PT_EMP_Count += 1;

                }

                Per_PT = (PT_EMP_Count / Employees.Count) * 100;

            }

            Console.WriteLine($"Part Time: {PT_EMP_Count}/{Employees.Count} ({Math.Round(Per_PT, 2)}%)");
        }
    }
}