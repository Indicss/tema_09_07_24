using System;

namespace EmployeeManagement
{
    public class Employee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, int id, decimal salary)
        {
            Name = name;
            ID = id;
            Salary = salary;
        }

        public virtual decimal CalculateAnnualSalary()
        {
            return Salary;
        }
    }

    public class FullTimeEmployee : Employee
    {
        public decimal Bonus { get; set; }

        public FullTimeEmployee(string name, int id, decimal salary, decimal bonus)
            : base(name, id, salary)
        {
            Bonus = bonus;
        }

        public override decimal CalculateAnnualSalary()
        {
            return Salary * 12 + Bonus;
        }
    }

    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursPerWeek { get; set; }

        public PartTimeEmployee(string name, int id, decimal hourlyRate, int hoursPerWeek)
            : base(name, id, hourlyRate * hoursPerWeek * 4)
        {
            HourlyRate = hourlyRate;
            HoursPerWeek = hoursPerWeek;
        }

        public override decimal CalculateAnnualSalary()
        {
            return HourlyRate * HoursPerWeek * 52;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FullTimeEmployee fullTimeEmp = new FullTimeEmployee("Oleg", 1, 3000m, 5000m);
            Console.WriteLine($"Full-Time: {fullTimeEmp.Name}, salariu anual: {fullTimeEmp.CalculateAnnualSalary()}");

            PartTimeEmployee partTimeEmp = new PartTimeEmployee("Igor", 2, 20m, 20);
            Console.WriteLine($"Part-Time: {partTimeEmp.Name}, salariu anual: {partTimeEmp.CalculateAnnualSalary()}");
        }
    }
}
