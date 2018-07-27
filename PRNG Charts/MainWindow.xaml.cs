using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using LiveCharts;
using LiveCharts.Wpf;

namespace PRNG_Charts
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        private FilesManager files = new FilesManager();
        private DataAnalysis dataAnalysis = new DataAnalysis();

        public SeriesCollection SeriesCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<int>()
                }
            };
            
            DataContext = this;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            comboBox.Items.Refresh();

            if (comboBox.Text == "Random C#")
            {
                SeriesCollection[0].Values = files.CollectionFillFromFile("Pseudo Random Numbers Random C#.csv");
            }
            else if (comboBox.Text == "LCG")
            {
                SeriesCollection[0].Values = files.CollectionFillFromFile("Pseudo Random Numbers LCG.csv");
            }
            else if (comboBox.Text == "LFG")
            {
                SeriesCollection[0].Values = files.CollectionFillFromFile("Pseudo Random Numbers LFG.csv");
            }
            else if (comboBox.Text == "MSM")
            {
                SeriesCollection[0].Values = files.CollectionFillFromFile("Pseudo Random Numbers MSM.csv");
            }
            else
            {
                SeriesCollection[0].Values = new ChartValues<int>();
            }
        }

        private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(textBoxSeed.Text, out int seed)
                && int.TryParse(textBoxRange.Text, out int range)
                && int.TryParse(textBoxNumberCount.Text, out int numberCount))
            {
                files.RandomToFile(seed, range, numberCount);
            }
            else
            {
                MessageBox.Show("Wartości przekazywane do generatora plików muszą być liczbami całkowitymi");
            }

        }

        private void ButtonAnalysis_Click(object sender, RoutedEventArgs e)
        {
            dataAnalysis.GetAnalysisMessage(SeriesCollection[0].Values);
        }
    }
}
