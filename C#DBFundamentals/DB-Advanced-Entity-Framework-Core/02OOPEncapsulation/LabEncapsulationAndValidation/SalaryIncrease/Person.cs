public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public string FirstName
    {
        get { return this.firstName; }
    }
    public string LastName
    {
        get { return this.lastName; }
    }
    public int Age
    {
        get { return this.age; }
    }
    public double Salary
    {
        get { return this.salary; }
        private set { this.salary = value; }
    }

    public Person(string firstName, string lastName, int age, double salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }
    public void IncreaseSalary(double percent)
    {
        if (this.age < 30)
        {
            percent /= 2;
        }
        else
        {
            this.Salary += this.Salary * percent / 100;
        }
    }
    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {this.salary:F2} leva";
    }
}