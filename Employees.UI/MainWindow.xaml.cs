using System.Windows;
using Microsoft.Win32;
using Employees.Core.Services;

namespace Employees.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadCsv_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                FilePathText.Text = dialog.FileName;

                var logs = CsvLoader.Load(dialog.FileName);
                var results = OverlapCalculator.Calculate(logs);

                GridResults.ItemsSource = results;

                var best = OverlapCalculator.FindBestPair(results);

                BestPairText.Text =
                    $"Best Pair: {best.EmpId1} & {best.EmpId2} — {best.TotalDays} days";
            }
        }
    }
}