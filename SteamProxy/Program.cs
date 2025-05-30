﻿using System.Diagnostics;
using System.IO;
using Windows.Gaming.UI;

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
            string launchDir = Environment.CurrentDirectory;
            string steamCommand = "";

            Trace.WriteLine("SteamProxy Args");
            Trace.Indent();
            foreach (string arg in args)
            {

                Trace.WriteLine(arg);

                if (arg == "--debug") continue;
                if (arg == "--ue5") continue;

                if (arg.StartsWith("--steam="))
                {
                    steamCommand = Path.GetFullPath(arg.Substring(8));
                    continue;
                }

                if (arg.StartsWith("--mo2="))
                {
                    Trace.WriteLine("MO2 Profile");
                    
                    string[] modOrgainizer = arg.Substring(6).Split("|");
                    string modOrgainizerBin = modOrgainizer[0];
                    string modOrgainizerProfile = @"moshortcut://" + modOrgainizer[1];

                    launchDir = Path.GetDirectoryName(modOrgainizerBin);
                    launchExe = Path.GetFullPath(modOrgainizerBin);
                    launchArgs = "\"" + modOrgainizerProfile + "\"";
                    continue;
                }

                if (arg.StartsWith("--app="))
                {
                    Trace.WriteLine("APP");
                    if (args.Contains("--ue5"))
                    {
                        string gamedir = steamCommand.Substring(0, steamCommand.Length - 4);
                        string bindir = Path.Combine(gamedir, "Binaries", "Win64");

                        launchExe = Path.GetFullPath(Path.Combine(bindir, arg.Substring(6)));
                        continue;
                    }

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
            Trace.WriteLine("Working Dir: " + launchDir);
            Trace.Unindent();

            ProcessStartInfo GameStartInfo = new()
            {
                FileName = launchExe,
                Arguments = launchArgs,
                WorkingDirectory = launchDir,
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
