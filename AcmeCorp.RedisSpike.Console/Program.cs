namespace AcmeCorp.RedisSpike.Console
{
    using StackExchange.Redis;

    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (!done)
            {
                System.Console.WriteLine("Enter...");
                System.Console.WriteLine(" - w to write");
                System.Console.WriteLine(" - r to read");
                System.Console.WriteLine(" - x to exit");
                string input = System.Console.ReadLine();
                switch (input.ToLower())
                {
                    case "w":
                        IDatabase db1 = GetCache();
                        System.Console.WriteLine("Adding to cache...");
                        string setKey = GetInput("Please enter a key.");
                        string setValue = GetInput("Please enter a value.");
                        db1.StringSet(setKey, setValue);
                        System.Console.WriteLine("...complete.");
                        break;
                    case "r":
                        IDatabase db2 = GetCache();
                        System.Console.WriteLine("Reading from cache...");
                        string getKey = GetInput("Please enter a key.");
                        RedisValue getValue = db2.StringGet(getKey);
                        System.Console.WriteLine($"The value is {getValue}.");
                        System.Console.WriteLine("...complete.");
                        break;
                    default:
                        done = true;
                        break;
                }
            }
        }

        private static IDatabase GetCache()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            return redis.GetDatabase();
        }

        private static string GetInput(string message)
        {
            System.Console.WriteLine(message);
            return System.Console.ReadLine();
        }
    }
}
