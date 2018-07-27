using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PRNG_Charts
{
    public class TimerManager
    {
        private StringBuilder messageBuilder;
        private Stopwatch timer;

        public TimerManager()
        {
            messageBuilder = new StringBuilder();
            timer = new Stopwatch();
        }

        public void TimerStart(String fileName)
        {
            timer.Reset();
            messageBuilder.Append(fileName);
            timer.Start();
        }

        public void TimrStop()
        {
            timer.Stop();
            messageBuilder.Append(": " + timer.Elapsed + " ms");
            messageBuilder.Append(Environment.NewLine);
        }

        public void ClearMessage()
        {
            messageBuilder.Clear();
        }

        public String ShowMessage()
        {
            return messageBuilder.ToString();
        }
    }
}
