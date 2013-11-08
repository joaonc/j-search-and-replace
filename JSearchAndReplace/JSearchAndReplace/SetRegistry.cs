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
        public static readonly string CommandName = "Search and Replace";

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

            List<RegistryKey> regKeyCreatedList = new List<RegistryKey>();

            // See the link below for more info
            // http://www.howtogeek.com/107965/how-to-add-any-application-shortcut-to-windows-explorers-context-menu
            foreach (string fileExtension in fileExtensions)
            {
                string extension = "." + fileExtension.Trim(trimChars).ToLower();

                try
                {
                    // HKEY_CLASSES_ROOT\<file extension including the dot>
                    // Below we will use the example ".srt" (an extension commonly used for subtitle text files)
                    // HKEY_CLASSES_ROOT\.srt
                    RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(extension, true);
                    if (regKey == null)
                    {
                        // Create new entry for the extension under HKEY_CLASSES_ROOT
                        regKey = Registry.ClassesRoot.CreateSubKey(extension);
                        regKey.SetValue("", extension.TrimStart('.') + "file", RegistryValueKind.String);  // Default value
                        regKey.SetValue("Content Type", "text/plain", RegistryValueKind.String);
                        regKey.SetValue("PerceivedType", "text", RegistryValueKind.String);
                        regKey.Close();

                        regKeyCreatedList.Add(regKey);
                        regKey = Registry.ClassesRoot.OpenSubKey(extension, true);
                    }

                    object regCRAppValue = regKey.GetValue("");  // Default value
                    if (regCRAppValue.GetType() != typeof(string))
                    {
                        throw new Exception(string.Format(
                            "Cannot read default value of HKEY_CLASSES_ROOT\\{0} as it's not a string.\nCurrent value: {1}",
                            extension, regCRAppValue));
                    }
                    string regCRAppName = (string)regCRAppValue;

                    // HKEY_CLASSES_ROOT\srtfile
                    RegistryKey regKeyCRApp = Registry.ClassesRoot.OpenSubKey(regCRAppName, true);
                    if (regKeyCRApp == null)
                    {
                        regKeyCRApp = Registry.ClassesRoot.CreateSubKey(regCRAppName);
                        regKeyCRApp.Close();

                        regKeyCreatedList.Add(regKeyCRApp);
                        regKeyCRApp = Registry.ClassesRoot.OpenSubKey(regCRAppName, true);
                    }

                    // HKEY_CLASSES_ROOT\srtfile\shell
                    RegistryKey regKeyCRAppShell = regKeyCRApp.OpenSubKey("shell", true);
                    if (regKeyCRAppShell == null)
                    {
                        regKeyCRAppShell = regKeyCRApp.CreateSubKey("shell");
                        regKeyCRAppShell.Close();

                        regKeyCreatedList.Add(regKeyCRAppShell);
                        regKeyCRAppShell = regKeyCRApp.OpenSubKey("shell", true);
                    }

                    // HKEY_CLASSES_ROOT\srtfile\shell\<text in right click>
                    // ex: HKEY_CLASSES_ROOT\srtfile\shell\Search and Replace
                    RegistryKey regKeyCRAppShellCommandName = regKeyCRAppShell.OpenSubKey(CommandName, true);
                    if (regKeyCRAppShellCommandName == null)
                    {
                        // The right click text that will appear
                        regKeyCRAppShellCommandName = regKeyCRAppShell.CreateSubKey(CommandName);
                        regKeyCRAppShellCommandName.Close();

                        regKeyCreatedList.Add(regKeyCRAppShellCommandName);
                        regKeyCRAppShellCommandName = regKeyCRAppShell.OpenSubKey(CommandName, true);
                    }

                    // HKEY_CLASSES_ROOT\srtfile\shell\Search and Replace\command
                    RegistryKey regKeyCRAppShellCommandNameCommand = regKeyCRAppShellCommandName.OpenSubKey("command", true);
                    if (regKeyCRAppShellCommandNameCommand == null)
                    {
                        // Command used to invoke this app (in the Default value)
                        regKeyCRAppShellCommandNameCommand = regKeyCRAppShellCommandName.CreateSubKey("command");
                        regKeyCRAppShellCommandNameCommand.Close();

                        regKeyCreatedList.Add(regKeyCRAppShellCommandNameCommand);
                        regKeyCRAppShellCommandNameCommand = regKeyCRAppShellCommandName.OpenSubKey("command", true);
                    }

                    // HKEY_CLASSES_ROOT\srtfile\shell\Search and Replace\command\<command line instructions>
                    object regCommandValue = regKeyCRAppShellCommandNameCommand.GetValue("");
                    if (regCommandValue == null || (regCommandValue.GetType() == typeof(string) && string.IsNullOrEmpty((string)regCommandValue)))
                    {
                        regKeyCRAppShellCommandNameCommand.SetValue(
                            "",
                            string.Format("{0}", Application.ExecutablePath),
                            RegistryValueKind.ExpandString);
                    }
                    // else, entry already exists, do nothing
                }
                catch (UnauthorizedAccessException ex)
                {
                    string error = ex.Message;

                    // Rollback entries that were added to the registry (LIFO)
                    try
                    {
                        for (int i = regKeyCreatedList.Count - 1; i >= 0; i--)
                        {
                            RegistryKey regKey = regKeyCreatedList[i];
                            regKey.DeleteSubKeyTree("");  // TODO: verify this works
                        }
                    }
                    catch (Exception ex2)
                    {
                        error += "\n\nIn addition, there was the following error trying to rollback:\n" + ex2.Message;
                    }

                    MessageBox.Show(error, "Not enough permissions to update the registry");
                }
            }
        }
    }
}
