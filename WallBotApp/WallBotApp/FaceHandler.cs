using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;

namespace WallBotApp
{
    /// <summary>
    /// Class that handles the majority of the face detecting algorithm
    /// </summary>
    /// 
    public class FaceHandler
    {
        /// <summary>
        /// percentage of the screen that the face should use
        /// </summary>
        //public static float SKINTHRESHOLD = 0.15f;
        /// <summary>
        /// number of consequative confirmations of face to trigger audio event
        /// </summary>
        //public static int CONFIRMFRAMES = 3; //3
        /// <summary>
        /// refresh rate for checking for faces
        /// </summary>
        //public static int REFRESHRATE = 500;
        
        /// <summary>
        /// Tracks if the last frame made the threshold
        /// </summary>
        private bool lastFrameThresh;

        /// <summary>
        /// cntr for consecuative threshold checks
        /// </summary>
        private int threshCntr;

        /// <summary>
        /// Tracks time for events
        /// </summary>
        private System.Timers.Timer myTimer;

        /// <summary>
        /// Local reference to the main form
        /// </summary>
        private mainScreen mainFrame;

        /// <summary>
        /// Delegate used to update gui text (% face)
        /// </summary>
        /// <param name="text"></param>
        private delegate void SetTextCallback(String text);

        public FaceHandler(mainScreen mainFrame)
        {
            myTimer = new System.Timers.Timer(mainFrame.theSettings.msRefresh); //remember: 1000 miliseconds in 1 second
            myTimer.Elapsed += new ElapsedEventHandler(IncrementEvent);
            //initialize dat shit
            this.mainFrame = mainFrame;
            this.lastFrameThresh = false;
            this.threshCntr = 0;
            //start the timer in main program, probably right after this is initialized
        }

        /// <summary>
        /// Start face handling
        /// </summary>
        public void Start()
        {
            myTimer.Start();
            //change the status of the WaLLBoT...
            this.SetTextStatus(mainScreen.BoTStatusStr[(int)mainScreen.BoTStatus.Detecting]);
        }
        /// <summary>
        /// Stop face handling
        /// </summary>
        public void Stop()
        {
            myTimer.Stop();
            //and make sure it's dead!
            //myTimer.Close();
            this.threshCntr = 0;
            this.lastFrameThresh = false;
        }

        /// <summary>
        /// Function that "runs" the FaceHandler...it handles faces in time
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public virtual void IncrementEvent(object source, ElapsedEventArgs e)
        {
            //code that process image goes here...
            //bitmap that will record image
            Bitmap imageToTest = new Bitmap(mainFrame.panel1.Width, mainFrame.panel1.Height, mainFrame.panel1.CreateGraphics());
            //graphics pulls the actual drawing data from the program
            Graphics gr = Graphics.FromImage(imageToTest);
            //calculate the TRUE location of the image frame, relative to the frame it's in and not from the actual screen
            Point relativeLocation = new Point(0, 0);
            relativeLocation.X = mainFrame.Location.X + mainFrame.panel1.Location.X + 3; // correction for frame border...cannot find constant for that in windows
            relativeLocation.Y = mainFrame.Location.Y + mainFrame.panel1.Location.Y + 27; //System.Windows.Forms.SystemInformation.FrameBorderSize.Height;
            //copies the specified region  from the program form
            gr.CopyFromScreen(relativeLocation, Point.Empty, mainFrame.panel1.Bounds.Size);
            //process the colors of the image to show an image equivalent of how the face looks
            //Bitmap outImg = YCbCr.PercentFaceBmp(imageToTest);
            //float percentFloat = YCbCr.PercentFace(imageToTest);
            YCbCr.VisualPercent convertedMap = YCbCr.PercentFaceBoth(imageToTest,this.mainFrame.theSettings.minYCbCr,this.mainFrame.theSettings.maxYCbCr);
            double percent = Math.Round((double)convertedMap.PERCENT * 100.0, 2);
            //mainFrame.label2.Text = "Processing: " + percent + "% Face";
            //thread-safe way:
            this.SetTextPercent("Processing: " + percent + "% Skin");
            mainFrame.pictureBox1.Image = convertedMap.MAP;

            //compare the calculated percent of skin against the threshold
            if (convertedMap.PERCENT >= this.mainFrame.theSettings.percentSkin)
            {

                if (this.lastFrameThresh == true)
                {
                    //increment then the threshold continues to be true for multiple frames in a row
                    this.threshCntr++;
                    //update the visual cntr
                    this.SetTextCycle("Cycles confirmed: " + threshCntr);
                    //if the threshCntr meets the consecuative frame check
                    if (this.threshCntr == this.mainFrame.theSettings.cycleConfirm)
                    {
                        //kill this event for now
                        this.Stop();
                        //start listening for sound/audio commands
                        //MessageBox.Show("FACE CONFIRMED");
                        mainFrame.voiceRecognizer.Start();
                        //start this event back up either after the audio commands have failed or when the video has been finished recording
                    }
                }
                //this current frame, which is now "over" did trip the counter
                this.lastFrameThresh = true;
            }
            else
            {
                //reset if failed
                this.lastFrameThresh = false;
                this.threshCntr = 0;
                //update the visual cntr
                this.SetTextCycle("Cycles confirmed: " + threshCntr);
            }
        }
        
        //Thread-safe way to update the GUI text..b/c Microsoft
        private void SetTextPercent(String text)
        {
            if (mainFrame.label2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextPercent);
                mainFrame.Invoke(d, new object[] { text });
            }
            else
            {
                mainFrame.label2.Text = text;
            }
        }
        private void SetTextCycle(String text)
        {
            if (mainFrame.curCycleLbl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextCycle);
                mainFrame.Invoke(d, new object[] { text });
            }
            else
            {
                mainFrame.curCycleLbl.Text = text;
            }
        }
        private void SetTextStatus(String text)
        {
            if (mainFrame.statusLbl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextStatus);
                mainFrame.Invoke(d, new object[] { text });
            }
            else
            {
                mainFrame.statusLbl.Text = text;
            }
        }
    }
}
