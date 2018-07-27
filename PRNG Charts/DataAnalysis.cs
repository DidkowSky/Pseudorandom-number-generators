using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LiveCharts;

namespace PRNG_Charts
{
    class DataAnalysis
    {
        private StringBuilder messageBuilder = new StringBuilder();

        public StringBuilder MessageBuilder { get => messageBuilder; set => messageBuilder = value; }

        public void GetAnalysisMessage(IChartValues values)
        {
            ClearMessage();
            try
            { 
                AverageValue(values);
                MedianValue(values);

                MessageBox.Show(MessageBuilder.ToString());
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Brak danych. Wybierz generator z listy.");
            }
        }

        private void AverageValue(IChartValues values)
        {
            int sum = 0;
                        
            for(int i = 0; i < values.Count; i++)
            {
                sum += (int.Parse(values[i].ToString()) * i);
            }

            UpdateMessage("Suma: " + sum);
            UpdateMessage("Średnia: " + sum / values.Count);          
        }

        private void MedianValue(IChartValues values)
        {
            int median = 0;
            int count = 0;

            for(int i = 0; i < values.Count; i++)
            {
                count += int.Parse(values[i].ToString());
            }

            UpdateMessage("Ilość elementów listy: " + count);
            count /= 2;
            count -= 1;

            for (int i = 0; i < values.Count; i++) {
                median += int.Parse(values[i].ToString());
                if (median > count)
                    break;
            }
            UpdateMessage("Mediana: " + median);
        }

        private void UpdateMessage(String content)
        {
            this.MessageBuilder.Append(content);
            this.MessageBuilder.Append(Environment.NewLine);
        }

        private void ClearMessage()
        {
            this.MessageBuilder.Clear();
        }
    }
}
