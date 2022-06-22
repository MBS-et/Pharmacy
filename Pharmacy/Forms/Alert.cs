using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Alert : Form
    {
        public Alert()
        {
            InitializeComponent();
        }
        public enum enumAction
        {
            wait,
            start,
            close
        }
        private Alert.enumAction Action;
        private int x, y;
        private void btnClose_Click(object sender, EventArgs e)
        {
            NotificationTimer.Interval = 1;
            Action = enumAction.close;
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            switch (Action)
            {
                case enumAction.wait:
                    NotificationTimer.Interval = 5000;
                    Action = enumAction.close;
                    break;
                case enumAction.start:
                    NotificationTimer.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            Action = enumAction.wait;
                        }
                    }
                    break;
                case enumAction.close:
                    NotificationTimer.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
        }

        public void showAlert(string msg)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;

            string fname;
            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Alert frm = (Alert)Application.OpenForms[fname];
                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    this.Location = new Point(this.x, this.y + 5);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            this.lblMessage.Text = msg;
            this.Show();
            this.Action = enumAction.start;
            NotificationTimer.Interval = 1;
            NotificationTimer.Start();
        }
    }
}
