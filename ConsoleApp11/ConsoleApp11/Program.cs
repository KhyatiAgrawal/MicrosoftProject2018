using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "dotnet --version");

            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();

            string result = proc.StandardOutput.ReadToEnd();

            Console.WriteLine(result.StartsWith("2.1"));
            Console.WriteLine(result);

            Console.ReadLine();
        }

        /*
         * This is like what is is griffin, it does not work, i think it is a different thing altogether
         * 
         * 
            private static void GetVersionFromRegistry()
            {
                // Opens the registry key for the .NET Framework entry.
                using (RegistryKey ndpKey =
                    RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
                    OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                {
                    // As an alternative, if you know the computers you will query are running .NET Framework 4.5 
                    // or later, you can use:
                    // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                    // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                    foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                    {
                        Console.WriteLine(versionKeyName);

                    }
                }
            }
        */
    }
}
