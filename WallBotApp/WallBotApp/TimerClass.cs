using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
//Author: Schuyler
namespace WallBotApp
{
    public class TimerClass
    {
        //set up as C# "Properties"
        //increment length in milliseconds
        public float IncrementLength { get; set; }
        //time; in seconds or milliseconds-> essentially the time that has elapsed
        public float Seconds { get; set; }
        public float MilliSeconds { get; set; }
        //timer class object
        public Timer MyTimer;
        //two time stamp variables...for use eventually; use time stamp method to actually give it a value
        public float TimeStamp1 { get; set; }
        public float TimeStamp2 { get; set; }
        //my class has a Timer object-> my class is better because it can actually increment time
        public TimerClass()
        {
            MilliSeconds = 0;
            Seconds = 0;
            //defaults by incrementing in whole seconds
            IncrementLength = 100;
            MyTimer = new Timer(IncrementLength);
            //fortunately the Milliseconds is =0 right now
            SetTimeStamp1();
            SetTimeStamp2();
            MyTimer.Elapsed += new ElapsedEventHandler(IncrementEvent);
        }
        public TimerClass(float IncrementArg)
        {
            MilliSeconds = 0;
            Seconds = 0;
            //defaults by incrementing in whole seconds
            IncrementLength = IncrementArg;
            MyTimer = new Timer(IncrementLength);
            //fortunately the Milliseconds is =0 right now
            SetTimeStamp1();
            SetTimeStamp2();
            MyTimer.Elapsed += new ElapsedEventHandler(IncrementEvent);
        }
        //start, stop and reset methods
        public void Start()
        {
            //starts the event
            //MyTimer.Elapsed+=new ElapsedEventHandler(IncrementEvent);
            MyTimer.Start();
        }
        public void Stop()
        {
            MyTimer.Stop();
        }
        //reset actually sets time back to 0
        public void Reset()
        {
            //calls the stop method
            Stop();
            //time actually reset to 0
            Seconds = 0;
            MilliSeconds = 0;
        }
        public virtual void IncrementEvent(object source, ElapsedEventArgs e)
        {
            //just increments milliseconds by the amount when 
            MilliSeconds += IncrementLength;
            //increments seconds; every 1000 milliseconds
            Seconds = MilliSeconds / 1000f;
        }
        //sets the timestamps to the millisecond time (use this...don't just assign it a value)
        public void SetTimeStamp1()
        {
            TimeStamp1 = MilliSeconds;
        }
        public void SetTimeStamp2()
        {
            TimeStamp2 = MilliSeconds;
        }
    }
}
