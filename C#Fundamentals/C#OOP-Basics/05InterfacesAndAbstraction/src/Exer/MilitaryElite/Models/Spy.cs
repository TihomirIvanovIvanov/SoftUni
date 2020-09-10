﻿namespace MilitaryElite.Models
{
    using Contracts;
    using System.Text;

    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .Append($"Code Number: {this.CodeNumber}");

            return sb.ToString();
        }
    }
}