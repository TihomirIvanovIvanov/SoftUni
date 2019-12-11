namespace Chronometer
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class Chronometer : IChronometer
    {
        private long miliSeconds;

        private bool isRunning;

        public Chronometer()
        {
            this.Reset();
        }

        public string GetTime => $"{this.miliSeconds / 60000:D2}:{this.miliSeconds / 1000:D2}:{this.miliSeconds % 1000:D4}";

        public List<string> Laps { get; private set; }

        public string Lap()
        {
            var lap = this.GetTime;
            this.Laps.Add(lap);
            return lap;
        }

        public void Reset()
        {
            this.Stop();
            this.miliSeconds = 0;
            this.Laps = new List<string>();
        }

        public void Start()
        {
            this.isRunning = true;

            Task.Run(() =>
            {
                while (this.isRunning)
                {
                    Thread.Sleep(1);
                    this.miliSeconds++;
                }
            });
        }

        public void Stop()
        {
            this.isRunning = false;
        }
    }
}
