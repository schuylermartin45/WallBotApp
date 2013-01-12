using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WallBotApp
{
    /// <summary>
    /// Class that lays out a structure for relevant data, stored under setttings
    /// </summary>
    [Serializable]
    public class SettingsData
    {
        public String audioDev
        { get; set; }
        public String vidDev
        { get; set; }
        public String savePath
        { get; set; }
        //color components to track
        public YCbCr minYCbCr
        { get; set; }
        public YCbCr maxYCbCr
        { get; set; }
        public float percentSkin
        { get; set; }
        public int msRefresh
        { get; set; }
        public int cycleConfirm
        { get; set; }
        public SettingsData()
        {
        }
        public SettingsData(String audioDev, String vidDev, String savePath, YCbCr minYCbCr, YCbCr maxYCbCr, float percentSkin, int msRefresh, int cycleConfirm)
        {
            this.audioDev = audioDev;
            this.vidDev = vidDev;
            this.savePath = savePath;
            //color values
            this.minYCbCr = minYCbCr;
            this.maxYCbCr = maxYCbCr;
            this.percentSkin = percentSkin;
            this.msRefresh = msRefresh;
            this.cycleConfirm = cycleConfirm;
        }
    }
}
