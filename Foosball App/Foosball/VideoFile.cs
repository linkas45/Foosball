using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.IO;

namespace Foosball
{
    public class VideoFile
    {
        public VideoCapture capture;

        public VideoFile(String file)
        {
            this.capture = new VideoCapture(file);
        }

        public Math GetFrame()
        {
            return this.capture.QueryFrame();
        }

        public void Dispose()
        {
            this.capture.Stop();
        }
    }
}
