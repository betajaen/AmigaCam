namespace AmigaCam
{
    partial class Controls
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bDevice = new System.Windows.Forms.ComboBox();
            this.bRes = new System.Windows.Forms.ComboBox();
            this.bOffsetX = new System.Windows.Forms.NumericUpDown();
            this.bSrcPixelSize = new System.Windows.Forms.ComboBox();
            this.bOffsetY = new System.Windows.Forms.NumericUpDown();
            this.bCropW = new System.Windows.Forms.NumericUpDown();
            this.bCropH = new System.Windows.Forms.NumericUpDown();
            this.bTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.bPresets = new System.Windows.Forms.Button();
            this.bPresetsCtx = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCropW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCropH)).BeginInit();
            this.SuspendLayout();
            // 
            // bDevice
            // 
            this.bDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bDevice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bDevice.FormattingEnabled = true;
            this.bDevice.Location = new System.Drawing.Point(12, 12);
            this.bDevice.Name = "bDevice";
            this.bDevice.Size = new System.Drawing.Size(182, 33);
            this.bDevice.TabIndex = 0;
            this.bDevice.SelectedIndexChanged += new System.EventHandler(this.bDevice_SelectedIndexChanged);
            // 
            // bRes
            // 
            this.bRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bRes.FormattingEnabled = true;
            this.bRes.Location = new System.Drawing.Point(200, 12);
            this.bRes.Name = "bRes";
            this.bRes.Size = new System.Drawing.Size(182, 33);
            this.bRes.TabIndex = 1;
            this.bRes.SelectedIndexChanged += new System.EventHandler(this.bRes_SelectedIndexChanged);
            // 
            // bOffsetX
            // 
            this.bOffsetX.Location = new System.Drawing.Point(514, 14);
            this.bOffsetX.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.bOffsetX.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            -2147483648});
            this.bOffsetX.Name = "bOffsetX";
            this.bOffsetX.Size = new System.Drawing.Size(95, 31);
            this.bOffsetX.TabIndex = 2;
            this.bOffsetX.ValueChanged += new System.EventHandler(this.bOffsetX_ValueChanged);
            // 
            // bSrcPixelSize
            // 
            this.bSrcPixelSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bSrcPixelSize.Items.AddRange(new object[] {
            "1x1",
            "2x2",
            "3x3"});
            this.bSrcPixelSize.Location = new System.Drawing.Point(388, 12);
            this.bSrcPixelSize.Name = "bSrcPixelSize";
            this.bSrcPixelSize.Size = new System.Drawing.Size(120, 33);
            this.bSrcPixelSize.TabIndex = 3;
            this.bSrcPixelSize.SelectedIndexChanged += new System.EventHandler(this.bSrcPixelSize_SelectedIndexChanged);
            // 
            // bOffsetY
            // 
            this.bOffsetY.Location = new System.Drawing.Point(615, 12);
            this.bOffsetY.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.bOffsetY.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            -2147483648});
            this.bOffsetY.Name = "bOffsetY";
            this.bOffsetY.Size = new System.Drawing.Size(95, 31);
            this.bOffsetY.TabIndex = 4;
            this.bOffsetY.ValueChanged += new System.EventHandler(this.bOffsetY_ValueChanged);
            // 
            // bCropW
            // 
            this.bCropW.Location = new System.Drawing.Point(716, 12);
            this.bCropW.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.bCropW.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.bCropW.Name = "bCropW";
            this.bCropW.Size = new System.Drawing.Size(95, 31);
            this.bCropW.TabIndex = 5;
            this.bCropW.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.bCropW.ValueChanged += new System.EventHandler(this.bCropW_ValueChanged);
            // 
            // bCropH
            // 
            this.bCropH.Location = new System.Drawing.Point(817, 12);
            this.bCropH.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.bCropH.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.bCropH.Name = "bCropH";
            this.bCropH.Size = new System.Drawing.Size(95, 31);
            this.bCropH.TabIndex = 6;
            this.bCropH.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.bCropH.ValueChanged += new System.EventHandler(this.bCropH_ValueChanged);
            // 
            // bPresets
            // 
            this.bPresets.ContextMenuStrip = this.bPresetsCtx;
            this.bPresets.Location = new System.Drawing.Point(918, 11);
            this.bPresets.Name = "bPresets";
            this.bPresets.Size = new System.Drawing.Size(89, 31);
            this.bPresets.TabIndex = 8;
            this.bPresets.Text = "Presets";
            this.bPresets.UseVisualStyleBackColor = true;
            this.bPresets.Click += new System.EventHandler(this.bPresets_Click);
            // 
            // bPresetsCtx
            // 
            this.bPresetsCtx.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bPresetsCtx.Name = "bPresetsCtx";
            this.bPresetsCtx.Size = new System.Drawing.Size(61, 4);
            this.bPresetsCtx.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // Controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 56);
            this.Controls.Add(this.bPresets);
            this.Controls.Add(this.bCropH);
            this.Controls.Add(this.bCropW);
            this.Controls.Add(this.bOffsetY);
            this.Controls.Add(this.bSrcPixelSize);
            this.Controls.Add(this.bOffsetX);
            this.Controls.Add(this.bRes);
            this.Controls.Add(this.bDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 40);
            this.Name = "Controls";
            this.Text = "Amiga Camera";
            this.MaximumSizeChanged += new System.EventHandler(this.Controls_MaximumSizeChanged);
            this.Load += new System.EventHandler(this.Controls_Load);
            this.LocationChanged += new System.EventHandler(this.Controls_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.Controls_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCropW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCropH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox bDevice;
        private ComboBox bRes;
        private NumericUpDown bOffsetX;
        private ComboBox bSrcPixelSize;
        private NumericUpDown bOffsetY;
        private NumericUpDown bCropW;
        private NumericUpDown bCropH;
        private ToolTip bTooltip;
        private Button bPresets;
        private ContextMenuStrip bPresetsCtx;
    }
}