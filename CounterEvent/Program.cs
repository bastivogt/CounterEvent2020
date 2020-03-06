using System;

namespace CounterEvent
{
    class Program
    {
        static Counter c;
        static Counter2 c2;
        static void Main(string[] args)
        {
            c = new Counter();
            c.CounterStartHandler += delegate (object sender, EventArgs e)
            {
                Counter s = (Counter)sender;
                Console.WriteLine($"COUNTER_START Count = {s.Count}");
            };

            c.CounterChangeHandler += (object sender, EventArgs e) => {
                Counter s = (Counter)sender;
                Console.WriteLine($"COUNTER_CHANGE Count = {s.Count}");
            };

            c.CounterFinishHandler += c_CounterFinishHandler;


            c.run();

            Console.WriteLine("------------------------------- Counter2 ----------------------------------------");

            c2 = new Counter2();
            c2.CounterStartHandler += (object sender, CounterEventArgs e) =>
            {
                Console.WriteLine($"COUNTER_START Count = {e.Count}");
            };

            c2.CounterChangeHandler += (object sender, CounterEventArgs e) =>
            {
                Console.WriteLine($"COUNTER_CHANGE Count = {e.Count}");
            };

            c2.CounterFinishHandler += (object sender, CounterEventArgs e) =>
            {
                Console.WriteLine($"COUNTER_FINISH Count = {e.Count}");
            };

            c2.run();
        }

        static void c_CounterFinishHandler(object sender, EventArgs e)
        {
            Counter s = (Counter)sender;
            Console.WriteLine($"COUNTER_FINISH Count = {s.Count}");
        }


    }
}
