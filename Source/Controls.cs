using Camera_NET;
using System.Reflection;
using System.Security.Cryptography.Xml;
using DirectShowLib;
using System;
using System.Runtime.InteropServices;

namespace AmigaCam
{
    public partial class Controls : Form
    {

        Video videoForm;
        bool handleEvents =true;
        CameraControl bCamera;
        CameraChoice deviceChoice;
        System.Runtime.InteropServices.ComTypes.IMoniker? deviceMoniker;
        Resolution? deviceResolution;

        public Controls()
        {
            InitializeComponent();

            handleEvents = false;

            bDevice.SelectedIndex = -1;
            bRes.SelectedIndex = -1;
            bTooltip.SetToolTip(bDevice, "Video Capture Device");    
            bTooltip.SetToolTip(bRes, "Video Capture Resolution");
            bTooltip.SetToolTip(bSrcPixelSize, "Pixel Size in Source Video");
            bTooltip.SetToolTip(bOffsetX, "Image Origin Columns");
            bTooltip.SetToolTip(bOffsetY, "Image Origin Lines");
            bTooltip.SetToolTip(bCropW, "Image Size Width (px)");
            bTooltip.SetToolTip(bCropH, "Image Size Height (px)");

            bSrcPixelSize.SelectedIndex = 0;

            handleEvents = true;

            EnableDisableControls();
            UpdatePresets();
        }

        void EnableDisableControls()
        {
            handleEvents = false;

            if (bDevice.SelectedIndex == -1)
            {
                bRes.SelectedIndex = -1;
                bRes.Enabled = false;
            }
            else
            {
                bRes.Enabled = true;
            }

            bSrcPixelSize.Enabled = bRes.Enabled;
            bOffsetX.Enabled = bRes.Enabled;
            bOffsetY.Enabled = bRes.Enabled;
            bCropW.Enabled = bRes.Enabled;
            bCropH.Enabled = bRes.Enabled;
            bPresets.Enabled = bRes.Enabled;


            handleEvents = true;
        }

        private void Controls_Load(object sender, EventArgs e)
        {
            videoForm = new Video(this);
            videoForm.Show(this);
            UpdateVideoPos();
            ReadPresets();

        }

        public void Start()
        {
            bCamera = videoForm.bCamera;
            ScanDevices();
        }

        void ScanDevices()
        {
            handleEvents = false;
            bDevice.Items.Clear();
            bDevice.SelectedIndex = -1;
            deviceChoice = new CameraChoice();
            deviceChoice.UpdateDeviceList();

            for (int i = 0; i < deviceChoice.Devices.Count; i++)
            {
                DirectShowLib.DsDevice device = deviceChoice.Devices[i];
                bDevice.Items.Add($"{i}:{device.Name}");
            }

            handleEvents = true;

            bDevice.SelectedIndex = 0;
        }

        void ScanResolutions()
        {
            int bestIndex = 0;

            handleEvents = false;

            ResolutionList resolutions = Camera.GetResolutionList(deviceMoniker);

            bRes.Items.Clear();
            bRes.SelectedIndex = -1;

            for (int i = 0; i < resolutions.Count; i++)
            {
                Resolution? res = resolutions[i];
                bRes.Items.Add($"{res.Width}x{res.Height}");

                if (res.Width == 640 && res.Height == 480)
                {
                    bestIndex = i;
                }

                if (res.Width == 640 && res.Height == 512)
                {
                    bestIndex = i;
                }
                
                if (res.Width == 800 && res.Height == 600)
                {
                    bestIndex = i;
                }

            }


            handleEvents = true;

            bRes.SelectedIndex = bestIndex;

            EnableDisableControls();
        }

        void SelectDevice(int index)
        {
            if (deviceChoice == null)
                return;

            var device = deviceChoice.Devices[index];
            deviceMoniker = device.Mon;

            ScanResolutions();
            EnableDisableControls();
        }
        
        void SelectResolution(int index)
        {
            if (deviceChoice == null && deviceMoniker != null)
                return;

            deviceResolution = Camera.GetResolutionList(deviceMoniker)[index];

            bCamera.SetCamera(deviceMoniker, deviceResolution);

            EnableDisableControls();
            UpdateVideoSizeAndCropping();
            UpdateVideoPos();
        }

        void UpdateVideoPos()
        {
            if (videoForm != null)
            {
                Screen screen = Screen.FromPoint(videoForm.Location);

                if (screen == null)
                {
                    videoForm.Top = this.Bottom;
                    videoForm.Left = this.Left;
                }
                else
                {
                    int bw = screen.Bounds.Width;
                    int bh = screen.Bounds.Height;

                    int w = videoForm.Width;
                    int h = videoForm.Height;

                    int x = this.Left;
                    int y = this.Bottom;

                    if (x < 0)
                    {
                        x = 0;
                    }

                    if (x + w > bw)
                    {
                        x = bw - w;
                    }

                    if (y < 0)
                    {
                        y = 0;
                    }

                    if (y + h > bh)
                    {
                        y = this.Top - h;
                    }


                    videoForm.Location = new Point(x, y);
                }

            }
        }

