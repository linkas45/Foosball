using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Foosball
{
    public static class BallRecognition
    {
        /// <summary>
        /// Detects circle/ball in given frame
        /// </summary>
        /// <param name="frame"></param>
        public static CircleF[] DetectBall(Mat frame)
        {
            Mat imgHSV = new Mat(frame.Size, DepthType.Cv8U, 3);

            Mat imgThreshLow = new Mat(frame.Size, DepthType.Cv8U, 1);
            Mat imgThreshHigh = new Mat(frame.Size, DepthType.Cv8U, 1);
            Mat imgThresh = new Mat(frame.Size, DepthType.Cv8U, 1);

            //frame is converted from BGR to HSV
            CvInvoke.CvtColor(frame, imgHSV, ColorConversion.Bgr2Hsv);

            //filters out colors
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(0, 165, 165)), new ScalarArray(new MCvScalar(25, 255, 255)), imgThreshLow);
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(0, 165, 165)), new ScalarArray(new MCvScalar(25, 255, 255)), imgThreshHigh);

            //unneeded colors are filtered out //white color-ball, black color-everything else
            CvInvoke.Add(imgThreshLow, imgThreshHigh, imgThresh);
            CvInvoke.GaussianBlur(imgThresh, imgThresh, new Size(3, 3), 0); //blurs frame using a Gaussian filter

            Mat structuringElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));

            //fills small holes in the foreground
            CvInvoke.Dilate(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));
            CvInvoke.Erode(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));

            //finds circle/ball in frame
            CircleF[] circles = CvInvoke.HoughCircles(imgThresh, HoughType.Gradient, 2.0, imgThresh.Rows / 4, 100, 30, 8, 50);

            return cirles;
        }
    }
}