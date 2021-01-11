using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWPFProject
{
    class ProgressReportModel
    {
        public int PercentageCompleted { get; set; }
        public List<WebsiteDataModel> DownloadedSites { get; set; } = new List<WebsiteDataModel>();
    }
}
