using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork6
{
    public class IPScaner
    {
        private List<IPData> _IPs;
        private string _path;

        public string Path { get => _path; set => _path = value; }
        public IPScaner(string path) : this()
        {
            Path = path;
        }
        private IPScaner()
        {
            _IPs = new List<IPData>();
        }
        public void ReadFife()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        _IPs.Add(new IPData(line));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found!");
            }
            catch (Exception)
            {
                Console.WriteLine("Some Exception");
            }
        }
        public void MostPopularDay()
        {
            HashSet<IPData> iPDatas = new HashSet<IPData>(_IPs);
            Console.WriteLine("Most popular days:");
            foreach (var item in iPDatas)
            {
                List<IPData> temp = new List<IPData>();
                for (int i = 0; i < _IPs.Count; i++)
                {
                    if (_IPs[i] == item)
                    {
                        temp.Add(_IPs[i]);
                    }
                }
                temp.Sort(new CompareByDay());
                Days day = temp[0].Day;
                int max_count = 1;
                int curr_count = 1;
                for (int i = 1; i < temp.Count; i++)
                {
                    if (temp[i].Day == temp[i - 1].Day)
                    {
                        curr_count++;
                    }
                    else
                    {
                        curr_count = 1;
                    }

                    if (curr_count > max_count)
                    {
                        max_count = curr_count;
                        day = temp[i - 1].Day;
                    }

                }
                Console.WriteLine($"{item} - {Enum.GetName(typeof(Days), day)}");
            }

        }
        public void MostPopularHour()
        {
            HashSet<IPData> iPDatas = new HashSet<IPData>(_IPs);
            _IPs.Sort(new CompareByTime());

            Console.WriteLine("Most popular hours:");
            foreach (var item in iPDatas)
            {
                string hour = item.Time.Split(':')[0];
                for (int i = 1; i < _IPs.Count; i++)
                {
                    int max_count = 1;
                    int curr_count = 1;
                    if (item.Ip == _IPs[i].Ip)
                    {
                        if (_IPs[i].Time.Split(':')[0] == _IPs[i - 1].Time.Split(':')[0])
                        {
                            curr_count++;
                        }
                        else
                        {
                            curr_count = 1;
                        }


                        if (curr_count > max_count)
                        {
                            max_count = curr_count;
                            hour = _IPs[i - 1].Time.Split(':')[0];
                        }
                    }
                }
                Console.WriteLine($"{item} - {hour}");
            }
        }
    }
}
