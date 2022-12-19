using Citect;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ctApi = new CtApi(true,"172.26.176.60","HLT2", "HLT2");
                ctApi.Open();
                Console.WriteLine("connected");
                ctApi.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
