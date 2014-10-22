using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVackarklocka_A
{
    class AlarmClock
    {
        private int _alarmHour; 
        private int _alarmMinute; 
        private int _hour; 
        private int _minute; 
        

        public int AlarmHour 
        { 
            get { return _alarmHour; } 
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException();
                }
                
                _alarmHour = value;
            }
        }  

        public int AlarmMinute 
        { 
            
            get { return _alarmMinute; } 
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException();
                }

                _alarmMinute = value;
            }
            
        }  

        public int Minute 
            { 
            
            get { return _minute; } 
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException();
                }

                _minute = value;
            }
            
        } 

        public int Hour 
        { 
            get { return _hour; } 
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException();
                }
                
                _hour = value;
            }
        } 


        public AlarmClock() : this(0, 0)
        {}

        public AlarmClock(int hour, int minute) : this(hour, minute, 0, 0) 
        {}

        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute) 
        {
            this.Hour = hour;
            this.Minute = minute;
            this.AlarmHour = alarmHour;
            this.AlarmMinute = alarmMinute;
        }
        
        public bool TickTock()
        {
            // ++minute [0,59]. Minute = 0, ++hour [0,23]
            _minute++;
            if (_minute == 60)
            {
                _minute = 0;
                _hour++;
                if (_hour == 24)
                {
                    _hour = 0;
                }
            }

            // om ny tid == alarmtiden == true, annars false
            if (_hour == _alarmHour && _minute == _alarmMinute)
            {
                return true;
            }
            else { return false; }

        }
        public override string ToString()
        {         
            return string.Format("{0,2}:{1:00} ({2}:{3:00})", Hour, Minute, AlarmHour, AlarmMinute);
        }

    }
}
