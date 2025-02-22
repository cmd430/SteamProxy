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

                Trace.Listeners.Add(new TextWriterTraceListener(logFile));
                Trace.AutoFlush = true;

                Trace.WriteLine("------------- [START] -------------");
                Trace.WriteLine("");
                Trace.Indent();
            }

            string launchExe = "";
            string launchArgs = "";
            string steamCommand = "";

            Trace.WriteLine("SteamProxy Args");
            Trace.Indent();
            foreach (string arg in args)
            {

                Trace.WriteLine(arg);

                if (arg == "--debug") continue;

                if (arg.StartsWith("--steam="))
                {
                    steamCommand = Path.GetFullPath(arg.Substring(8));
                    continue;
                }

                if (arg.StartsWith("--app="))
                {
                    launchExe = Path.GetFullPath(arg.Substring(6));
                    continue;
                }

                launchArgs = launchArgs + " " + arg;
            }
            Trace.Unindent();

            if (launchExe == "")
            {
                Trace.WriteLine("");
                Trace.WriteLine("Unable to find valid app path, falling back to Steam default");
                launchExe = steamCommand;
            }

            Trace.WriteLine("");
            Trace.WriteLine("Starting game with the following parameters...");
            Trace.Indent();
            Trace.WriteLine("Executable: " + launchExe);
            Trace.WriteLine("Arguments: " + (launchArgs == "" ? "<none>" : launchArgs));
            Trace.WriteLine("Working Dir: " + Environment.CurrentDirectory);
            Trace.Unindent();

            ProcessStartInfo GameStartInfo = new()
            {
                FileName = launchExe,
                Arguments = launchArgs,
                UseShellExecute = false
            };

            try
            {
                Process GameProcess = Process.Start(GameStartInfo)!;

                if (GameProcess != null)
                {
                    Trace.WriteLine("");
                    Trace.WriteLine("Process started with ID: " + GameProcess.Id);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("");
                Trace.WriteLine("Process unable to be started: " + ex.Message);
            }

            Trace.Unindent();
            Trace.WriteLine("");
            Trace.WriteLine("------------- [ END ] -------------");
            Trace.WriteLine("");
            Trace.Close();
        }
    }
}
