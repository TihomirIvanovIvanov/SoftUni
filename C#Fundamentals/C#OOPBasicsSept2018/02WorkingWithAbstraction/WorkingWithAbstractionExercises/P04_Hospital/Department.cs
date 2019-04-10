namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Department
    {
        private string name;
        private List<Room> rooms;

        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public List<Room> Rooms
        {
            get => this.rooms;
            set => this.rooms = value;
        }
    }
}