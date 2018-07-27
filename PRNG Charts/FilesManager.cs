using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LiveCharts;
using System.Windows;

using CustomRandom;

namespace PRNG_Charts
{
    public class FilesManager
    {
        private void WriteToFile(String file, String message)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(message);
            }
        }
        
        public void RandomToFile(int seed, int range, int numberOfPRNGs)
        {
            TimerManager timer = new TimerManager();
            String file = "";
            StringBuilder stringBuilder = new StringBuilder();
            String content = "";
            AbstractRandom randomAbstract = new LCG();
            Random random = new Random(seed);
            
            for (int i = 0; i < 3; i++)
            {
                stringBuilder.Clear();
                if(i == 0)
                {
                    randomAbstract = new LCG();
                    randomAbstract.Srand((uint)seed);
                    file = "Pseudo Random Numbers LCG.csv";
                }
                else if(i == 1)
                {
                    randomAbstract = new LFG();
                    randomAbstract.Srand((uint)seed);
                    file = "Pseudo Random Numbers LFG.csv";
                }
                else if (i == 2)
                {
                    randomAbstract = new MSM();
                    randomAbstract.Srand((uint)seed);
                    file = "Pseudo Random Numbers MSM.csv";
                }

                timer.TimerStart(file);
                
                for (int j = 0; j < numberOfPRNGs; j++)
                {
                    stringBuilder.Append(randomAbstract.Next((uint)range));
                    stringBuilder.Append(Environment.NewLine);
                }

                timer.TimrStop();

                content = stringBuilder.ToString();
                WriteToFile(file, content);
            }

            file = "Pseudo Random Numbers Random C#.csv";
            stringBuilder.Clear();

            timer.TimerStart(file);

            for (int j = 0; j < numberOfPRNGs; j++)
            {
                stringBuilder.Append(random.Next(range));
                stringBuilder.Append(Environment.NewLine);
            }

            timer.TimrStop();
            MessageBox.Show(timer.ShowMessage(),"Czas generowanie poszczególnych plików");

            content = stringBuilder.ToString();
            WriteToFile(file, content);
        }

        public String[] ReadFile(String file)
        {
            String content;

            //ConsoleManager.Show();
            
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(file))
                {
                    // Read the stream to a string
                    content = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Nie można odczytać pliku, prawdopodobnie nie istnieje, wygeneruj plik.");
                return null;
            }
            
            //Console.WriteLine(content);
            //Console.Read();
            //ConsoleManager.Hide();

            return content.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries
                );
        }

        public ChartValues<int> CollectionFillFromFile(String file)
        {
            String[] fileContent;
            List<int> convertedContent = new List<int>();
            ChartValues<int> values = new ChartValues<int>();

            fileContent = ReadFile(file);

            if (fileContent == null) return values;

            //ConsoleManager.Show();

            for (int i = 0; i < fileContent.Count(); i++)
            {
                convertedContent.Add(int.Parse(fileContent[i]));
            }

            //Console.WriteLine("Max: " + convertedContent.Max());

            for (int i = 0; i < convertedContent.Max() + 1; i++)
            {
                values.Add(0);
                //Console.WriteLine("Wpisano" + values[i]);
            }

            for (int i = 0; i < convertedContent.Count; i++)
            {
                values[convertedContent[i]]++;
                //Console.WriteLine("Numer" + convertedContent[i] + " " + values[(int)convertedContent[i]]);
            }

            //Console.Read();
            //ConsoleManager.Hide();

            return values;
        }
    }
}
