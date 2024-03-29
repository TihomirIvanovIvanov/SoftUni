﻿namespace Employee.App
{
    using AutoMapper;

    using Employees.Models;
    using Employees.DtoModels;

    class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
