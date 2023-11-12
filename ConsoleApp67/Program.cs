namespace ConsoleApp67
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<object> collection = new List<object>();
            collection.Add(42);
            collection.Add("Hello, world!");
            collection.Add(DateTime.Now);

            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}