        void UpdateVideoSizeAndCropping()
        {
            if (deviceResolution == null)
                return;

            int resWidth = deviceResolution.Width;
            int resHeight = deviceResolution.Height;

            int sourcePixelSize = (bSrcPixelSize.SelectedIndex + 1);

            int imageX = ((int) bOffsetX.Value);
            int imageY = ((int) bOffsetY.Value);
            int imageWidth = ((int) bCropW.Value);
            int imageHeight = ((int)bCropH.Value);

            bCamera.Size = new Size(resWidth / sourcePixelSize, resHeight / sourcePixelSize);
            bCamera.Location = new Point(imageX, imageY);            
            videoForm.Size = new Size(imageWidth, imageHeight);
        }

        private void Controls_SizeChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            UpdateVideoPos();
        }

        private void Controls_LocationChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            UpdateVideoPos();
        }

        private void Controls_MaximumSizeChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            UpdateVideoPos();
        }

        private void bDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            SelectDevice(bDevice.SelectedIndex);
        }

        private void bRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            SelectResolution(bRes.SelectedIndex);
        }

        private void bSrcPixelSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            UpdateVideoSizeAndCropping();
            UpdateVideoPos();
        }

        private void bDstPixelSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            UpdateVideoSizeAndCropping();
            UpdateVideoPos();
        }

        private void bOffsetX_ValueChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            UpdateVideoSizeAndCropping();
            UpdateVideoPos();
        }

        private void bOffsetY_ValueChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            UpdateVideoSizeAndCropping();
            UpdateVideoPos();
        }

        private void bCropW_ValueChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            UpdateVideoSizeAndCropping();
            UpdateVideoPos();
        }

        private void bCropH_ValueChanged(object sender, EventArgs e)
        {
            if (handleEvents == false)
                return;

            UpdateVideoSizeAndCropping();
            UpdateVideoPos();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void bPresets_Click(object sender, EventArgs e)
        {
            bPresetsCtx.Show(bPresets, Point.Empty);
        }

        class Preset
        {
            public string Name;
            public int x, y, w, h, resW, resH, srcPixelSize;
        }

        List<Preset> presets = new();

        void ApplyPreset(Preset preset)
        {
            handleEvents = false;
            bOffsetX.Value = preset.x;
            bOffsetY.Value = preset.y;
            bCropW.Value = preset.w;
            bCropH.Value = preset.h;
            if (preset.srcPixelSize != -1)
            {
                bSrcPixelSize.SelectedIndex = preset.srcPixelSize - 1;
            }
            handleEvents = true;

            if (preset.resW != -1 && preset.resH != -1 && deviceMoniker != null)
            {
                var list = Camera.GetResolutionList(deviceMoniker);
                for (int i = 0; i < list.Count; i++)
                {
                    Resolution res = list[i];
                    if (res.Width == preset.resW && res.Height == preset.resH)
                    {
                        bRes.SelectedIndex = i;
                        break;
                    }
                }

            }


            UpdateVideoSizeAndCropping();
            UpdateVideoPos();
        }

        void UpdatePresets()
        {
            bPresetsCtx.Items.Clear();

            var reload = new ToolStripButton();
            reload.Text = "Refresh";
            reload.Click += ReloadPresets_Click;

            bPresetsCtx.Items.Add(reload);

            bPresetsCtx.Items.Add(new ToolStripSeparator());

            foreach(var preset in presets)
            {
                var ti = new ToolStripButton()
                {
                    Text = preset.Name,
                    Tag = preset                    
                };
                ti.Click += Preset_Click;

                bPresetsCtx.Items.Add(ti);
            }
        }

        private void ReloadPresets_Click(object? sender, EventArgs e)
        {
            ReadPresets();
        }

        void ReadPresets()
        {
            presets.Clear();

            try
            {
                string[] lines = File.ReadAllLines("Presets.txt");
                Array.Sort<string>(lines);

                foreach (var line in lines)
                {
                    var l = line.Trim();
                    int comment = l.IndexOf('#');
                    if (comment != 0)
                    {
                        l = l.Substring(comment+1).Trim();
                    }

                    if (string.IsNullOrWhiteSpace(l))
                        continue;

                    string[] parts = l.Split(",");

                    Preset p = new Preset();
                    p.Name = parts[0];
                    p.x = Int32.Parse(parts[1]);
                    p.y = Int32.Parse(parts[2]);
                    p.w = Int32.Parse(parts[3]);
                    p.h = Int32.Parse(parts[4]);
                    p.resW = -1;
                    p.resH = -1;
                    p.srcPixelSize = 1;

                    if (parts.Length >= 5)
                    {
                        p.resW = Int32.Parse(parts[5]);
                        p.resH = Int32.Parse(parts[6]);
                    }

                    if (parts.Length >= 8)
                    {
                        p.srcPixelSize = Int32.Parse(parts[7]);
                    }
                    presets.Add(p);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            UpdatePresets();
        }

        private void Preset_Click(object? sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ApplyPreset((Preset) button.Tag);
        }
    }
}