using System.ComponentModel;

namespace Stopwatch
{
    public class StopWatch
    {
        private DateTime StartTime = DateTime.Now;
        private DateTime StopTime = DateTime.Now;
        private TimeSpan timeSpan ;
        private bool started = false;
        private bool stopped = true;
        public void StopTimer()
        {
            if (stopped) 
            {
                Console.WriteLine("Stopwatch already stopped");
            }
            else
            {
                stopped = true;
                started = false;
                StopTime = DateTime.Now;
            }
        }
        public void StartTimer()
        {
            if (started)
            {
                Console.WriteLine("Stopwatch already started");
            }
            else
            {
                stopped = false;
                started= true;
                StartTime = DateTime.Now;
            }
            
        }
        public void TimeInterval()
        {
            if (!stopped)
            {
                Console.WriteLine("Please stop stopwatch first");
            }
            else
            {
                timeSpan += StopTime.Subtract(StartTime);
                Console.WriteLine($"Total duration is {timeSpan.Hours} Hours - {timeSpan.Minutes} Mintues - {timeSpan.Seconds} seconds");
            }
        }
    }
    enum Selection
    {
        [Description("To start press 0")] Start,
        [Description("To stop press 1")] Stop,
        [Description("To show interval press 2")] Interval,
        [Description("To exit press 3")] Exit
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            StopWatch watch = new StopWatch();
            Console.WriteLine("To start press 0");
            Console.WriteLine("To stop press 1");
            Console.WriteLine("To show interval press 2");
            Console.WriteLine("To exit press 3");
            while (true)
            {
                var selection = int.TryParse(Console.ReadLine(), out int entry);
                Selection userselection = (Selection)entry;
                switch (userselection) 
                {
                   case Selection.Start:
                        watch.StartTimer();
                        break;
                    case Selection.Stop:
                        watch.StopTimer();
                        break;
                    case Selection.Interval:
                        watch.TimeInterval();
                        break;
                    case Selection.Exit:
                        return;
                }
            }
        }
    }
}
