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
using System.IO;

namespace Foosball
{
    public partial class Counting_Goals : Form
    {
        VideoCapture capture;
        public int goalsCountTeam1 = 0;
        public int goalsCountTeam2 = 0;

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
                try
                {
                    capture = new Emgu.CV.VideoCapture(ofd.FileName);
                }
                catch(Exception ex) {
                    Console.WriteLine(ex);
                }
            }
            Application.Idle += ProcessFrameAndUpdateGUI;
            /*

            try
            {
                String videoDirectory = "./Resources/video_files/VID_20171020_093147.mp4";
                capture = new VideoCapture(videoDirectory);
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("Video file \"" + exception.Message + "\" could not be opened");
            }
            Application.Idle += ProcessFrameAndUpdateGUI;
            */
        }

        private void ProcessFrameAndUpdateGUI(object sender, EventArgs e)
        {
            Mat frame = capture.QueryFrame(); //one frame
            OutputScore();
            Thread.Sleep(1000 / 30);

            if (frame == null)
            {
                FinishGame();
                return;
            }
            else
            {

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

                    if (920 <= circle.Center.X && circle.Center.X <= 930 && 250 <= circle.Center.Y && circle.Center.Y <= 260)
                    {
                        goalsCountTeam1++;
                        textBoxXY.AppendText("Goal for Team 1");
                        textBoxXY.ScrollToCaret();
                    }
                    /*else if (70 <= circle.Center.X && circle.Center.X <= 80 && 450 <= circle.Center.X && circle.Center.Y <= 500)
                    {
                        goalsCountTeam2++;
                        textBoxXY.AppendText("Goal for Team 2");
                        textBoxXY.ScrollToCaret();
                    }*/
                    else
                    {
                        textBoxXY.AppendText("ball position x = " + circle.Center.X.ToString().PadLeft(4) + ", y = " + circle.Center.Y.ToString().PadLeft(4) + ", radius = " + circle.Radius.ToString("###.000").PadLeft(7));
                        // textBoxXY.AppendText("distance to goal x:" + (927 - circle.Center.X) + "distance to goal y:" + (257 - circle.Center.Y));
                        textBoxXY.ScrollToCaret();
                    }

                    CvInvoke.Circle(frame, new Point((int)circle.Center.X, (int)circle.Center.Y), (int)circle.Radius, new MCvScalar(0, 0, 255), 2);
                    CvInvoke.Circle(frame, new Point((int)circle.Center.X, (int)circle.Center.Y), 3, new MCvScalar(0, 255, 0), -1);
                }

                ibOriginal.Image = frame; //frame with detected ball
            }
        }

        private void FinishGame()
        {

            DialogResult dialogResult = MessageBox.Show("Do you want to exit?", "The Game is Over!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Leaderboards leadersBoard = new Leaderboards();
                leadersBoard.Show();
                this.Close();
                Application.Idle -= ProcessFrameAndUpdateGUI;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void OutputScore()
        {
            Start_Screen StartScreen = new Start_Screen();
            if (TextBoxGoalsTeam1.Text != "")
                TextBoxGoalsTeam1.AppendText(Environment.NewLine);

            //TextBoxGoalsTeam1.AppendText(text: StartScreen.Team1Name + " " + goalsCountTeam1.ToString());


            if (TextBoxGoalsTeam2.Text != "")
                TextBoxGoalsTeam2.AppendText(Environment.NewLine);

            //TextBoxGoalsTeam2.AppendText(text: StartScreen.Team2Name + " "  + goalsCountTeam2.ToString());

        }

        private void GoalsCountText_TextChanged(object sender, EventArgs e)
        {

        }

        private void EndGame_Click(object sender, EventArgs e)
        {
            ScoreInput scoreInput = new ScoreInput(goalsCountTeam1, goalsCountTeam2);
            this.Hide();
            scoreInput.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void PBGoalPlus1_Click(object sender, EventArgs e)
        {
            goalsCountTeam1++;
        }

        private void PBGoalMinus1_Click(object sender, EventArgs e)
        {
            if (goalsCountTeam1 > 0)
                goalsCountTeam1--;
        }

        private void PBGoalPlus2_Click(object sender, EventArgs e)
        {
            goalsCountTeam2++;
        }

        private void PBGoalMinus2_Click(object sender, EventArgs e)
        {
            if (goalsCountTeam1 > 0)
                goalsCountTeam1--;
        }


        private void ButtonLeaderboards_Click(object sender, EventArgs e)
        {

        }
    }
}
