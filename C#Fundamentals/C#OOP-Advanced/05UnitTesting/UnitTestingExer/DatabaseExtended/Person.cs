namespace DatabaseExtended
{
    using System;

    public class Person : IPerson, IEquatable<IPerson>
    {
        private long id;
        private string username;

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id
        {
            get => this.id;
            private set
            {
                if (this.id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.id));
                }
                this.id = value;
            }
        }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.username));
                }
                this.username = value;
            }
        }

        public bool Equals(IPerson other)
        {
            var result = this.Id == other.Id &&
                this.Username == other.Username;

            return result;
        }
    }
}
