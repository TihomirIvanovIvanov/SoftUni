namespace DatabaseExtended
{
    using System;
    using System.Linq;

    public class Database : IDatabase<IPerson>
    {
        private int MaxCapacity = 16;

        private readonly IPerson[] data;
        private int currentIndex;

        public Database()
        {
            this.data = new IPerson[MaxCapacity];
            this.currentIndex = 0;
        }

        public Database(params IPerson[] inputElements)
            : this()
        {
            this.InitializeElements(inputElements);
        }

        private void InitializeElements(IPerson[] inputElements)
        {
            try
            {
                Array.Copy(inputElements, this.data, inputElements.Length);
                this.currentIndex = inputElements.Length;

            }
            catch (AggregateException ae)
            {
                throw new InvalidOperationException("Array is full!", ae);
            }
        }

        public int CurrentIndex
        {
            get => this.currentIndex;
            private set
            {
                if (value <= 0 || value >= this.data.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                this.currentIndex = value;
            }
        }

        public void AddPerson(IPerson element)
        {
            if (this.currentIndex >= MaxCapacity)
            {
                throw new InvalidOperationException("Array is full!");
            }

            if (this.data.Take(this.currentIndex).Any(p => p.Equals(element)))
            {
                throw new InvalidOperationException("There is already person with with same Username and Id");
            }

            this.data[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }

            this.currentIndex--;
            this.data[this.currentIndex] = default(IPerson);
        }

        public IPerson FindByUsername(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (this.data.Take(this.currentIndex).All(p => p.Username != name))
            {
                throw new InvalidOperationException($"No person with Username{name}.");
            }

            var searchedPerson = this.data.FirstOrDefault(p => p.Username == name);
            if (searchedPerson == null)
            {
                throw new ArgumentNullException("No person with Username.");
            }

            return searchedPerson;
        }

        public IPerson FindById(long id)
        {
            var searchedPerson = this.data.Take(this.currentIndex).FirstOrDefault(p => p.Id == id);

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (searchedPerson == null)
            {
                throw new InvalidOperationException("No person with this Id.");
            }

            return searchedPerson;
        }

        public IPerson[] Fetch()
        {
            var newArray = new IPerson[this.currentIndex];
            Array.Copy(this.data, newArray, this.currentIndex);

            return newArray;
        }
    }
}
