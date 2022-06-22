using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork6
{
    public class Task1Program // Task 1
    {
        private string _path;
        private List<FlatData> flats;
        private int _quartalNumber;
        private int flatNumbers;
        public string Path
        {
            get;
            private set;
        }
        public int QuartalNumber
        {
            get => _quartalNumber;
            private set
            {
                if (value >= 1 && value <= 4)
                {
                    _quartalNumber = value; 
                }
            }
        } 
        public int FlatNumbers
        {
            get => flatNumbers;
            private set
            {
                if (value > 0)
                {
                    flatNumbers = value; 
                }
            }
        } 
        private Task1Program()
        {
            flats = new List<FlatData>();
        }
        public Task1Program(string path) : this()
        {
            Path = path;
        }

        public void InputData()
        {
            try
            {
                StreamReader reader = new StreamReader(Path);
                int lineNumber = 1;
                string[] line = reader.ReadLine().Split(' ');
                if (!int.TryParse(line[0], out flatNumbers))
                {
                    Console.WriteLine($"Cant read {lineNumber} line");
                }
                if (!int.TryParse(line[1], out _quartalNumber))
                {
                    Console.WriteLine($"Cant read {lineNumber} line");
                }
                lineNumber++;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(' ');
                    try
                    {
                        flats.Add(new FlatData(line[0],
                                        int.Parse(line[1]),
                                        double.Parse(line[2]),
                                        double.Parse(line[3]),
                                        DateTime.Parse(line[4])));
                        lineNumber++;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Cant read {lineNumber++} line");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
        }
        public void OutputAll()
        {
            foreach (var item in flats)
            {
                Console.WriteLine(item);
            }
        }
        public void OutputFlat(int flatNumber)
        {
            if (flatNumber > FlatNumbers || flatNumber <= 0)
            {
                Console.WriteLine("No such flat");
                return;
            }
            try
            {
                Console.WriteLine($"\n{flats[flatNumber - 1]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No such flat in database");
            }
        }
        public void OutputNoEnergyUsed()
        {
            int index = 1;
            foreach (var item in flats)
            {
                if ((int)item.UsedEnergy == 0)
                {
                    if (index == 1)
                    {
                        Console.WriteLine("\nNo energy used:");
                    }
                    Console.WriteLine($"{index++}) Owner:{item.Owner}\tFlat number:{item.Number}");
                }
            }
        }
        public void OutputMostEnergyUsed()
        {
            if (flats.Count == 0)
            {
                return;
            }
            FlatData flatMostEnergyUsed = flats[0];
            Console.WriteLine();
            foreach (var item in flats)
            {
                if (item.UsedEnergy > flatMostEnergyUsed.UsedEnergy)
                {
                    flatMostEnergyUsed = item;
                }
            }
            Console.WriteLine($"Most energy used: {flatMostEnergyUsed.Owner}");
        }
        public void OutputDataIntoFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Quartal: {QuartalNumber} Number of flats: {FlatNumbers}");
                foreach (var item in flats)
                {
                    writer.WriteLine(item);
                }
            }
        }
        public void NeedToPay()
        {
            Console.WriteLine();
            foreach (var item in flats)
            {
                Console.WriteLine($"{item.Owner} (flat number {item.Number}) need to pay {item.UsedEnergy*3}UAH");
            }
        }
        public void daysFromLastData(int flatNumber)
        {
            Console.WriteLine($"\nDays from last data in flat №{flatNumber}: {DateTime.Now.Day - flats[flatNumber-1].Data.Day}");
        }
    }
}
