using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LU1_TaskManager
{
    public partial class Form1 : Form
    {
        private int processId; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.ProcessName
                               select proc;

            foreach (var p in runningProcs)
            {
                listBox1.Items.Add(string.Format("-> PID: {0} \t Name: {1}", p.Id, p.ProcessName));
            }
        }

        private void btnStartChrome_Click(object sender, EventArgs e)
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "chrome.exe",
                    Arguments = "https://www.varsitycollege.co.za",
                    WindowStyle = ProcessWindowStyle.Maximized,
                    UseShellExecute = true
                };

                using (Process chromeProc = Process.Start(startInfo))
                {
                    if (chromeProc != null)
                    {
                        processId = chromeProc.Id;
                        // MessageBox.Show(processId.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Chrome could not be started.");
                    }
                }
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show("Unable to start Chrome (is it installed / on PATH?): " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        private void btnKillChrome_Click(object sender, EventArgs e)
        {
            try
            {
                if (processId != 0)
                {
                    try
                    {
                        var p = Process.GetProcessById(processId);
                        p.Kill();
                        p.WaitForExit(2000);
                        processId = 0;
                        MessageBox.Show("Tracked Chrome process terminated.");
                        return;
                    }
                    catch (ArgumentException)
                    {

                        processId = 0;
                    }
                }

                Process[] chromeProcs = Process.GetProcessesByName("chrome");
                if (chromeProcs.Length == 0)
                {
                    MessageBox.Show("No Chrome processes found.");
                    return;
                }

                foreach (Process p in chromeProcs)
                {
                    try { p.Kill(); }
                    catch (Exception exInner) { Debug.WriteLine(exInner.Message); }
                }

                MessageBox.Show("All Chrome processes were terminated.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        private void btnEndTaskMng_Click(object sender, EventArgs e)
        {
            var p = Process.GetCurrentProcess();
            try
            {
                Application.Exit();
                p.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }

        private void btnThreads_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedPid(out int i))
            {
                MessageBox.Show("Please select a process first.");
                return;
            }

            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(i);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Process not found: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return;
            }

            if (theProc != null)
            {
                var sb = new StringBuilder();
                try
                {
                    ProcessThreadCollection theThreads = theProc.Threads;
                    foreach (ProcessThread pt in theThreads)
                    {
                        string startTime;
                        try
                        {
                            startTime = pt.StartTime.ToShortTimeString();
                        }
                        catch
                        {
                            startTime = "N/A";
                        }

                        sb.AppendLine(
                            $"-> Thread ID: {pt.Id}\tStart Time: {startTime}\tPriority: {pt.PriorityLevel}");
                    }
                }
                catch (Win32Exception ex)
                {
                    sb.AppendLine("Could not read thread information: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    sb.AppendLine("Process exited while reading threads: " + ex.Message);
                }
                MessageBox.Show(sb.ToString());
            }
        }

        private void btnLoadedModules_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedPid(out int i))
            {
                MessageBox.Show("Please select a process first.");
                return;
            }

            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(i);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Process not found: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return;
            }

            var sb = new StringBuilder();

            try
            {
                ProcessModuleCollection theMods = theProc.Modules;
                foreach (ProcessModule pm in theMods)
                {
                    sb.AppendLine($"-> Module Name: {pm.ModuleName}");
                }
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show("Unable to enumerate modules (access denied or 32/64-bit mismatch): " + ex.Message);
                return;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Process exited while reading modules: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return;
            }

            MessageBox.Show(sb.ToString());
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;

            string output = "";
            output += "Name of this domain: " + defaultAD.FriendlyName + Environment.NewLine;
            output += "ID of domain in this process: " + defaultAD.Id + Environment.NewLine;
            output += "Is this the default domain? " + defaultAD.IsDefaultAppDomain() + Environment.NewLine;
            output += "Base directory of this domain: " + defaultAD.BaseDirectory;

            MessageBox.Show(output);
        }

        private void btnAssemblies_Click(object sender, EventArgs e)
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;

            Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            var sb = new StringBuilder();
            sb.AppendLine("Assemblies loaded in " + defaultAD.FriendlyName);

            foreach (Assembly a in loadedAssemblies)
            {
                sb.AppendLine("-> Name: " + a.GetName().Name);
                sb.AppendLine("-> Version: " + a.GetName().Version);
            }
            MessageBox.Show(sb.ToString());
        }

        private bool TryGetSelectedPid(out int pid)
        {
            pid = 0;
            var selected = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selected)) return false;

            var m = Regex.Match(selected, @"PID:\s*(\d+)");
            if (m.Success && int.TryParse(m.Groups[1].Value, out var parsed))
            {
                pid = parsed;
                return true;
            }
            return false;
        }
    }
}
