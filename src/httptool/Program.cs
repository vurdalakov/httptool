namespace Vurdalakov
{
    using System;
    using System.Net;

    class Program
    {
        static void Main(string[] args)
        {
            if ((args.Length != 2) || (args[0][0] != '-'))
            {
                Console.WriteLine("httptool -command <url>\n");
                Console.WriteLine("Commands:");
                Console.WriteLine("\t-head - sends HEAD command and prints response HTTP headers");
                return;
            }

            var url = args[1];

            switch (args[0].ToLower())
            {
                case "-head":
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
