using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            string result, error;

            System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "dotnet --version");

            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();

            using (System.IO.StreamReader myOutput = proc.StandardOutput)
            {
                result = myOutput.ReadToEnd();
            }
            using (System.IO.StreamReader myError = proc.StandardError)
            {
                error = myError.ReadToEnd();

            }

            Console.WriteLine(result.StartsWith("2.1"));
            Console.WriteLine("result: " + result);

            Console.WriteLine("error: " + error);

            Console.ReadLine();
        }
    }
}
