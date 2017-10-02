extern alias Drawing;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Emgu.CV;
using Android.OS;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
using System;


namespace Foosball.Droid
{
	[Activity (Label = "Foosball", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
        MediaRecorder recorder;
        VideoCapture capture;

        protected override void OnCreate (Bundle bundle)
		{

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new Foosball.App ());

            SetContentView(Resource.Layout.Main);

            var record = FindViewById<Button>(Resource.Id.record);
            var video = FindViewById<VideoView>(Resource.Id.videoView);

            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/test.mp4";


             record.Click += delegate
             {

                
                 video.StopPlayback();

                 recorder = new MediaRecorder();
                 recorder.SetVideoSource(VideoSource.Camera);
                 recorder.SetAudioSource(AudioSource.Mic);
                 recorder.SetOutputFormat(OutputFormat.Default);
                 recorder.SetVideoEncoder(VideoEncoder.Default);
                 recorder.SetAudioEncoder(AudioEncoder.Default);
                 recorder.SetOutputFile(path);
                 recorder.SetPreviewDisplay(video.Holder.Surface);
                 recorder.SetVideoFrameRate(30);
                 recorder.Prepare();
                 recorder.Start();
                
             };
             
            

        }
        private void ProcessFrameAndUpdateGUI(object sender, EventArgs e)
        {
            Mat frame = capture.QueryFrame();

            Mat imgHSV = new Mat(200, 400, DepthType.Cv8U, 3);
            Mat imgThreshLow = new Mat(200, 400, DepthType.Cv8U, 1);
            Mat imgThreshHigh = new Mat(200, 400, DepthType.Cv8U, 1);
            Mat imgThresh = new Mat(200, 400, DepthType.Cv8U, 1);

            CvInvoke.CvtColor(frame, imgHSV, ColorConversion.Bgr2Hsv); //frame converted from BGR to HSV

            //filtering out colors
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(0, 165, 165)), new ScalarArray(new MCvScalar(25, 255, 255)), imgThreshLow);
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(0, 165, 165)), new ScalarArray(new MCvScalar(25, 255, 255)), imgThreshHigh);

            CvInvoke.Add(imgThreshLow, imgThreshHigh, imgThresh);

            CvInvoke.MedianBlur(imgThresh, imgThresh, 7); //filtering

            Mat structuringElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Drawing.System.Drawing.Size(3, 3), new Drawing.System.Drawing.Point(-1, -1));


            //filling small holes in the foreground
            CvInvoke.Dilate(imgThresh, imgThresh, structuringElement, new Drawing.System.Drawing.Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));
            CvInvoke.Erode(imgThresh, imgThresh, structuringElement, new Drawing.System.Drawing.Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));



            //finding circle/ball
            CircleF[] circles = CvInvoke.HoughCircles(imgThresh, HoughType.Gradient, 2.0, imgThresh.Rows / 4, 100, 30, 8, 50);

            foreach (CircleF circle in circles) //drawing circle and writing XYRadius
            {

                CvInvoke.Circle(frame, new Drawing.System.Drawing.Point((int)circle.Center.X, (int)circle.Center.Y), (int)circle.Radius, new MCvScalar(0, 0, 255), 2);
                CvInvoke.Circle(frame, new Drawing.System.Drawing.Point((int)circle.Center.X, (int)circle.Center.Y), 3, new MCvScalar(0, 255, 0), -1);
            }
        }

    }
}

