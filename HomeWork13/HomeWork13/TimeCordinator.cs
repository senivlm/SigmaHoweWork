namespace HomeWork13
{
    internal class TimeCordinator
    {
        private int timeCounter = 1;

        public List<string> Cordinate(List<Cassa> casses, string path)
        {
            bool isProcess = true;
            int counter = 0;
            int time = 0;
            List<Person> persons = Reader.ReadPersons(path);
            List<string> result = new List<string>();

            while (isProcess)
            {
                time++;

                if (time % timeCounter == 0 && counter < persons.Count)
                {
                    casses[CassHelper.ChooseBetter(casses, persons[counter])].Enqueue(persons[counter++]);

                }
                int number = 0;
                foreach (var item in casses)
                {
                    number++;
                    if (!item.IsEmpty && --item.Peek().TimeServise <= 0)
                    {
                        result.Add($"Cassa_{number}: {item.Dequeue()} has been observed");
                        //Console.WriteLine(result[result.Count - 1]);
                    }
                    Thread.Sleep(500);
                }

                bool isContinuable = false;
                foreach (var item in casses)
                {
                    if (!item.IsEmpty)
                    {
                        isContinuable = true;
                    }
                }
                isProcess = isContinuable;
            }

            return result;
        }
    }
}