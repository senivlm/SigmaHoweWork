using System;

namespace HomeWork6
{
    public class FlatData //fot Task 7.1
    {
        private string _owner;
        private int _number;
        private double _startElectricMeter;
        private double _endElectricMeter;
        private DateTime data;
        public FlatData(string owner, int flatNumber, double startElectricMeter, double endElectricMeter, DateTime data)
        {
            Owner = owner;
            Number = flatNumber;
            StartElectricMeter = startElectricMeter;
            EndElectricMeter = endElectricMeter;
            Data = data;
        }
        public FlatData() : this(default, default, default, default, default)
        {

        }

        public FlatData(string owner, int flatNumber)
        {
            Owner = owner;
            Number = flatNumber;
        }

        public string Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                if (value != null)
                {
                    _owner = value;
                }
                else
                {
                    _owner = "No Data";
                }
            }
        }
        public int Number
        {
            get => _number;
            set
            {
                if (value > 0)
                {
                    _number = value;
                }
            }
        }
        public double StartElectricMeter
        {
            get => _startElectricMeter;
            set
            {
                if (value > 0)
                {
                    _startElectricMeter = value;

                }
            }
        }
        public double EndElectricMeter
        {
            get => _endElectricMeter; 
            set
            {
                if (value >= _startElectricMeter)
                {
                    _endElectricMeter = value; 
                }
                else
                {
                    _endElectricMeter = _startElectricMeter;
                }
            }
        }
        public DateTime Data
        {
            get => data;
            set => data = value; 
        }
        public double UsedEnergy
        {
            get
            {
                return _endElectricMeter - _startElectricMeter;
            }
        }
        public override string ToString()
        {
            return $"Owner: {Owner}\tFlat number: {Number}\t" +
                $"Starting & ending electric meter: {StartElectricMeter} - {EndElectricMeter}\t" +
                $"Data: {Data.Day} {Enum.GetName(typeof(Months), Data.Month)}";
        }

        public override bool Equals(object obj)
        {
            return this.Owner == ((FlatData)obj).Owner && this.Number == ((FlatData)obj).Number;
        }
        public static bool operator ==(FlatData current, FlatData another)
        {
            return current.Equals(another);
        }
        public static bool operator !=(FlatData current, FlatData another)
        {
            return !current.Equals(another);
        }
    }
}
