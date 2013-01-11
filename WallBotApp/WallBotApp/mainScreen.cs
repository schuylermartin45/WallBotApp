using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Video libs
using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
//for HandleRef Struct
using System.Runtime.InteropServices;

namespace WallBotApp
{
    public partial class mainScreen : Form
    {
        private List<String> vidDeviceLst;
        private List<String> audioDeviceLst;

        //device representation
        private EncoderDevice videoDevice;
        private EncoderDevice audioDevice;

        public LiveJob audVidJob;
        private LiveDeviceSource deviceSource;
        //private bool isRecording;

        //holds current settings
        public SettingsData theSettings;

        //timed system to check faces
        public FaceHandler faceRecognizer;
        //handles speech recognition
        public VoiceHandler voiceRecognizer;

        //enumerated types that represent the status of the WaLLBoT
        public enum BoTStatus {Detecting = 0, Listening, Recording};
        public static String[] BoTStatusStr = {"Detecting", "Listening","Recording"};
        public static Color[] BoTStatusColor = {Color.Purple, Color.SteelBlue, Color.DarkRed };
        
        //number of videos that have been recorded thus far
        public int numRecorded;

        public mainScreen()
        {
            InitializeComponent();

            //initilize a list of string equivalents of audio visual devices
            initDeviceList();

            //read the datta in 
            theSettings = Settings.readFile(audioDeviceLst, vidDeviceLst);

            //construct the values for the actual devices
            convertStringToDevice(theSettings);

            // Starts new job for preview window
            audVidJob = new LiveJob();
            
            // Create a new device source. We use the first audio and video devices on the system
            deviceSource = audVidJob.AddDeviceSource(videoDevice, audioDevice);
            // Sets preview window to winform panel hosted by xaml window
            deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(this.panel1, this.panel1.Handle));

            // Make this source the active one
            audVidJob.ActivateSource(deviceSource);

            //set text values for labels that allow the user how to use face detection
            this.coverLbl.Text = "Allow for " + (FaceHandler.SKINTHRESHOLD*100f) + "% coverage for";
            this.msLbl.Text = FaceHandler.REFRESHRATE + " milliseconds and";
            this.cycleLbl.Text = FaceHandler.CONFIRMFRAMES + " refresh cycles";
            this.curCycleLbl.Text = "Cycles confirmed: 0";
            this.statusLbl.Text = BoTStatus.Detecting.ToString();
            //check the number of videos recorded at start by counting how many videos have been recorded
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(theSettings.savePath); 
            this.numRecorded = dir.GetFiles().Length;
            this.recordedLbl.Text = numRecorded.ToString();
            //now that the form and it's members have been properly initialized, initialize and start the facial 
            //recognition system
            faceRecognizer = new FaceHandler(this);
            //initialize the speech recognition system but DO NOT START IT
            voiceRecognizer = new VoiceHandler(this);
            faceRecognizer.Start();
        }
        private void initDeviceList()
        {
            //bool to track recordings is initialized
            //isRecording = false;
            //lists of devices initialized
            vidDeviceLst = new List<String>();
            audioDeviceLst = new List<String>();
            //Generates lists of all audio and video devices currently hooked up into this computer
            foreach (EncoderDevice edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            {
                vidDeviceLst.Add(edv.Name);
            }
            foreach (EncoderDevice eda in EncoderDevices.FindDevices(EncoderDeviceType.Audio))
            {
                audioDeviceLst.Add(eda.Name);
            }
        }

        //take the string of the device chosen (from the GUI) and return the audio/video devices we need
        private void convertStringToDevice(SettingsData theSettings)
        {
            foreach (EncoderDevice edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            {
                if(edv.Name == theSettings.vidDev)
                {
                    videoDevice = edv;
                    //break to stop looping
                    break;
                }
            }
            foreach (EncoderDevice eda in EncoderDevices.FindDevices(EncoderDeviceType.Audio))
            {
                if (eda.Name == theSettings.audioDev)
                {
                    audioDevice = eda;
                    //break to stop looping
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings toOpen = new Settings(audioDeviceLst,vidDeviceLst,deviceSource);
            DialogResult result1 = toOpen.ShowDialog(this);
            if (result1 == DialogResult.OK)
            {
                //change the settings to whatever is currently in the file (may have been written/changed in the settings menu)
                DialogResult result2 = MessageBox.Show("Restart program now to apply changes?", "Restart needed", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                {
                    //kill all the threads!
                    Application.ExitThread();
                    //Restart now
                    Application.Restart();
                }
            }
        }
        /*
        private void recordBtn_Click(object sender, EventArgs e)
        {
            //Record button is a test-event for recording messages, prior to the use of more interesting events            
            //flip the isRecording value
            isRecording = !isRecording;
            //control to start/stop recording
            if (isRecording)
            {
                // Sets up publishing format for file archival type
                FileArchivePublishFormat fileOut = new FileArchivePublishFormat();

                // Sets file path and name
                fileOut.OutputFileName = String.Format(theSettings.savePath + "Message_Recording{0:MM_dd_yy_hhmmss}" + theSettings.fileType, DateTime.Now);
                //prepares to publish the file, even as one of the 3 file types
                audVidJob.PublishFormats.Add(fileOut);
                
                // Start encoding (recording video)
                audVidJob.StartEncoding();
                //recording status changed
                this.label1.Text = "Recording...";
                this.recordBtn.Text = "Stop";
            }
            else
            {
                //End the encoding process
                audVidJob.StopEncoding();
                //recording status changed
                this.label1.Text = "";
                this.recordBtn.Text = "Record";
            }
        }
        */
        //change the color of the status label when the text is changed elsewhere
        private void ChangeStatusTxt(object sender, EventArgs e)
        {
            switch (this.statusLbl.Text)
            {
                case "Detecting": this.statusLbl.ForeColor = mainScreen.BoTStatusColor[(int)mainScreen.BoTStatus.Detecting];
                    break;
                case "Listening": this.statusLbl.ForeColor = mainScreen.BoTStatusColor[(int)mainScreen.BoTStatus.Listening];
                    break;
                case "Recording": this.statusLbl.ForeColor = mainScreen.BoTStatusColor[(int)mainScreen.BoTStatus.Recording];
                    break;
            }
        }
        /*
        private void CptrImgBtn_Click(object sender, EventArgs e)
        {
            //bitmap that will record image
            Bitmap imageToTest = new Bitmap(this.panel1.Width, this.panel1.Height,this.panel1.CreateGraphics());
            //graphics pulls the actual drawing data from the program
            Graphics gr = Graphics.FromImage(imageToTest);
            //calculate the TRUE location of the image frame, relative to the frame it's in and not from the actual screen
            Point relativeLocation = new Point(0,0);
            relativeLocation.X = this.Location.X + this.panel1.Location.X + 3; // correction for frame border...cannot find constant for that in windows
            relativeLocation.Y = this.Location.Y + this.panel1.Location.Y + 27; //System.Windows.Forms.SystemInformation.FrameBorderSize.Height;
            //copies the specified region  from the program form
            gr.CopyFromScreen(relativeLocation, Point.Empty, panel1.Bounds.Size);
            //process the colors of the image to show an image equivalent of how the face looks
            Bitmap outImg = YCbCr.PercentFaceBmp(imageToTest);
            float percentFloat = YCbCr.PercentFace(imageToTest);
            double percent = Math.Round((double)percentFloat * 100.0,2); 
            this.label2.Text = "Processing: " + percent + "% Face";
            this.pictureBox1.Image = outImg;
        }
        */
    }
}