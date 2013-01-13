using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace WallBotApp
{
    public partial class Messenger : Form
    {
        private System.Timers.Timer tempTimer;
        private delegate void killCallback();
        public Messenger(String Text)
        {
            InitializeComponent();
            this.label1.Text = Text;
            //construct the self-kill timer
            tempTimer = new System.Timers.Timer(2000);
            tempTimer.Elapsed += new ElapsedEventHandler(CloseBox);
        }

        private void Message_Shown(object sender, EventArgs e)
        {
            tempTimer.Enabled = true;
        }

        private void CloseBox(object source, ElapsedEventArgs e)
        {
            tempTimer.Enabled = false;
            this.KillConfirm();
        }

        //delegate to kill this safely
        private void KillConfirm()
        {
            if (this.InvokeRequired)
            {
                killCallback d = new killCallback(KillConfirm);
                this.Invoke(d);
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }
    }
}
