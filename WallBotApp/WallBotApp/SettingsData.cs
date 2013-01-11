using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WallBotApp
{
    /// <summary>
    /// Class that lays out a structure for relevant data, stored under setttings
    /// </summary>
    public class SettingsData
    {
        public String audioDev
        { get; set; }
        public String vidDev
        { get; set; }
        public String savePath
        { get; set; }
        public String fileType
        { get; set; }
        public SettingsData()
        {
        }
        public SettingsData(String audioDev, String vidDev, String savePath,String fileType)
        {
            this.audioDev = audioDev;
            this.vidDev = vidDev;
            this.savePath = savePath;
            this.fileType = fileType;
        }
    }
}
