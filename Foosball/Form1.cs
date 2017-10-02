﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure; 
using Emgu.CV.UI;
using Emgu.CV.Cvb;


namespace Foosball
{
    public partial class Form1 : Form
    {

        VideoCapture capture;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                String videoDirectory = "C:/Users/Migle/source/Foosball/Foosball/video_files/video-1506004806.mp4";
                capture = new VideoCapture(videoDirectory);
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("Video file \"" + exception.Message + "\" could not be opened");
            }
            Application.Idle += ProcessFrameAndUpdateGUI;
        }

        private void ProcessFrameAndUpdateGUI(object sender, EventArgs e)
        {
            Mat frame = capture.QueryFrame(); //one frame

            if (frame == null)
            {
                Environment.Exit(0);
                return;
            }

            Mat imgHSV = new Mat(frame.Size, DepthType.Cv8U, 3);

            Mat imgThreshLow = new Mat(frame.Size, DepthType.Cv8U, 1);
            Mat imgThreshHigh = new Mat(frame.Size, DepthType.Cv8U, 1);
            Mat imgThresh = new Mat(frame.Size, DepthType.Cv8U, 1);


            CvInvoke.CvtColor(frame, imgHSV, ColorConversion.Bgr2Hsv); //frame converted from BGR to HSV

            //filtering out colors
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(0, 165, 165)), new ScalarArray(new MCvScalar(25, 255, 255)), imgThreshLow);
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(0, 165, 165)), new ScalarArray(new MCvScalar(25, 255, 255)), imgThreshHigh);

            CvInvoke.Add(imgThreshLow, imgThreshHigh, imgThresh);

            CvInvoke.GaussianBlur(imgThresh, imgThresh, new Size(3, 3), 0); //filtering

            Mat structuringElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));

            //filling small holes in the foreground
            CvInvoke.Dilate(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));
            CvInvoke.Erode(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));



            //finding circle/ball
            CircleF[] circles = CvInvoke.HoughCircles(imgThresh, HoughType.Gradient, 2.0, imgThresh.Rows / 4, 100, 30, 8, 50);

            foreach (CircleF circle in circles) //drawing circle and writing XYRadius
            {
                if (textBoxXYRadius.Text != "")
                {
                    textBoxXYRadius.AppendText(Environment.NewLine);
                }

                textBoxXYRadius.AppendText("ball position x = " + circle.Center.X.ToString().PadLeft(4) + ", y = " + circle.Center.Y.ToString().PadLeft(4) + ", radius = " + circle.Radius.ToString("###.000").PadLeft(7));
                textBoxXYRadius.ScrollToCaret();

                CvInvoke.Circle(frame, new Point((int)circle.Center.X, (int)circle.Center.Y), (int)circle.Radius, new MCvScalar(0, 0, 255), 2);
                CvInvoke.Circle(frame, new Point((int)circle.Center.X, (int)circle.Center.Y), 3, new MCvScalar(0, 255, 0), -1);
            }

            ibOriginal.Image = frame; //frame with detected ball
            ibThresh.Image = imgThresh;
        }

    }
}
