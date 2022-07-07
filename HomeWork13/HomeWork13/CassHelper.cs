namespace HomeWork13
{
    internal static class CassHelper
    {
        public static int ChooseBetter(List<Cassa> cassas, Person person)
        {
            List<Cassa> newCassas = new(cassas);
            newCassas.Sort(new CassComparer());
            List<Cassa> minPersonCass = new();
            foreach (var item in newCassas)
            {
                if (item.Count == newCassas[0].Count)
                {
                    minPersonCass.Add(item);
                }
            }

            double minDistanse = minPersonCass[0].Cordinate - person.Coordinate;
            int betterIndex = 0;
            for (int i = 0; i < minPersonCass.Count; i++)
            {
                if (minPersonCass[i].Cordinate - person.Coordinate < minDistanse)
                {
                    minDistanse = minPersonCass[i].Cordinate - person.Coordinate;
                    betterIndex = i;
                }
            }
            return cassas.IndexOf(minPersonCass[betterIndex]);
        }
    }
}