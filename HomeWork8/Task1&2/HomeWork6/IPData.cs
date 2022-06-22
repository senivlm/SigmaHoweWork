using System;
using System.Collections.Generic;

namespace HomeWork6
{
    public class IPData
    {
        private string _ip;
        private string _time;
        private Days _day;

        public string Ip { get => _ip; set => _ip = value; }
        public string Time { get => _time; set => _time = value; }
        public Days Day { get => _day; set => _day = value; }
        public IPData(string ip, string time, Days day)
        {
            Ip = ip;
            Time = time;
            Day = day;
        }
        public IPData(string line)
        {
            Parse(line);
        }
        public IPData() : this(default, default, default)
        {

        }
        public void Parse(string str)
        {
            try
            {
                string[] line = str.Split(' ');
                Ip = line[0];
                Time = line[1];
                Day = (Days)Enum.Parse(typeof(Days), line[2]);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public override string ToString()
        {
            return $"{Ip}";
        }
        public override bool Equals(object obj)
        {
            return this.Ip == ((IPData)obj).Ip;
        }
        public override int GetHashCode()
        {
            return Ip.Length;
        }

        public static bool operator ==(IPData current, IPData another)
        {
            return current.Equals(another);
        }
        public static bool operator !=(IPData current, IPData another)
        {
            return !current.Equals(another);
        }
    }
    public class CompareByDay : IComparer<IPData>
    {
        public int Compare(IPData x, IPData y)
        {
            int day1 = (int)x.Day;
            int day2 = (int)y.Day;
            if (day1 > day2)
            {
                return 1;
            }
            else if (day1 < day2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class CompareByTime : IComparer<IPData>
    {
        public int Compare(IPData x, IPData y)
        {
            int time1 = int.Parse(x.Time.Split(':')[0]);
            int time2 = int.Parse(y.Time.Split(':')[0]);
            if (time1 > time2)
            {
                return 1;
            }
            else if (time1 < time2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
