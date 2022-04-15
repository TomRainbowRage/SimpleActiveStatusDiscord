using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DiscordActiveChanger
{
    public partial class formti : Form
    {

        int mov;
        int movX;
        int movY;


        public formti()
        {
            InitializeComponent();
        }

        

        

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;
            
            if(Properties.Settings.Default.StartMinimized == true)
            {
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.Visible = true;
            }

            if(Properties.Settings.Default.StartMinimized == false)
            {                          
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
                WindowState = FormWindowState.Normal;
            }

            Properties.Settings.Default.StartMinimized = true;
            Properties.Settings.Default.Save();

            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("My application", Application.ExecutablePath.ToString());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Makes version of itself
            //formti form2 = new formti();
            //form2.Visible = true;


            Form2 form2 = new Form2();
            form2.Visible = true;
        }

        private void formti_SizeChanged(object sender, EventArgs e)
        {
            //notifyIcon1.Icon = SystemIcons.Application;
            //notifyIcon1.BalloonTipText = "Your progran has been minimized to system tray";
            //notifyIcon1.ShowBalloonTip(1000);
            //this.ShowInTaskbar = false;
            //notifyIcon1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
                
            
            notifyIcon1.Icon = SystemIcons.Application;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void hELSADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartMinimized = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
