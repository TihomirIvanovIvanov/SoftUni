﻿using System;
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

        var fields = classType.GetFields
            (BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        var instance = Activator.CreateInstance(classType, new object[] { });
        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var field in fields.Where(f => requaredFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string investigatedClass)
    {
        var classType = Type.GetType(investigatedClass);

        var fields = classType.GetFields
            (BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        var publicMethods = classType.GetMethods
            (BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        var nonPunblicMethods = classType.GetMethods
            (BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in nonPunblicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        var classType = Type.GetType(investigatedClass);

        var nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in nonPublicMethods)
        {
            sb.AppendLine($"{method.Name}");
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        var classType = Type.GetType(investigatedClass);

        var methods = classType.GetMethods
            (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}