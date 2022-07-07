namespace HomeWork13
{
    internal class CassComparer : IComparer<Cassa>
    {
        public int Compare(Cassa x, Cassa y)
        {
            return x.Count - y.Count;
        }
    }
}