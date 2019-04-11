namespace Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private decimal workSalary;
        private decimal workingHoursPerDay;

        public Worker(string firstName, string lastName, decimal workSalary, decimal workingHoursPerDay)
            : base(firstName, lastName)
        {
            this.WorkSalary = workSalary;
            this.WorkingHoursPerDay = workingHoursPerDay;
        }

        public decimal WorkSalary
        {
            get => workSalary;
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                workSalary = value;
            }
        }

        public decimal WorkingHoursPerDay
        {
            get => workingHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                workingHoursPerDay = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Week Salary: {this.WorkSalary:F2}");
            sb.AppendLine($"Hours per day: {this.WorkingHoursPerDay:F2}");
            sb.AppendLine($"Salary per hour: {CalculateSalaryPerHour():F2}");

            return sb.ToString().TrimEnd();
        }

        private decimal CalculateSalaryPerHour()
        {
            return this.workSalary / (5m * this.WorkingHoursPerDay);
        }
    }
}