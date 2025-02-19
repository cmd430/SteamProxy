using System.Diagnostics;

namespace SteamProxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Contains("--debug"))
            {
                string logFile = "SteamProxy.log";

                if (File.Exists(logFile)) File.WriteAllText(logFile, "");

                Trace.Listeners.Add(new TextWriterTraceListener("SteamProxy.log"));
                Trace.AutoFlush = true;

                Trace.WriteLine("------------- [START] -------------");
            }

            string launchExe = "";
            string launchArgs = "";       

            foreach (string arg in args)
            {
                if (arg.StartsWith("--app="))
                {
                    launchExe = Path.GetFullPath(arg.Substring(6));
                    continue;
                }

                if (arg == "--debug" || arg.StartsWith("--steam="))
                {
                    continue;
                }

                launchArgs = launchArgs + " " + arg;
            }

            Trace.WriteLine("Executable: " + launchExe);
            Trace.WriteLine("Arguments: " + (launchArgs == "" ? "<none>" : launchArgs));
            Trace.WriteLine("Working Dir: " + Environment.CurrentDirectory);

            Process GameProcess = Process.Start(launchExe, launchArgs);

            Trace.WriteLine("Process ID: " + GameProcess.Id);
            Trace.WriteLine("------------- [ END ] -------------");
            Trace.Close();
        }
    }
}
