using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder.Devices;

//for HandleRef Struct
using System.Runtime.InteropServices;


namespace WallBotApp
{
    public partial class Settings : Form
    {
        private List<String> audioDeviceLst;
        private List<String> vidDeviceLst;

        //values stored in the file, loaded from the save and then changed to be written again
        private SettingsData settings;
        private LiveDeviceSource deviceSource;

        //stores settings related to skin detection
        public YCbCr minYCbCr;
        public YCbCr maxYCbCr;
        public float percentSkin;
        public int msRefresh;
        public int cycleConfirm;

        public Settings(List<String> audioDeviceLst, List<String> vidDeviceLst, LiveDeviceSource deviceSource)
        {
            InitializeComponent();
            this.deviceSource = deviceSource;
            this.audioDeviceLst = audioDeviceLst;
            this.vidDeviceLst = vidDeviceLst;
            //then populate the GUI
            populateComboBoxes();
            //load values into the program from a file
            readFile();
            //display the current path/options to the GUI to the GUI
            pathBox.Text = settings.savePath;
            audioDevBox.SelectedItem = settings.audioDev;
            vidDevBox.SelectedItem = settings.vidDev;
            //fill local variables with the versions just read from the XML file
            this.minYCbCr = settings.minYCbCr;
            this.maxYCbCr = settings.maxYCbCr;
            this.percentSkin = settings.percentSkin;
            this.msRefresh = settings.msRefresh;
            this.cycleConfirm = settings.cycleConfirm;
            //Display the color data
            displayColorTextBox();

            //set ok/cancel btns
            this.saveBtn.DialogResult = DialogResult.OK;
            this.cancelBtn.DialogResult = DialogResult.Cancel;
        }

        //Fills the gui with current color values
        private void displayColorTextBox()
        {
            //Y
            this.minYBox.Text = this.minYCbCr.Y.ToString();
            this.maxYBox.Text = this.maxYCbCr.Y.ToString();
            //Cb
            this.minCbBox.Text = this.minYCbCr.Cb.ToString();
            this.maxCbBox.Text = this.maxYCbCr.Cb.ToString();
            //Cr
            this.minCrBox.Text = this.minYCbCr.Cr.ToString();
            this.maxCrBox.Text = this.maxYCbCr.Cr.ToString();
            //other 3 values
            this.percentSkinBox.Text = this.percentSkin.ToString();
            this.refreshBox.Text = this.msRefresh.ToString();
            this.cycleBox.Text = this.cycleConfirm.ToString();
        }

        private void recordColorTextBox()
        {
            //YCbCr
            this.minYCbCr = new YCbCr(Convert.ToInt32(this.minYBox.Text), Convert.ToInt32(this.minCbBox.Text), Convert.ToInt32(this.minCrBox.Text));
            this.maxYCbCr = new YCbCr(Convert.ToInt32(this.maxYBox.Text), Convert.ToInt32(this.maxCbBox.Text), Convert.ToInt32(this.maxCrBox.Text));
            //other 3 values
            this.percentSkin = Convert.ToSingle(this.percentSkinBox.Text);
            this.msRefresh = Convert.ToInt32(this.refreshBox.Text);
            this.cycleConfirm = Convert.ToInt32(this.cycleBox.Text);
        }

