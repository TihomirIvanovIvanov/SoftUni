using System.Collections.Generic;

namespace P04_Hospital
{
    public class Department
    {
        private string name;

        private List<Room> rooms;

        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }
    }
}