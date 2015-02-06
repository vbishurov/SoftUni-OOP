namespace AsynchronousTimer
{
    using System;
    using System.Threading;

    public class AsyncTimer
    {
        private int ticks;
        private int timeInterval;

        public AsyncTimer(Action tick, int ticks, int timeInterval)
        {
            this.Tick = tick;
            this.Ticks = ticks;
            this.TimeInterval = timeInterval;
            this.OnTick(EventArgs.Empty);
        }

        public int TimeInterval
        {
            get
            {
                return this.timeInterval;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("TimeInterval", "TimeInterval cannot be negative");
                }

                this.timeInterval = value;
            }
        }

        public int Ticks
        {
            get
            {
                return this.ticks;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ticks", "Ticks cannot be negative");
                }

                this.ticks = value;
            }
        }

        public Action Tick { get; private set; }

        public void OnTick(EventArgs e)
        {
            if (this.Tick != null)
            {
                Thread newThread = new Thread(() =>
                {
                    int ticksCount = 0;
                    while (ticksCount < this.ticks)
                    {
                        this.Tick();
                        ticksCount++;
                        Thread.Sleep(this.TimeInterval);
                    }
                });

                newThread.Start();
            }
        }
    }
}
