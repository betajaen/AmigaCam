using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigaCam
{
    public partial class Video : Form
    {
        public Camera_NET.CameraControl bCamera;
        Controls controlsForm;

        public Video(Controls controls)
        {
            controlsForm = controls;

            InitializeComponent();
            bCamera = new Camera_NET.CameraControl();
            bCamera.Width = 640;
            bCamera.Height = 480;
            bCamera.Left = 0;
            bCamera.Top = 0;
            bCamera.AutoScaleMode = AutoScaleMode.None;
            bCamera.AutoScroll = false;

            this.Controls.Add(bCamera);
        }

        private void Video_Load(object sender, EventArgs e)
        {
            controlsForm.Start();
        }
    }
}
