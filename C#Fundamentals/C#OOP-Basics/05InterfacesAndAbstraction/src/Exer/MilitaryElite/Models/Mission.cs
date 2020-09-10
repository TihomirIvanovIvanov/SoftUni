namespace MilitaryElite.Models
{
    using Enums;
    using Contracts;
    using System;

    public class Mission : IMission
    {
        private MissionState state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get { return this.state.ToString(); }
            private set
            {
                MissionState state;

                if (!Enum.TryParse<MissionState>(value, out state))
                {
                    throw new ArgumentException();
                }
                this.state = state;
            }

        }

        public void CompleteMission()
        {
            this.state = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}