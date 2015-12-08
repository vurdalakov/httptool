namespace Vurdalakov
{
    using System;
    using System.Net;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("httptool <http method> <url> [-options]\n");
                Console.WriteLine("HTTP methods:");
                Console.WriteLine("\thead - sends HEAD command and prints response HTTP headers");
                return;
            }

            var url = args[1];

            switch (args[0].ToLower())
            {
                case "head":
                    Head(url);
                    break;
            }
        }

        static public void Head(String url)
        {
            using (var webClient = new WebClientEx())
            {
                var headers = webClient.DownloadHeaders(url);

                foreach (var header in headers)
                {
                    Console.WriteLine("{0}={1}", header.Key, header.Value);
                }
            }
        }
    }
}
