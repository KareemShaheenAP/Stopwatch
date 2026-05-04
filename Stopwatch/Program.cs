using System.ComponentModel;

namespace Stopwatch
{
    public class StopWatch
    {
        public DateTime StartTime { get; private set; }
        public DateTime StopTime { get; private set; }
        public TimeSpan timeSpan { get; private set; }
        public bool StopWatchSTatus = false;
        public void StartTimer() //set True
        {
            if (StopWatchSTatus)
            {
                Console.WriteLine("Stopwatch already started");
            }
            else
            {
                StopWatchSTatus = true;
                Console.WriteLine("Stopwatch started");
                StartTime = DateTime.Now;
            }
        }
        public void StopTimer() //set false
        {
            if (!StopWatchSTatus) 
            {
                Console.WriteLine("Stopwatch already stopped");
            }
            else
            {
                StopWatchSTatus = false;
                Console.WriteLine("Stopwatch stopped");
                StopTime = DateTime.Now;
            }
        }
        public void TimeInterval()
        {
            if (StopWatchSTatus)
            {
                Console.WriteLine("Please stop stopwatch first");
            }
            else if (timeSpan.TotalSeconds == 0 && StopTime == StartTime)
            {
                Console.WriteLine("Please start then stop stopwatch to get total duration");
            }
            else
            {
                // In case it is continuous stop watch
                //timeSpan += StopTime.Subtract(StartTime);
                // In case it is seperatly each time started and stopped
                timeSpan = StopTime.Subtract(StartTime);
                Console.WriteLine($"Total duration is {timeSpan.Days} Days - {timeSpan.Hours} Hours - {timeSpan.Minutes} Mintues - {timeSpan.Seconds} seconds");
                Console.WriteLine($"\nTotal duration is {timeSpan.TotalSeconds} Seconds");
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
