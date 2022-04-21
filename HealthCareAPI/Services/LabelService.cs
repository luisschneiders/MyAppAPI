using System;
using System.Net;
using System.Text;
using LabelLibrary;
using LabelLibrary.Models;

namespace HealthCareAPI.Services
{
    public class LabelService
    {
        private string _labelMop { get; set; } = String.Empty;
        private LabelBuilder _labelBuilder = new();

        public async Task<string> PostAsync(LabelMop labelMop)
        {
            _labelMop = _labelBuilder.BuildLabelMop(labelMop, 1);

            byte[] zpl = Encoding.UTF8.GetBytes(_labelMop);

            // adjust print density (8dpmm), label width (4 inches), label height (6 inches), and label index (0) as necessary
            var request = (HttpWebRequest)WebRequest.Create("https://api.labelary.com/v1/printers/8dpmm/labels/3x2/0/");
            request.Method = "POST";
            //request.Accept = "application/pdf"; // omit this line to get PNG images back
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = zpl.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(zpl, 0, zpl.Length);
            requestStream.Close();

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();
                var fileStream = File.Create("Labels/lfs_label_model_001.png"); // change file name for PNG images
                responseStream.CopyTo(fileStream);
                responseStream.Close();
                fileStream.Close();
                await Task.CompletedTask;
            }
            catch (WebException e)
            {
                Console.WriteLine("Error: {0}", e.Status);
                await Task.CompletedTask;
            }

            return _labelMop;
        }
    }
}
