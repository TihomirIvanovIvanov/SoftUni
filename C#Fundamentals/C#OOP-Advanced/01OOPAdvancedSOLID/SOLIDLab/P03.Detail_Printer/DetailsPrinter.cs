namespace P03.DetailPrinter
{
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintEmployees()
        {
            foreach (var employee in this.employees)
            {
                System.Console.WriteLine(employee);
            }
        }
    }
}