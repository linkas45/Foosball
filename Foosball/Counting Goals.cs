using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Foosball
{
    public partial class Counting_Goals : Form
    {
        VideoCapture capture;
        public int goalsCount = 0;

        public Counting_Goals()
        {
            InitializeComponent();
        }

        private void Counting_Goals_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video Files |*.mp4";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                capture = new Emgu.CV.VideoCapture(ofd.FileName);
            }
            Application.Idle += ProcessFrameAndUpdateGUI;

        }

        private void ProcessFrameAndUpdateGUI(object sender, EventArgs e)
        {
            Mat frame = capture.QueryFrame(); //one frame
            OutputScore();
            Thread.Sleep(1000 / 30);

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
                if (textBoxXY.Text != "")
                {
                    textBoxXY.AppendText(Environment.NewLine);
                }

                textBoxXY.AppendText("ball position x = " + circle.Center.X.ToString().PadLeft(4) + ", y = " + circle.Center.Y.ToString().PadLeft(4) + ", radius = " + circle.Radius.ToString("###.000").PadLeft(7));
                textBoxXY.ScrollToCaret();
                
                CvInvoke.Circle(frame, new Point((int)circle.Center.X, (int)circle.Center.Y), (int)circle.Radius, new MCvScalar(0, 0, 255), 2);
                CvInvoke.Circle(frame, new Point((int)circle.Center.X, (int)circle.Center.Y), 3, new MCvScalar(0, 255, 0), -1);
            }

            ibOriginal.Image = frame; //frame with detected ball
        }

        private void OutputScore()
        {
            if (GoalsCountText.Text != "")
                GoalsCountText.AppendText(Environment.NewLine);

                GoalsCountText.AppendText(text: "Current goals count: " + goalsCount.ToString());
             

        }

        private void GoalsCountText_TextChanged(object sender, EventArgs e)
        {

        }

        private void EndGame_Click(object sender, EventArgs e)
        {
            ScoreInput scoreInput = new ScoreInput(goalsCount);
            this.Hide();
            scoreInput.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
