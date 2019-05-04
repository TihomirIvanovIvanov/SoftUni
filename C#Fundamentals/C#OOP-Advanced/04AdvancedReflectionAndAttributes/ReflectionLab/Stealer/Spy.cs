using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    private StringBuilder sb;

    public Spy()
    {
        this.sb = new StringBuilder();
    }

    public string StealFieldInfo(string investigatedClass, params string[] requaredFields)
    {
        var classType = Type.GetType(investigatedClass);

        var classFields = classType.GetFields
            (BindingFlags.Instance |
             BindingFlags.Static |
             BindingFlags.NonPublic |
             BindingFlags.Public);

        var classInstance = Activator.CreateInstance(classType, new object[] { });
        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var field in classFields.Where(f => requaredFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }
}