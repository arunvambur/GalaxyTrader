using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader
{
    class Program
    {
        static IContext context = new StorageContext();
        static IQueryGalaxy qg = new QueryGalaxy();

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                string line;
                do
                {
                    line = Console.ReadLine();
                    Process(line);
                }
                while (line.ToLower() != "exit");
            }
            else if (args.Length == 1)
            {
                string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(args[0]);
                while ((line = file.ReadLine()) != null)
                {
                    Process(line);
                }

                file.Close();
            }
            else
                Console.WriteLine("Arguments passed is not valid");

        }

        static void Process(string line)
        {
            try
            {
                if (line.Length == 0) return;

                if (line.ToLower() != "exit")
                {
                    float responce = qg.Query(context, line);

                    if (responce >= 0)
                        Console.WriteLine(responce);
                }
            }
            catch (QueryGalaxyException qge)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Error: {qge.Message}, query({qge.Query})");
                if (qge.Token != null)
                    sb.Append($", token({qge.Token})");

                Console.WriteLine(sb.ToString());

            }
        }
    }
}
