namespace Employees.Services
{
    using AutoMapper;
    using Employees.Data;
    using Employees.DtoModels;

    public class EmloyeeService
    {
        private readonly EmployeeContext context;

        public EmloyeeService(EmployeeContext context)
        {
            this.context = context;
        }

        public EmployeeDto ById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }
    }
}
