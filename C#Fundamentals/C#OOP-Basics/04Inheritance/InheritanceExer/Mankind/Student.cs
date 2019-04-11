namespace Mankind
{
    using System;
    using System.Linq;
    using System.Text;

    public class Student : Human
    {
        private string facNum;

        public Student(string firstName, string lastName, string facNum)
            : base(firstName, lastName)
        {
            this.FacNum = facNum;
        }

        public string FacNum
        {
            get => facNum;
            set
            {
                if (!value.All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                facNum = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Faculty number: {facNum}");

            return sb.ToString();
        }
    }
}