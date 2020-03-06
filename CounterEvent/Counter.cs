using System;
using System.Collections.Generic;
using System.Text;

namespace CounterEvent
{
    class Counter
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
        public EventHandler CounterStartHandler;
        public EventHandler CounterFinishHandler;
        public EventHandler CounterChangeHandler;


        // Event Methoden
        protected virtual void OnCounterStart(EventArgs e)
        {
            if(this.CounterStartHandler != null)
            {
                this.CounterStartHandler(this, e);
            }
        }

        protected virtual void OnCounterChange(EventArgs e)
        {
            if(this.CounterChangeHandler != null)
            {
                this.CounterChangeHandler(this, e);
            }
        }

        protected virtual void OnCounterFinish(EventArgs e)
        {
            if(this.CounterFinishHandler != null)
            {
                this.CounterFinishHandler(this, e);
            }
        }


        public Counter(int startValue = 0, int finishValue = 10, int stepValue = 1)
        {
            this.StartValue = startValue;
            this.FinishValue = finishValue;
            this.StepValue = stepValue;
        }

        public virtual void run()
        {
            this.OnCounterStart(EventArgs.Empty);
            for(this.Count = this.StartValue; this.Count < this.FinishValue; this.Count += this.StepValue)
            {
                this.OnCounterChange(EventArgs.Empty);
            }
            this.OnCounterFinish(EventArgs.Empty);
        }

    }
}
