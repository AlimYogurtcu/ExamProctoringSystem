using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace Exam
{
    public partial class MainWindow : Window
    {
        private static System.Timers.Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            SetTimer();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }
        private static void SetTimer()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += backgroundKill;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void backgroundKill(Object source, ElapsedEventArgs x)
        {

            Process[] processes = Process.GetProcesses();

            foreach (Process p in processes)
            {
                try
                {
                    if (p.ProcessName.ToLower().Contains("discord") || p.ProcessName.ToLower().Contains("skype") || p.ProcessName.ToLower().Contains("teamspeak") || p.ProcessName.ToLower().Contains("teams") || p.ProcessName.ToLower().Contains("teamviewer") || p.ProcessName.ToLower().Contains("safari") || p.ProcessName.ToLower().Contains("extend") || p.ProcessName.ToLower().Contains("firefox") || p.ProcessName.ToLower().Contains("chrome") || p.ProcessName.ToLower().Contains("opera") || (p.ProcessName.ToLower().Contains("edge") && !p.ProcessName.ToLower().Contains("webview2")))
                    {
                        p.Kill();
                        return;
                    }
                }
                catch (Win32Exception w)
                {
                    Console.WriteLine(w.Message);
                    Console.WriteLine(w.ErrorCode.ToString());
                    Console.WriteLine(w.NativeErrorCode.ToString());
                    Console.WriteLine(w.StackTrace);
                    Console.WriteLine(w.Source);
                    Exception e = w.GetBaseException();
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}