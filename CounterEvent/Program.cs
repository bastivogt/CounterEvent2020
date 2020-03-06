using System;

namespace CounterEvent
{
    class Program
    {
        static Counter c;
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
        }

        static void c_CounterFinishHandler(object sender, EventArgs e)
        {
            Counter s = (Counter)sender;
            Console.WriteLine($"COUNTER_FINISH Count = {s.Count}");
        }


    }
}
