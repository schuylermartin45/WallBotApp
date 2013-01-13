using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;
using System.Windows.Forms;
using System.Timers;
using Microsoft.Expression.Encoder.Live;
using System.Threading;
namespace WallBotApp
{
    //MSDN Libraries and examples:
    //http://msdn.microsoft.com/en-us/library/hh361683(v=office.14).aspx
    //http://msdn.microsoft.com/en-us/library/bb608250.aspx
    //Important: http://msdn.microsoft.com/en-us/library/hh361636(v=office.14).aspx

    /// <summary>
    /// Class that handles audio input commands from microphone in order to start/stop the recording of the video
    /// </summary>
    public class VoiceHandler
    {
        /// <summary>
        /// Handles recognition
        /// </summary>
        private SpeechRecognitionEngine compEars;
        
        /// <summary>
        /// Tracks time for the time-out event
        /// </summary>
        private System.Timers.Timer myTimer;

        /// <summary>
        /// Timeout of listening in milliseconds
        /// </summary>
        public static int timeOut = 4000;
        /// <summary>
        /// refresh rate for counting time
        /// </summary>
        public static int REFRESHRATE = 1000;
        /// <summary>
        /// Counts time. Tell your friends.
        /// </summary>
        private int clockTimeOut;

        /// <summary>
        /// Timeout of recording in milliseconds; set to 5 minutes
        /// </summary>
        public static int timeOutRecording = 3 * 60 * 1000;
        //use "new technique" to cap 3 minute recording
        private System.Timers.Timer recordingLimTimer;

        private static String startCmd = "start recording";
        private static String stopCmd = "stop recording";
        private bool isRecording = false;
        /// <summary>
        /// Local reference to the main form
        /// </summary>
        private mainScreen mainFrame;
        /// <summary>
        /// Delegate used to update gui text (% face)
        /// </summary>
        /// <param name="text"></param>
        private delegate void SetTextCallback(String text);

        /// <summary>
        /// Constructs VoiceHandler Object
        /// </summary>
        public VoiceHandler(mainScreen mainFrame)
        {
            //reference to the main program
            this.mainFrame = mainFrame;
            //prep for keeping track of the time-out
            myTimer = new System.Timers.Timer(REFRESHRATE); //remember: 1000 miliseconds in 1 second
            myTimer.Elapsed += new ElapsedEventHandler(IncrementEvent);
            //prep the timer for the video recording length
            recordingLimTimer = new System.Timers.Timer(timeOutRecording);
            recordingLimTimer.Elapsed += new ElapsedEventHandler(KillRecordingLimit);
            recordingLimTimer.Enabled = false;
            this.clockTimeOut = 0;
            //initialize the system that will handle voice recognition
            compEars = new SpeechRecognitionEngine();
            //set audio device specified elsewhere
            compEars.SetInputToDefaultAudioDevice();
            compEars.LoadGrammar(initGrammar());
            //add the event handler
            compEars.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
            //stop listening...which may or may not be started when constructed
            this.Stop();
        }

        /// <summary>
        /// Starts listening for commands
        /// </summary>
        public void Start()
        {
            //MessageBox.Show("Start Listening");
            //compEars.recog
            try
            {
                compEars.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Exception @ start recognition: " + ex.ToString());
            }
            //change the status of the WaLLBoT...if not recording
            if (isRecording == false)
            {
                this.SetTextStatus(mainScreen.BoTStatusStr[(int)mainScreen.BoTStatus.Listening]);
                //more in-your face message       
                Messenger thanks = new Messenger("WaLLBoT Listening");
                thanks.ShowDialog();
                //reset the confirmation for the next set of detecting
                this.SetTextCycle("Cycles confirmed: 0");
            }
            //start the time-out for listening
            this.StartTimeOut();
        }

        /// <summary>
        /// Stop listening for commands
        /// </summary>
        public void Stop()
        {
            compEars.RecognizeAsyncCancel();
        }

        /// <summary>
        /// Function that keeps track of time (for mic)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public virtual void IncrementEvent(object source, ElapsedEventArgs e)
        {
            this.clockTimeOut += VoiceHandler.REFRESHRATE;
            if (this.clockTimeOut >= VoiceHandler.timeOut)
            {
                if (this.isRecording == false)
                {
                    Messenger message = new Messenger("Mic has Timed out");
                    message.ShowDialog();
                    this.Stop();
                    this.stopRecord();
                }
            }
        }

