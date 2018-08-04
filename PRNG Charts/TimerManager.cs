using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;

namespace PRNG_Charts
{
    public static class TimerManager
    {
        private static StringBuilder messageBuilder = new StringBuilder();
        private static Stopwatch timer = new Stopwatch();
        /*
        public static TimerManager()
        {
            messageBuilder = new StringBuilder();
            timer = new Stopwatch();
        }*/

        public static void TimerStart(String fileName)
        {
            timer.Reset();
            messageBuilder.Append(fileName);
            timer.Start();
        }

        public static void TimrStop()
        {
            timer.Stop();
            messageBuilder.Append(": " + timer.Elapsed + " ms");
            messageBuilder.Append(Environment.NewLine);
        }

        public static void ClearMessage()
        {
            messageBuilder.Clear();
        }

        public static void ShowMessage()
        {
            MessageBox.Show(messageBuilder.ToString(), "Czas generowanie poszczególnych plików");
        }
    }
}
