using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerDemo
{
    public delegate void OnVideoUploaded();

    internal class Video
    {
        public OnVideoUploaded onVideoUploaded;
        public string Name { get; set; }

        public Video(string name)
        {
            Name = name;
        }

        public void UploadVideo()
        {
            Console.WriteLine("Uploading video");
            Thread.Sleep(1000);
            Console.WriteLine("Video uploaded");
            onVideoUploaded();
        }
    }
}