        private void StartTimeOut()
        {
            //only start the Time-out process 
            if(isRecording == false)
                myTimer.Start();
        }
        /// <summary>
        /// Stop face handling
        /// </summary>
        public void StopTimeOut()
        {
            myTimer.Stop();
            //reset the time
            this.clockTimeOut = 0;
        }

        /// <summary>
        /// Function that executes once the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //test codez
            //MessageBox.Show(e.Result.Text);
            //MessageBox.Show(isRecording.ToString());
            if(e.Result.Text == VoiceHandler.startCmd)
            {
                //kill the time-out if the command has been picked up 
                this.StopTimeOut();
                if (isRecording == false)
                {
                    //start recording if command is said and not recording
                    this.startRecord();
                }
                //start listening for the next command to stop...if command is picked up by mistake
                //No longer needed in multiple-command mode
                //this.Start();
            }
            if((e.Result.Text == VoiceHandler.stopCmd) && (isRecording == true))
            {
                Messenger thanks = new Messenger("Message  Received");
                thanks.ShowDialog();
                //stop listening
                this.Stop();
                //stop recording and save file
                this.stopRecord();
            }
        }

        /// <summary>
        /// Starts the recording of the video
        /// </summary>
        private void startRecord()
        {
            this.isRecording = true;
            //change the status of the WaLLBoT
            this.SetTextStatus(mainScreen.BoTStatusStr[(int)mainScreen.BoTStatus.Recording]);
            //more in-your face message                
            Messenger message = new Messenger("WaLLBoT Recording");
            message.ShowDialog();
            //start the recoding limit of 5 minutes
            recordingLimTimer.Enabled = true;
            // Sets up publishing format for file archival type
            FileArchivePublishFormat fileOut = new FileArchivePublishFormat();
            // Sets file path and name
            //check the number of videos recorded at start by counting how many videos have been recorded
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(mainFrame.theSettings.savePath);
            mainFrame.numRecorded = dir.GetFiles().Length;
            fileOut.OutputFileName = mainFrame.theSettings.savePath + "Message_" + (mainFrame.numRecorded+1) + ".wmv";
            //prepares to publish the file, even as one of the 3 file types
            mainFrame.audVidJob.PublishFormats.Add(fileOut);
            // Start encoding (recording video)
            mainFrame.audVidJob.StartEncoding();
        }

        /// <summary>
        /// Stops the recording of the video
        /// </summary>
        private void stopRecord()
        {
            this.isRecording = false;
            //cut the 5min video timer (just in case) as well
            recordingLimTimer.Enabled = false;
            //video is being saved, stop counting the timeout
            this.StopTimeOut();
            //save the video
            //End the encoding process
            mainFrame.audVidJob.StopEncoding(); 
            //start the facial detection back up
            mainFrame.faceRecognizer.Start();
            //check the number of videos recorded at start by counting how many videos have been recorded
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(mainFrame.theSettings.savePath);
            mainFrame.numRecorded = dir.GetFiles().Length;
            this.SetVideoNumText(mainFrame.numRecorded.ToString());
        }

        /// <summary>
        /// Kill the video recording after 5 minutes
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void KillRecordingLimit(object source, ElapsedEventArgs e)
        {
            //invoke to end the video recording
            this.stopRecord();
        }

        /// <summary>
        /// Initializes the grammar to be used by the speech recognizer. Seperate from the constructor for orginization
        /// </summary>
        private Grammar initGrammar()
        {
            //words to be used to start/stop message recording
            Choices voiceCmd = new Choices();
            //add word commands to the choices
            voiceCmd.Add(new string[] {VoiceHandler.startCmd,VoiceHandler.stopCmd});
            //build the grammar system
            GrammarBuilder gramBuild = new GrammarBuilder();
            gramBuild.Append(voiceCmd);
            //return the finalized grammar system
            return(new Grammar(gramBuild));
        }

        //Thread-safe way to update the GUI text..b/c Microsoft
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
        private void SetVideoNumText(String text)
        {
            if (mainFrame.recordedLbl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetVideoNumText);
                mainFrame.Invoke(d, new object[] { text });
            }
            else
            {
                mainFrame.recordedLbl.Text = text;
            }
        }
    }
}
