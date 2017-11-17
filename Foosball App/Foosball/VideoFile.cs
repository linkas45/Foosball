using System;
using Emgu.CV;

namespace Foosball
{
    public class VideoFile
    {
        public VideoCapture capture;

        public VideoFile(String file)
        {
            this.capture = new VideoCapture(file);
        }

        public Mat GetFrame()
        {
            return this.capture.QueryFrame();
        }

        public void Dispose()
        {
            this.capture.Stop();
        }
    }
}
