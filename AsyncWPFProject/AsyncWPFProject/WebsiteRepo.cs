using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWPFProject
{

    class WebsiteRepo
    {

        public static List<string> PrepData()
        {
            List<string> output = new List<string>();

            output.Add("https://www.yahoo.com");
            output.Add("https://www.google.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.cnn.com");
            output.Add("https://www.amazon.com");
            output.Add("https://www.facebook.com");

            output.Add("https://www.codeproject.com");
            output.Add("https://www.stackoverflow.com");
            output.Add("https://en.wikipedia.org/wiki/.NET_Framework");

            return output;
        }


        public static List<WebsiteDataModel> normalExecute()
        {
            List<string> websiteList = PrepData();
            WebsiteDataModel obj = new WebsiteDataModel();
            List<WebsiteDataModel> list1 = new List<WebsiteDataModel>();
            foreach (var website in websiteList)
            {
                obj = DownloadWebsite(website);
                list1.Add(obj);
            }
            return list1;
        }

        public static async Task<List<WebsiteDataModel>> ParallelExecute(IProgress<ProgressReportModel> progress, CancellationToken t)
        {
            List<string> websiteList = PrepData();
            WebsiteDataModel obj = new WebsiteDataModel();
            ProgressReportModel report = new ProgressReportModel();
            List<WebsiteDataModel> list1 = new List<WebsiteDataModel>();
            await Task.Run(()=>{ 
            Parallel.ForEach(websiteList, (website)=>
            {
                obj = DownloadWebsite(website);
                t.ThrowIfCancellationRequested();
                list1.Add(obj);


                report.PercentageCompleted = (list1.Count * 100) / websiteList.Count();
                report.DownloadedSites = list1;
                progress.Report(report);
            });
            });
            return list1;
        }



        public static async Task<List<WebsiteDataModel>> asyncExecute(IProgress<ProgressReportModel> progress,CancellationToken t)
        {
            List<string> websiteList = PrepData();
            WebsiteDataModel obj = new WebsiteDataModel();
            ProgressReportModel report = new ProgressReportModel();
            List<WebsiteDataModel> list1 = new List<WebsiteDataModel>();
            foreach (var website in websiteList)
            {
                obj = await DownloadWebsiteAsync(website);

                t.ThrowIfCancellationRequested();
                list1.Add(obj);
                
                report.PercentageCompleted = (list1.Count * 100) / websiteList.Count();
                report.DownloadedSites = list1;
                progress.Report(report);
            }
            return list1;
        }

        public static async Task<WebsiteDataModel> DownloadWebsiteAsync(string website)
        {
            WebClient client = new WebClient();
            WebsiteDataModel op = new WebsiteDataModel();
            op.websiteData = await client.DownloadStringTaskAsync(website);
            op.websiteUrl = website;

            return op;
        }

        public static WebsiteDataModel DownloadWebsite(string website)
        {
            WebClient client = new WebClient();
            WebsiteDataModel op = new WebsiteDataModel();
            op.websiteData = client.DownloadString(website);
            op.websiteUrl = website;

            return op;
         }

    }
}
