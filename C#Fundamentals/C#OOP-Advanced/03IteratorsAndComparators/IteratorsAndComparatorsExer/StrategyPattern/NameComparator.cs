namespace StrategyPattern
{
    using System.Collections.Generic;

    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            var result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

            if (result == 0)
            {
                var firstPersonFirstLetter = char.ToLower(firstPerson.Name[0]);
                var secondPersonFirstLetter = char.ToLower(secondPerson.Name[0]);

                result = firstPersonFirstLetter.CompareTo(secondPersonFirstLetter);
            }

            return result;
        }
    }
}