        private void readFile()
        {
            //check if the config file exists; if not, create a default config file
            if (File.Exists(Application.StartupPath + @"\config.xml") == false)
            {
                String generateSavePath = @"C:\Users\" + Environment.UserName + @"\Videos\WaLLBoT Recordings\";
                //generate a default save path based on the user that is currently logged in
                System.IO.Directory.CreateDirectory(generateSavePath);
                //write a new file based on the default
                writeFile(new SettingsData(this.audioDeviceLst[0], this.vidDeviceLst[0], generateSavePath, new YCbCr(50, 124, 130), new YCbCr(90, 140, 140), 0.15f, 500, 3));
            }
            
            //now that the file is existent, make
            XmlSerializer deserializer = new XmlSerializer(typeof(SettingsData));
            TextReader textReader = new StreamReader(Application.StartupPath + @"\config.xml");
            settings = (SettingsData)deserializer.Deserialize(textReader);
            textReader.Close();
        }
        //overload that allows us to read the file from an outside program; returns a new list of settings to be utilized
        public static SettingsData readFile(List<String> audioDeviceLst, List<String> vidDeviceLst)
        {
            //check if the config file exists; if not, create a default config file
            if (File.Exists(Application.StartupPath + @"\config.xml") == false)
            {
                String generateSavePath = @"C:\Users\" + Environment.UserName + @"\Videos\WaLLBoT Recordings\";
                //generate a default save path based on the user that is currently logged in
                System.IO.Directory.CreateDirectory(generateSavePath);
                //write a new file based on the defaults
                SettingsData theSettings = new SettingsData(audioDeviceLst[0], vidDeviceLst[0], generateSavePath, new YCbCr(50, 124, 130), new YCbCr(90, 140, 140), 0.15f, 500, 3);
                
                //write code just coppied into the static version...for ease
                XmlSerializer toSerialize = new XmlSerializer(typeof(SettingsData));
                //config file is local to the app's executable
                TextWriter textWriter = new StreamWriter(Application.StartupPath + @"\config.xml");
                toSerialize.Serialize(textWriter, theSettings);
                //close the writer...b/c that'd be dumb to leave it open
                textWriter.Close();
            }
            //now that the file is existent, make
            XmlSerializer deserializer = new XmlSerializer(typeof(SettingsData));
            TextReader textReader = new StreamReader(Application.StartupPath + @"\config.xml");
            SettingsData localSettings = (SettingsData)deserializer.Deserialize(textReader);
            textReader.Close();
            //returns the 
            return (localSettings);
        }

        public void writeFile(SettingsData theSettings)
        {
            //serialize that shit!
            XmlSerializer toSerialize = new XmlSerializer(typeof(SettingsData));
            //config file is local to the app's executable
            TextWriter textWriter = new StreamWriter(Application.StartupPath + @"\config.xml");
            toSerialize.Serialize(textWriter, theSettings);
            //close the writer...b/c that'd be dumb to leave it open
            textWriter.Close();
        }

        public void populateComboBoxes()
        {
            //take the list of devices and populate the appropriate comboboxes in the GUI
            foreach (String element in vidDeviceLst)
            {
                vidDevBox.Items.Add(element);
            }
            foreach (String element in audioDeviceLst)
            {
                audioDevBox.Items.Add(element);
            }
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            //open the folder browser and assign the result to the corresponding text box
            folderBrowserDialog1.SelectedPath = settings.savePath;
            folderBrowserDialog1.ShowDialog();
            //display the newly selected path
            String tempStr = folderBrowserDialog1.SelectedPath;
            if(tempStr[tempStr.Length - 1] == '\\')
                pathBox.Text = tempStr;
            else
                //adds needed slash if not present
                pathBox.Text = tempStr + '\\';
        }
        
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //set all the color values
            this.recordColorTextBox();
            //build the settings "structure" with all sorts of good data
            SettingsData theSettings = new SettingsData(audioDevBox.Text, vidDevBox.Text, pathBox.Text,this.minYCbCr,this.maxYCbCr,this.percentSkin,this.msRefresh,this.cycleConfirm);
            //write the current data to a file
            writeFile(theSettings);
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void vidSetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                deviceSource.ShowConfigurationDialog(ConfigurationDialog.VideoCaptureDialog, new HandleRef(this, this.Handle));
            }
            catch (ArgumentErrorException Ex)
            {
                Console.WriteLine("Video device does not support options menu.");
                MessageBox.Show("Video device does not support options menu.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void audDevBtn_Click(object sender, EventArgs e)
        {
            try
            {
                deviceSource.ShowConfigurationDialog(ConfigurationDialog.AudioCaptureDialog, new HandleRef(this, this.Handle));
            }
            catch (ArgumentException Ex)
            {
                Console.WriteLine("Audio device does not support options menu.");
                MessageBox.Show("Audio device does not support options menu.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox1 open = new AboutBox1();
            open.ShowDialog();
        }
    }
}
