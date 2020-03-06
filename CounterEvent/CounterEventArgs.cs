using System;
using System.Collections.Generic;
using System.Text;

namespace CounterEvent
{
    public class CounterEventArgs : EventArgs
    {
        public int Count { get; set; } = 0;
        public CounterEventArgs(int count)
        {
            this.Count = count;
        }
    }
}
