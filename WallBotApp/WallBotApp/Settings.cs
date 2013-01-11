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
            fileFormatBox.SelectedItem = settings.fileType;

            //set ok/cancel btns
            this.saveBtn.DialogResult = DialogResult.OK;
            this.cancelBtn.DialogResult = DialogResult.Cancel;
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
                writeFile(new SettingsData(this.audioDeviceLst[0], this.vidDeviceLst[0], generateSavePath,".wmv"));
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
                SettingsData theSettings = new SettingsData(audioDeviceLst[0], vidDeviceLst[0], generateSavePath,".wmv");
                
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
            //build the settings "structure" with all sorts of good data
            SettingsData theSettings = new SettingsData(audioDevBox.Text, vidDevBox.Text, pathBox.Text,fileFormatBox.Text);
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
