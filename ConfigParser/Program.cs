namespace ConfigParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var configData = ConfigParser.FromFile("TextFile1.txt");
            ConfigParser.Write("ResultFile.txt", configData);
        }
    }
}
