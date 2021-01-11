using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncWPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource cts = new CancellationTokenSource();
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExecuteSync_Click(object sender, RoutedEventArgs e)
        {
            var results = WebsiteRepo.normalExecute();
            display(results);
        }


        private async void ExecuteAsync_Click(object sender, RoutedEventArgs e)
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += ReportProgress;
            try
            {
                var results = await WebsiteRepo.asyncExecute(progress, cts.Token);
                display(results);
            }
            catch(Exception)
            {
                resultsWindow.Text = "Task Cancelled";
            }
          
        }

        private async void ExecuteParallelAsync_Click(object sender, RoutedEventArgs e)
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += ReportProgress;
            try
            {
                var results = await WebsiteRepo.ParallelExecute(progress, cts.Token);
                display(results);
            }
            catch(Exception)
            {
                resultsWindow.Text = "Task Cancelled";
            }
        }

        private void CancelOperation_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            dashboardProgress.Value = e.PercentageCompleted;
            display(e.DownloadedSites);
        }

        private void display(List<WebsiteDataModel> results)
        {
            resultsWindow.Text = "";
            foreach (var item in results)
            {
                resultsWindow.Text += $"{ item.websiteUrl } downloaded: { item.websiteData.Length } characters long.{ Environment.NewLine }";
            }
        }
    }
}
