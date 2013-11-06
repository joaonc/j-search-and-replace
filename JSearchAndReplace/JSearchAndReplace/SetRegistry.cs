using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace JSearchAndReplace
{
    /// <summary>
    /// This class handles the interaction with the Registry to set right click handlers to work with files.
    /// Requires UAC elevated privileges.
    /// </summary>
    public static class SetRegistry
    {
        public static readonly string SetRegistryCommandLineArg = "-ConfigRegistryRightClickHandler";

        public static bool CheckCommandLineArgs(string[] args)
        {
            bool registryProcessed = false;
            if (args != null && args.Length == 2 && args[0].Equals(SetRegistryCommandLineArg))
            {
                try
                {
                    System.IO.File.AppendAllText("COMMANDLINE_JSearchAndReplace.txt", string.Format("{0} : {1}\n", DateTime.Now.ToString(), string.Join(" ", args)));
                    SetFromCommandLineArgs(args[1]);  // Note: Application exits when this call is done
                }
                finally
                {
                    registryProcessed = true;
                }
            }

            return registryProcessed;
        }

        public static bool StartProcessElevatedPrivileges(string args, bool waitForExit)
        {
            // Launch itself as administrator
            ProcessStartInfo process = new ProcessStartInfo();
            process.UseShellExecute = true;
            process.WorkingDirectory = Environment.CurrentDirectory;
            process.FileName = Application.ExecutablePath;
            process.Verb = "runas";
            process.Arguments = args;

            try
            {
                Process newProcess = Process.Start(process);

                if (waitForExit)
                    newProcess.WaitForExit();
            }
            catch
            {
                // The user refused to allow privileges elevation.
                // Do nothing and return directly ...
                return false;
            }

            return true;
        }

        public static void SetFromCommandLineArgs(string commandLineArgs)
        {
            string[] fileExtensions = commandLineArgs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Set(fileExtensions);
        }

        public static void Set(string[] fileExtensions)
        {
            char[] trimChars = new char[] { ' ', '*', '.' };
            foreach (string fileExtension in fileExtensions)
            {
                string extension = "." + fileExtension.Trim(trimChars).ToLower();

                try
                {
                    RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(extension, true);
                    if (regKey == null)
                    {
                        // Create new entry
                        regKey = Registry.ClassesRoot.CreateSubKey(extension);
                        regKey.SetValue("", extension.TrimStart('.') + "file", RegistryValueKind.String);  // Default value
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Not enough permissions to update the registry.");
                }
            }
        }
    }
}
