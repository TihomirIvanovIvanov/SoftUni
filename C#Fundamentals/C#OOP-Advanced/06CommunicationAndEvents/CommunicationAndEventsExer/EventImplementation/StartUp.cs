﻿using System;

public class StartUp
{
    public static void Main()
    {
        Dispatcher dispatcher = new Dispatcher();
        Handler handler = new Handler();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string name;
        while ((name = Console.ReadLine()) != "End")
        {
            dispatcher.Name = name;
        }
    }
}