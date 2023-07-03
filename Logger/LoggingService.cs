using System;
using System.Diagnostics;

namespace Logger
{
    public class LoggerService
    {
        static StreamWriter writer;
        static LoggerService()
        {
            writer = new StreamWriter(@"C: \Users\AISHWARYA\source\repos\Univeristy database\Output Files\log.txt");
        }
        public static void Error(string msg)
        {
            writer.WriteLine($"Error! {msg}");
        }
    }
}
