using System;
using System.Collections.Generic;
using System.Text;

namespace CounterEvent
{



    class Counter3
    {

        public int StartValue { get; set; } = 0;

        public int FinishValue { get; set; } = 10;

        public int StepValue { get; set; } = 1;

        private int _count;
        public int Count
        {
            get
            {
                return this._count;
            }
            private set
            {
                this._count = value;
            }
        }


        // Events
        public event EventHandler<CounterEventArgs> CounterStartHandler;
        public event EventHandler<CounterEventArgs> CounterFinishHandler;
        public event EventHandler<CounterEventArgs> CounterChangeHandler;


        // Event Methoden
        protected virtual void OnCounterStart(CounterEventArgs e)
        {
            if (this.CounterStartHandler != null)
            {
                this.CounterStartHandler(this, e);
            }
        }

        protected virtual void OnCounterChange(CounterEventArgs e)
        {
            if (this.CounterChangeHandler != null)
            {
                this.CounterChangeHandler(this, e);
            }
        }

        protected virtual void OnCounterFinish(CounterEventArgs e)
        {
            if (this.CounterFinishHandler != null)
            {
                this.CounterFinishHandler(this, e);
            }
        }


        public Counter3(int startValue = 0, int finishValue = 10, int stepValue = 1)
        {
            this.StartValue = startValue;
            this.FinishValue = finishValue;
            this.StepValue = stepValue;
        }

        public virtual void run()
        {
            this.Count = this.StartValue;
            this.OnCounterStart(new CounterEventArgs(this.Count));
            for (; this.Count < this.FinishValue; this.Count += this.StepValue)
            {
                this.OnCounterChange(new CounterEventArgs(this.Count));
            }
            this.OnCounterFinish(new CounterEventArgs(this.Count));
        }

    }
}
