using System;

public class Person
{
    private const int MinNameLenght = 3;
    private const double MinSalary = 460.0;
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age, double salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value.Length < MinNameLenght)
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value.Length < MinNameLenght)
            {
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }
            this.lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or negative integer");
            }

            this.age = value;
        }
    }

    public double Salary
    {
        get { return this.salary; }
        set
        {
            if (value < MinSalary)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva");
            }

            this.salary = value;
        }
    }
}