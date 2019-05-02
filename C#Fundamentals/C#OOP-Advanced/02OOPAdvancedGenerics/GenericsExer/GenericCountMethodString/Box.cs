﻿namespace GenericCountMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
        where T : IComparable<T>
    {
        public Box(List<T> items)
        {
            this.Items = items;
        }

        public List<T> Items { get; }

        public int GetGreaterThan(T inputItem)
        {
            var count = 0;

            foreach (var item in this.Items)
            {
                if (item.CompareTo(inputItem) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}